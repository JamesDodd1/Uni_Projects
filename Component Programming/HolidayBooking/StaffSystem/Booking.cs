using Libraries;
using StaffSystem.ServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapacityDates = Libraries.CapacityDates;
using Employee = Libraries.Employee;
using Holidays = Libraries.Holidays;
using SoapCapacityDates = StaffSystem.ServiceReference.CapacityDates;
using SoapEmployee = StaffSystem.ServiceReference.Employee;
using SoapHolidays = StaffSystem.ServiceReference.Holidays;
using StaffSystem.Properties;
using System.Threading;

namespace StaffSystem
{
    public partial class BookingForm : Form
    {
        private WebServiceSoapClient ws = new WebServiceSoapClient();
        private Employee user;
        private Thread thread;

        public BookingForm()
        {
            InitializeComponent();
        }


        private void BookingForm_Load(object sender, EventArgs e)
        {
            user = SetEmployee(Settings.Default.username);

            thread = new Thread(new ThreadStart(SetupComponents));
            thread.Start();
        }


        private void SetupComponents()
        {
            // Request constraints component
            constraints.Management = ws.GetManagement();
            constraints.SeniorStaff = ws.GetSeniors();

            constraints.DefaultTime = new Libraries.CapacityDates { Minimum = ws.DefaultOnDuty().Minimum };
            constraints.TimePeriods = SetCapactiyDates(ws.GetPeriodTimes());
            constraints.RoleTotal = ws.GetTotalRoleNum(user.RoleName, user.DepartmentName);
            constraints.DepartmentTotal = ws.GetTotalDepartmentNum(user.DepartmentName);
        }


        private void BookingButton_Click(object sender, EventArgs e)
        {
            // Wait for component setup thread
            thread.Join();


            List<Holidays> approved = SetHolidays(ws.GetApprovedHolidays());
            constraints.AcceptedHolidays = approved;


            // Selected data
            DateTime from = fromCalendar.SelectionStart;
            DateTime to = toCalendar.SelectionStart;
            DateTime today = DateTime.Now;


            // Validate selected date
            if (from >= today && to >= today && to >= from)
            {
                Holidays booking = new Holidays { Staff = user, Start = from, End = to };

                try
                {
                    // If constraints passed
                    if (constraints.CheckHoliday(booking) == null)
                    {
                        ws.SubmitBooking(user.Username, booking.Start, booking.End);

                        // Update label
                        msgLabel.Visible = true;
                        msgLabel.ForeColor = Color.Green;
                        msgLabel.Text = "Holiday Booked";
                    }
                    else
                    {
                        booking = constraints.SuggestNewDate(booking);

                        // If new recommended date found
                        if (booking != null)
                        {
                            // Alternative date message box
                            string message = "An alternative date has been found between " + booking.Start.ToLongDateString() + " - " + booking.End.ToLongDateString() + "\nWould you like to book then?";
                            DialogResult answer = MessageBox.Show(message, "Alternative Date", MessageBoxButtons.YesNo);

                            if (answer == DialogResult.Yes)
                            {
                                ws.SubmitBooking(user.Username, booking.Start, booking.End);

                                // Update label
                                msgLabel.Visible = true;
                                msgLabel.ForeColor = Color.Green;
                                msgLabel.Text = "Holiday Booked";
                            }
                        }
                        else
                        {
                            // Update label
                            msgLabel.Visible = true;
                            msgLabel.ForeColor = Color.Red;
                            msgLabel.Text = "Cannot book during that period";
                        }
                    }
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1);
                }
            }
            else
            {
                // Update label
                msgLabel.Visible = true;
                msgLabel.ForeColor = Color.Red;
                msgLabel.Text = "Date selected cannot be chosen";
            }
        }


        // Convert WebServiceSoapClient Holidays to Libraries Holidays 
        private List<Holidays> SetHolidays(SoapHolidays[] soapHolidays)
        {
            List<Holidays> holidays = new List<Holidays>();
            foreach (SoapHolidays soapHoliday in soapHolidays)
            {
                holidays.Add(new Holidays
                {
                    Staff = new Employee
                    {
                        Username = soapHoliday.Staff.Username,
                        RoleName = soapHoliday.Staff.RoleName,
                        DepartmentName = soapHoliday.Staff.DepartmentName,
                    },
                    Start = soapHoliday.Start,
                    End = soapHoliday.End,
                    Pending = soapHoliday.Pending,
                    Approved = soapHoliday.Approved,
                    Canceled = soapHoliday.Canceled,
                });
            }

            return holidays;
        }


        // Convert WebServiceSoapClient CapacityDates to Libraries CapacityDates 
        private List<CapacityDates> SetCapactiyDates(SoapCapacityDates[] soapCapacityDates)
        {
            List<CapacityDates> timePeriods = new List<CapacityDates>();
            foreach (SoapCapacityDates soapPeriod in soapCapacityDates)
            {
                timePeriods.Add(new CapacityDates
                {
                    Name = soapPeriod.Name,
                    Minimum = soapPeriod.Minimum,
                    Start = soapPeriod.Start,
                    End = soapPeriod.End,
                    Annual = soapPeriod.Annual
                });
            }

            return timePeriods;
        }


        // Convert WebServiceSoapClient Employee to Libraries Employee 
        private Employee SetEmployee(string username)
        {
            SoapEmployee soapUser = ws.GetStaff(username);
            Employee person = new Employee
            {
                Username = soapUser.Username,
                FirstName = soapUser.FirstName,
                LastName = soapUser.LastName,
                RoleName = soapUser.RoleName,
                DepartmentName = soapUser.DepartmentName,
                Entitlement = soapUser.Entitlement,
            };

            return person;
        }


        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
