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
    public partial class Prioritise : Component
    {
        public Prioritise()
        {
            InitializeComponent();
        }


        public Prioritise(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        private class StaffHoliday
        {
            public List<Holidays> Holidays { get; set; }
            public int HolidayTotal { get; set; }
        }


        // Declare variables
        private List<StaffHoliday> staffHolidays;
        private StaffHoliday timeOff = new StaffHoliday { Holidays = new List<Holidays>() };

        private static List<CapacityDates> peakTimes;



        // Getters and setters
        public List<CapacityDates> PeakTimes
        {
            set { peakTimes = value; }
        }

        public List<Holidays> ApprovedHolidays { get; set; }


        /// <summary> 
        /// Prioritise a list of holiday requests.  First by the total number of days already taken assendingly. 
        /// Second by the number of days during peak times the request has
        /// </summary>
        /// <return>
        /// The sorted holiday requests list is returned
        /// </return>
        public List<Holidays> PrioritiseHolidays(List<Holidays> holidays)
        {
            staffHolidays = new List<StaffHoliday>();

            // Sort functions
            SortByPeakTimes(holidays);
            SortByTotalHolidays();
            return SortByEqualHolidays();
        }


        /// <summary>
        /// Count number of days requested in during peak times, then sort list assendingly
        /// </summary>
        private void SortByPeakTimes(List<Holidays> holidays)
        {
            foreach (Holidays booking in holidays)
            {
                // If timeOff holidays contain anything (not first iteration) and is a different staff
                if (timeOff.Holidays.Any() && booking.Staff.Username != timeOff.Holidays[0].Staff.Username)
                {
                    // Order all staff's bookings by each booking's total peak days
                    timeOff.Holidays = timeOff.Holidays.OrderBy(h => h.PeakTotal).ToList();
                    staffHolidays.Add(timeOff);

                    timeOff = new StaffHoliday { Holidays = new List<Holidays>() };
                }


                int duration = Convert.ToInt32(1 + (booking.End - booking.Start).TotalDays);

                // Count the number days during a peak time
                for (int i = 0; i < duration; i++)
                {
                    DateTime day = booking.Start.AddDays(i);

                    foreach (CapacityDates peak in peakTimes)
                    {
                        if (day >= peak.Start && day <= peak.End)
                        {
                            booking.PeakTotal++;
                            break;
                        }
                    }
                }

                timeOff.Holidays.Add(booking);
            }


            // Order final iteration staff's bookings by each booking's total peak days
            timeOff.Holidays = timeOff.Holidays.OrderBy(h => h.PeakTotal).ToList();
            staffHolidays.Add(timeOff);
        }


        /// <summary>
        /// Counts the total number of holidays that have been accepted, then sorts assendingly
        /// </summary>
        private void SortByTotalHolidays()
        {
            foreach (StaffHoliday staff in staffHolidays)
            {
                foreach (Holidays approved in ApprovedHolidays)
                {
                    // If not staff's approved holidays
                    if (staff.Holidays.Any() && staff.Holidays[0].Staff.Username == approved.Staff.Username)
                        staff.HolidayTotal += Convert.ToInt32(1 + (approved.End - approved.Start).TotalDays);
                }
            }

            // Order list by total holiday days assendingly
            staffHolidays = staffHolidays.OrderBy(sh => sh.HolidayTotal).ToList();
        }


        /// <summary>
        /// Sort holiday requests where the same number of total day are booked, 
        /// by the number of requested days during peak times assendingly
        /// </summary>
        private List<Holidays> SortByEqualHolidays()
        {
            List<Holidays> holidayList = new List<Holidays>();
            List<Holidays> temp = new List<Holidays>();
            
            // Loop through staff holidays
            for (int i = 1; i < staffHolidays.Count(); i++)
            {
                // If current total days booked is the same as the previous iteration
                if (staffHolidays[i].HolidayTotal == staffHolidays[i - 1].HolidayTotal)
                {
                    temp = temp.Concat(staffHolidays[i - 1].Holidays).ToList();

                    // If last iteration
                    if (i == (staffHolidays.Count() - 1))
                    {
                        temp = temp.Concat(staffHolidays[i].Holidays).ToList();
                        holidayList = holidayList.Concat(BubbleSortHoliday(temp)).ToList();

                        break;
                    }

                    continue;
                }

                // If list constaints anything then sort
                if (temp.Any())
                {
                    temp = temp.Concat(staffHolidays[i - 1].Holidays).ToList();
                    holidayList = holidayList.Concat(BubbleSortHoliday(temp)).ToList();
                    temp.Clear();
                }
                else
                    holidayList = holidayList.Concat(staffHolidays[i - 1].Holidays).ToList();


                // Add if last iteration
                if (i == (staffHolidays.Count() - 1))
                    holidayList = holidayList.Concat(staffHolidays[i].Holidays).ToList();
            }

            return holidayList;
        }


        /// <summary>
        /// Bubble sort holidays
        /// </summary>
        private List<Holidays> BubbleSortHoliday(List<Holidays> holidays)
        {
            Holidays temp = new Holidays();

            for (int j = 0; j < (holidays.Count() - 1); j++)
            {
                for (int i = 0; i < (holidays.Count() - 1); i++)
                {
                    // If less or same peak bookings
                    if (holidays[i].PeakTotal <= holidays[i + 1].PeakTotal)
                        continue;

                    temp = holidays[i + 1];
                    holidays[i + 1] = holidays[i];
                    holidays[i] = temp;
                }
            }

            return holidays;
        }
    }
}
