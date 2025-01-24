using E3_Barroc_Intens.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Appointments;
using Windows.Foundation;
using Windows.Foundation.Collections;


namespace E3_Barroc_Intens.Maintenance
{

    public sealed partial class AddAppointment : Page
    {
        public AddAppointment()
        {
            this.InitializeComponent();
        }
       
        static ObservableCollection<Data.Maintenance> AllCalendarItems = new ObservableCollection<Data.Maintenance>();

        private void CreateAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton repeatInterval = null;

            if (CreateAppointmentDiscriptionTextBox.Text == null || CreateAppointmentDiscriptionTextBox.Text == "")
            {
                ContentDialogView("discription niet ingevult", "discription is niet ingevult. vul het in om een appointment aan te kunnen maken");
                return;
            }

            bool isLetterInDescription = false;
            int firstLetterNumber = 0;
            int lastLetterNumber = 0;
            string description = "";

            for (int i = 0; i < CreateAppointmentDiscriptionTextBox.Text.Length; i++)
            {
                if (isLetterInDescription && firstLetterNumber != 0 && CreateAppointmentDiscriptionTextBox.Text[i].ToString() != " ")
                {
                    lastLetterNumber = i;
                }
                else if (CreateAppointmentDiscriptionTextBox.Text[i].ToString() != " ")
                {
                    isLetterInDescription = true;
                        firstLetterNumber = i;
                }
            }

            if (isLetterInDescription)
            {
                for (int i = firstLetterNumber; i < lastLetterNumber + 1; i++)
                {
                    description = description + CreateAppointmentDiscriptionTextBox.Text[i].ToString();
                }
            }

            if (description == "")
            {
                ContentDialogView("discription bevat alleen spaties", "discription bevat alleen spaties. zorg dat je voor discription niet alleen spaties invult om een appointment aan te kunnen maken");
                return;
            }

            if (CreateAppointmentFromDateCalendarDatePicker.Date == null)
            {
                ContentDialogView("vanaf datum niet geselecteerd", "er is geen vanaf datum geselecteerd. selecteer een vanaf datum om een appointment aan te kunnen maken");
                return;
            }

            if (CreateAppointmentSelectUserComboBox.SelectedItem == null)
            {
                ContentDialogView("geen medewerker geselecteerd", "er is geen medewerker geselecteerd. selecteer een medewerker om een appointment aan te kunnen maken");
                return;
            }

            if (CreateAppointmentSelectCustomerComboBox.SelectedItem == null)
            {
                ContentDialogView("geen klant geselecteerd", "er is geen klant geselecteerd. selecteer een klant om een appointment aan te kunnen maken");
                return;
            }

            if (CreateAppointmentRoutineCheckBox.IsChecked == true)
            {
                if (CreateAppointmentWeeklyRadioButton.IsChecked == true)
                {
                    repeatInterval = CreateAppointmentWeeklyRadioButton as RadioButton;
                }
                else if (CreateAppointmentMonthlyRadioButton.IsChecked == true)
                {
                    repeatInterval = CreateAppointmentMonthlyRadioButton as RadioButton;
                }
                else if (CreateAppointmentToDateCalenderDatePicker.Date == null)
                {
                    ContentDialogView("eind datum niet geselecteerd", "er is geen eind datum geselecteerd. selecteer een eind datum om een appointment aan te kunnen maken");
                    return;
                }
                else
                {
                    ContentDialogView("datum interval niet geselecteerd", "er is geen datum interval geselecteerd. selecteer een datum interval om een appointment aan te kunnen maken");
                    return;
                }
            }

            //var description = CreateAppointmentDiscriptionTextBox.Text;
            var date = CreateAppointmentFromDateCalendarDatePicker.Date.Value.Date;
            var selectedUser = CreateAppointmentSelectUserComboBox.SelectedItem as RoleUser;
            var customer = CreateAppointmentSelectCustomerComboBox.SelectedItem as Customer;

            using (var db = new AppDbContext())
            {
                var user = db.Users.Where(u => u.Id == selectedUser.UserId).First();
                customer = db.Customers.Where(c => c.Name == customer.Name).First();

                var appointment = new Data.Maintenance
                {
                    UserId = user.Id,
                    CostumerId = customer.Id,
                    Description = description,
                    AppointmentDate = date,
                };

                db.Maintenances.Add(appointment);
                AllCalendarItems.Add(appointment);

                if (repeatInterval != null)
                {
                    var isRunning = true;
                    do
                    {
                        if (repeatInterval == CreateAppointmentWeeklyRadioButton)
                        {
                            date = date.AddDays(7);
                        }
                        else if (repeatInterval == CreateAppointmentMonthlyRadioButton)
                        {
                            date = date.AddMonths(1);
                        }

                        if (CreateAppointmentToDateCalenderDatePicker.Date != null && date <= CreateAppointmentToDateCalenderDatePicker.Date.Value.Date)
                        {
                            var repeatAppointment = new Data.Maintenance
                            {
                                UserId = user.Id,
                                CostumerId = customer.Id,
                                Description = description,
                                AppointmentDate = date,
                            };

                            db.Maintenances.Add(repeatAppointment);
                            AllCalendarItems.Add(repeatAppointment);
                        }
                        else
                        {
                            isRunning = false;
                        }

                    } while (isRunning);
                }

                db.SaveChanges();
            }

