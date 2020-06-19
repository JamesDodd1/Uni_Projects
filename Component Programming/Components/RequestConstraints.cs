using Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    public partial class RequestConstraints : Component
    {
        public RequestConstraints()
        {
            InitializeComponent();
        }


        public RequestConstraints(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        private class TimePeriod : CapacityDates
        {
            public TimePeriod(CapacityDates dates)
            {
                Name = dates.Name;
                Minimum = dates.Minimum;
                Start = dates.Start;
                End = dates.End;
            }

            public bool Error { get; set; }
        }


        // Declare variables
        private static List<TimePeriod> periods;
        private static TimePeriod defaultTime;

        private List<string> errorMsg;
        private List<Holidays> accepted;

        private int duration;

        public List<string> Management { get; set; }
        public List<string> SeniorStaff { get; set; }

        public CapacityDates DefaultTime
        {
            set { defaultTime = new TimePeriod(value); }
        }
        public List<CapacityDates> TimePeriods
        {
            set
            {
                periods = new List<TimePeriod>();

                foreach (CapacityDates timePeriod in value)
                    periods.Add(new TimePeriod(timePeriod));
            }
        }

        public List<Holidays> AcceptedHolidays
        {
            set
            {
                accepted = new List<Holidays>();

                // Add each holiday to accepted
                foreach (Holidays holiday in value)
                    accepted.Add(holiday);
            }
        }

        public int RoleTotal { get; set; }
        public int DepartmentTotal { get; set; }


        /// <summary>
        /// Reset all variables
        /// </summary>
        public void Clear()
        {
            periods.Clear();
            accepted.Clear();
            defaultTime = null;

            Management.Clear();
            SeniorStaff.Clear();

            DepartmentTotal = 0;
            RoleTotal = 0;
        }


        /// <summary>
        /// Checks a holiday passes the required checks
        /// </summary>
        public List<string> CheckHoliday(Holidays holiday)
        {
            // Check if variable aren't set before running
            Errors();


            errorMsg = new List<string>();
            duration = 0;


            // Run checks
            CheckEntitlement(holiday);
            CheckRole(holiday);
            CheckDepartment(holiday);

            ResetErrorFlags();


            // Return if failed constraints return error messages
            return (errorMsg.Any()) ? errorMsg : null;
        }


        // Throw errors required values are not set
        private void Errors()
        {
            if (defaultTime == null)
                throw new Exception("DefaultTime has not been set");

            if (periods == null || !periods.Any())
                throw new Exception("No TimePeriods have been added");

            if (DepartmentTotal == 0)
                throw new Exception("DepartmentTotal has not been set");

            if (RoleTotal == 0)
                throw new Exception("RoleTotal has not been set");
        }


        // Check holiday requested doesn't exceed remaining entitlement 
        private void CheckEntitlement(Holidays holiday)
        {
            int holidaysTaken = 0;

            foreach (Holidays accept in accepted)
            {
                // If staff's booked holiday
                if (holiday.Staff.Username == accept.Staff.Username)
                    holidaysTaken += Convert.ToInt32(1 + (accept.End - accept.Start).TotalDays);
            }

            duration = Convert.ToInt32(1 + (holiday.End - holiday.Start).TotalDays);

            if ((holiday.Staff.Entitlement - holidaysTaken - duration) < 0)
                errorMsg.Add("Holiday length exceeds total entitlement");
        }


        // Checks the staff's role doesn't break any constraints
        private void CheckRole(Holidays holiday)
        {
            Employee staff = holiday.Staff;
            bool error = false;


            // For each day of holiday
            for (int i = 0; i <= duration; i++)
            {
                DateTime holidayDay = holiday.Start.AddDays(i);
                int roleHolCount = 0;

                foreach (Holidays accept in accepted)
                {
                    // If staff has booked holiday
                    if (staff.Username == accept.Staff.Username && holidayDay >= accept.Start && holidayDay <= accept.End)
                    {
                        // Only show once
                        if (!error)
                        {
                            errorMsg.Add("Holiday already booked within during these dates");

                            error = true;
                        }
                    }


                    // Not from same department
                    if (staff.DepartmentName != accept.Staff.DepartmentName)
                        continue;


                    // If day does not overlap with accepted holiday
                    if (holidayDay < accept.Start || holidayDay > accept.End)
                        continue;

                    
                    // Count total number of role jobs 
                    if (staff.RoleName == accept.Staff.RoleName)
                        roleHolCount++;


                    // Check management
                    foreach (string manager in Management)
                    {
                        if (staff.RoleName == manager)
                        {
                            errorMsg.Add("Head or Deputy off");
                            return;
                        }
                    }


                    // Check senior staff
                    foreach (string senior in SeniorStaff)
                    {
                        if (staff.RoleName == senior)
                        {
                            // If more that one on duty
                            if ((RoleTotal - roleHolCount) <= 1)
                            {
                                errorMsg.Add("Too many " + staff.RoleName + " are off");
                                return;
                            }
                        }
                    }
                }
            }
        }


        // Check the staff's department doesn't break any constraints
        private void CheckDepartment(Holidays holiday)
        {
            DateTime holidayDay;

            // For each day of holiday
            for (int i = 0; i <= duration; i++)
            {
                holidayDay = holiday.Start.AddDays(i);
                int deptHolCount = 0;
                bool noPeriod = true;


                // Count department holidays
                foreach (Holidays accept in accepted)
                {
                    // If day during accepted holiday
                    if (holidayDay >= accept.Start && holidayDay <= accept.End)
                    {
                        if (holiday.Staff.DepartmentName == accept.Staff.DepartmentName)
                            deptHolCount++;
                    }
                }


                // Loop for every time period
                foreach (TimePeriod period in periods)
                {

                    // If period error set
                    if (period.Error)
                    {
                        noPeriod = true;
                        break;
                    }


                    // If day outside time period
                    if (holidayDay < period.Start || holidayDay > period.End)
                        continue;


                    // If zero, no holidays can be booked
                    if (period.Minimum == 0)
                    {
                        errorMsg.Add("No holidays can be booked during " + period.Start.ToLongDateString() + " to " + period.End.ToLongDateString());
                        period.Error = true;
                    }
                    else
                    {
                        // If another holiday breaks department on duty percentage
                        if ((((deptHolCount + 1) / DepartmentTotal) * 100) > period.Minimum)
                        {
                            errorMsg.Add("Below on duty percentage on " + holidayDay);
                            period.Error = true;
                        }
                    }
                }


                // If noPeriod and no error set
                if (noPeriod && !defaultTime.Error)
                {
                    double remainingStaff = DepartmentTotal - (deptHolCount + 1);
                    double remainPercent = (remainingStaff / DepartmentTotal) * 100;

                    // If another holiday breaks department on duty percentage
                    if (remainPercent < defaultTime.Minimum)
                    {
                        errorMsg.Add("Below on duty percentage on " + holidayDay);
                        defaultTime.Error = true;
                    }
                }
            }
        }


        // Reset error flags
        private void ResetErrorFlags()
        {
            defaultTime.Error = false;

            foreach (TimePeriod period in periods)
                period.Error = false;
        }
    }
}
