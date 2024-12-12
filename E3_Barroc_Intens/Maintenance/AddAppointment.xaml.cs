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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace E3_Barroc_Intens.Maintenance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddAppointment : Page
    {
        public AddAppointment()
        {
            this.InitializeComponent();
        }
        // Dankzij 'static' blijft er maar 1 instantie van deze lijst.
        // Ondanks dat de gebruiker terug kan gaan (met de 'Go back'-knop) blijven
        // de calendar items dan wel hetzelfde in de lijst. Zonder static zou de
        // lijst iedere keer opnieuw aangemaakt worden, wanneer de Page opnieuw
        // aangemaakt wordt (bij openen)
        static List<Data.Maintenance> AllCalendarItems = new List<Data.Maintenance>();

        private void CreateAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton repeatInterval = null;
            if (CreateAppointmentDiscriptionTextBox.Text == null || CreateAppointmentDiscriptionTextBox.Text == "")
            {
                return;
            }
            if (CreateAppointmentFromDateCalendarDatePicker.Date == null)
            {
                return;
            }
            if (CreateAppointmentSelectUserComboBox.SelectedItem == null)
            {
                return;
            }
            if (CreateAppointmentSelectCustomerComboBox.SelectedItem == null)
            {
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
                    return;
                }
                else
                {
                    return;
                }
            }

            var description = CreateAppointmentDiscriptionTextBox.Text;
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
                AllCalendarItems = db.Maintenances.Include(ali => ali.Costumer).ToList();

                var relevantCalendarItems = AllCalendarItems.Where(item => item.AppointmentDate.Date == calendarItemDate.Date);

                // De DataContext is vanuit de xaml te benaderen met {Binding}
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
                var dialog = new ContentDialog()
                {
                    //Title = clickedCalendarItem.Subject,
                    //Content = $"Start: {clickedCalendarItem.StartTime}\nEnd: {clickedCalendarItem.EndTime}\nLocation: {clickedCalendarItem.Location}\nDetails: {clickedCalendarItem.Details}",
                    //CloseButtonText = "Close",
                    //XamlRoot = this.XamlRoot,

                    Title = $"Appointment {appointment.Costumer.Name}",
                    Content = $"Customer Name: {appointment.Costumer.Name}\nCustomer Location: {appointment.Costumer.Location}\nDiscription: {appointment.Description}\nAppointment Date and Time: {appointment.AppointmentDate}",
                    CloseButtonText = "Close",
                    XamlRoot = this.XamlRoot,
                };

                await dialog.ShowAsync();
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
    }
}