            CreateAppointmentStackPanel.Visibility = Visibility.Collapsed;
            calendarView.Visibility = Visibility.Visible;

            // Er blijkt geen nette manier om de CalendarView te 'refreshen', zodat de 
            // 'CalendarView_CalendarViewDayItemChanging' event opnieuw wordt
            // aangeroepen. Deze workaround forceert toch dat de calender ververst:
            calendarView.MinDate = calendarView.MinDate.AddMilliseconds(1);
            calendarView.SetDisplayDate(DateTime.Now);
        }

        // Gebruikte bron: https://stackoverflow.com/a/75269157
        private void CalendarView_CalendarViewDayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
        {
            var calendarItemDate = args.Item.Date;

            using (var db = new AppDbContext())
            {
                var appointments = db.Maintenances.Include(ali => ali.Costumer).ToList();

                foreach (var appointment in appointments)
                {
                    AllCalendarItems.Add(appointment);
                }

                var relevantCalendarItems = AllCalendarItems.Where(item => item.AppointmentDate.Date == calendarItemDate.Date);

                args.Item.DataContext = relevantCalendarItems;

                if (relevantCalendarItems.Count() == 0)
                {
                    args.Item.IsBlackout = true;
                }
                else
                {
                    args.Item.IsBlackout = false;
                }
            }
        }

        private async void DayItemListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedCalendarItem = (Data.Maintenance)e.ClickedItem;

            using (var db = new AppDbContext())
            {
                var appointment = db.Maintenances.Where(a => a.AppointmentDate == clickedCalendarItem.AppointmentDate && a.UserId == clickedCalendarItem.UserId && a.CostumerId == clickedCalendarItem.CostumerId).Include(a => a.Costumer).FirstOrDefault();

                if (appointment.AppointmentDate > DateTime.Now)
                {
                    var dialog = new ContentDialog()
                    {
                        Title = $"Appointment {appointment.Costumer.Name}",
                        Content = $"Customer Name: {appointment.Costumer.Name}\nCustomer Location: {appointment.Costumer.Location}\nDiscription: {appointment.Description}\nAppointment Date and Time: {appointment.AppointmentDate}",
                        CloseButtonText = "Close",
                        XamlRoot = this.XamlRoot,
                    };

                    await dialog.ShowAsync();
                }
                else
                {
                    calendarView.Visibility = Visibility.Collapsed;
                    CreateWorkVoucherStackPanel.Visibility = Visibility.Visible;
                    AppointmentIdTextBlock.Text = appointment.Id.ToString();
                    AppointmentInformationTextBlock.Text = $"Customer Name: {appointment.Costumer.Name}\nCustomer Location: {appointment.Costumer.Location}\nDiscription: {appointment.Description}\nAppointment Date and Time: {appointment.AppointmentDate}";
                }
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void MakeAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            CreateAppointmentStackPanel.Visibility = Visibility.Visible;
            calendarView.Visibility = Visibility.Collapsed;
            using (var db = new AppDbContext())
            {
                var role = db.Roles.Where(r => r.Name == "Maintenance").FirstOrDefault();
                if (role != null)
                {
                    CreateAppointmentSelectUserComboBox.ItemsSource = db.RoleUsers.Where(ru => ru.RoleId == role.Id).Include(ru => ru.User).ToList();
                    CreateAppointmentSelectCustomerComboBox.ItemsSource = db.Customers.ToList();
                }
            }
        }

        private void CreateAppointmentRoutineCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CreateAppointmentRoutineStackPanel.Visibility = Visibility.Visible;
        }

        private void CreateAppointmentRoutineCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CreateAppointmentRoutineStackPanel.Visibility = Visibility.Collapsed;
        }

        private void CreateWorkVoucherButton_Click(object sender, RoutedEventArgs e)
        {
            if (WorkVoucherTextBox.Text == null || WorkVoucherTextBox.Text == "")
            {
                ContentDialogView("er is geen discription ingevult", "er is geen workvoucher discription ingevult. vul een discription in om een workvoucher aan te kunnen maken");
                return;
            }

            CreateWorkVoucherStackPanel.Visibility = Visibility.Collapsed;

            using (var db = new AppDbContext())
            {
                var appointment = db.Maintenances.Where(a => a.Id.ToString() == AppointmentIdTextBlock.Text).FirstOrDefault();
                if (appointment != null)
                {
                    var appointmentItem = AllCalendarItems.Where(item => item.UserId == appointment.UserId && item.CostumerId == appointment.CostumerId && item.AppointmentDate == appointment.AppointmentDate).FirstOrDefault();
                    if (appointmentItem != null && AllCalendarItems.Remove(appointmentItem))
                    {
                        //throw new Exception("het is verwijderd");
                    }
                    appointment.Description = $"{appointment.Description}\n\nWorkVoucher: {WorkVoucherTextBox.Text}";
                    db.SaveChanges();
                }
            }

            calendarView.Visibility = Visibility.Visible;
            calendarView.MinDate = calendarView.MinDate.AddMilliseconds(1);
            calendarView.SetDisplayDate(DateTime.Now);
        }

        private async void ContentDialogView(string title, string content)
        {
            var dialog = new ContentDialog()
            {
                Title = title,
                Content = content,
                CloseButtonText = "Close",
                XamlRoot = this.XamlRoot,
            };

            await dialog.ShowAsync();
        }
    }
}
