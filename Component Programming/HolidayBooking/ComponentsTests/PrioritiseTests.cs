using Microsoft.VisualStudio.TestTools.UnitTesting;
using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraries;

namespace Components.Tests
{
    [TestClass()]
    public class PrioritiseTests
    {
        private Prioritise prioritise = new Prioritise()
        {
            PeakTimes = new List<CapacityDates>
            {
                new CapacityDates { Start = new DateTime(2020, 6, 1), End = new DateTime(2020, 6, 30) },
                new CapacityDates { Start = new DateTime(2020, 10, 1), End = new DateTime(2020, 10, 31) },
            },
            ApprovedHolidays = new List<Holidays>
            {
                new Holidays
                {
                    Staff = new Employee { Username = "Iron Man" },
                    Start = new DateTime(2020, 6, 1),
                    End = new DateTime(2020, 6, 10),
                },
                new Holidays
                {
                    Staff = new Employee { Username = "Iron Man" },
                    Start = new DateTime(2020, 1, 1),
                    End = new DateTime(2020, 1, 10),
                },
                new Holidays
                {
                    Staff = new Employee { Username = "Captain America" },
                    Start = new DateTime(2020, 6, 1),
                    End = new DateTime(2020, 6, 10),
                },
                new Holidays
                {
                    Staff = new Employee { Username = "Spiderman" },
                    Start = new DateTime(2020, 5, 1),
                    End = new DateTime(2020, 5, 10),
                },
                new Holidays
                {
                    Staff = new Employee { Username = "Spiderman" },
                    Start = new DateTime(2020, 10, 1),
                    End = new DateTime(2020, 10, 20),
                },
                new Holidays
                {
                    Staff = new Employee { Username = "Hulk" },
                    Start = new DateTime(2020, 3, 1),
                    End = new DateTime(2020, 3, 5),
                },
                new Holidays
                {
                    Staff = new Employee { Username = "Hulk" },
                    Start = new DateTime(2020, 2, 1),
                    End = new DateTime(2020, 2, 5),
                },
            }
        };


        private bool CheckList(List<Holidays> expected, List<Holidays> results)
        {
            bool pass = false;
            for (int i = 0; i < results.Count(); i++)
            {
                if (expected[i].Staff.Username == results[i].Staff.Username &&
                    expected[i].Start == results[i].Start &&
                    expected[i].End == results[i].End)
                    pass = true;
                else
                {
                    pass = false;
                    break;
                }
            }

            return pass;
        }


        /// <summary>
        /// Orders request from staff with accepted holidays and check peak time ordering works
        /// </summary>
        [TestMethod()]
        public void PrioritiseHolidaysTest_1()
        {
            List<Holidays> bookings = new List<Holidays>
            {
                new Holidays
                {
                    Staff = new Employee { Username = "Iron Man" },
                    Start = new DateTime(2020, 10, 1),
                    End = new DateTime(2020, 10, 10),
                },
                new Holidays
                {
                    Staff = new Employee { Username = "Iron Man" },
                    Start = new DateTime(2020, 10, 1),
                    End = new DateTime(2020, 10, 5),
                },
                new Holidays
                {
                    Staff = new Employee { Username = "Hulk" },
                    Start = new DateTime(2020, 10, 1),
                    End = new DateTime(2020, 10, 10),
                },
            };


            List<Holidays> expectResults = new List<Holidays>
            {
                new Holidays
                {
                    Staff = new Employee { Username = "Hulk" },
                    Start = new DateTime(2020, 10, 1),
                    End = new DateTime(2020, 10, 10),
                },
                new Holidays
                {
                    Staff = new Employee { Username = "Iron Man" },
                    Start = new DateTime(2020, 10, 1),
                    End = new DateTime(2020, 10, 5),
                },
                new Holidays
                {
                    Staff = new Employee { Username = "Iron Man" },
                    Start = new DateTime(2020, 10, 1),
                    End = new DateTime(2020, 10, 10),
                },
            };


            List<Holidays> results = prioritise.PrioritiseHolidays(bookings);


            Assert.IsTrue(CheckList(expectResults, results));
        }


        /// <summary>
        /// Orders requests from staff, include one with no accepted holiday
        /// </summary>
        [TestMethod()]
        public void PrioritiseHolidaysTest_2()
        {
            List<Holidays> bookings = new List<Holidays>
            {
                new Holidays
                {
                    Staff = new Employee { Username = "Iron Man" },
                    Start = new DateTime(2020, 10, 1),
                    End = new DateTime(2020, 10, 10),
                },
                new Holidays
                {
                    Staff = new Employee { Username = "Black Widow" },
                    Start = new DateTime(2020, 10, 1),
                    End = new DateTime(2020, 10, 5),
                },
                new Holidays
                {
                    Staff = new Employee { Username = "Hulk" },
                    Start = new DateTime(2020, 10, 1),
                    End = new DateTime(2020, 10, 10),
                },
            };


            List<Holidays> expectResults = new List<Holidays>
            {
                new Holidays
                {
                    Staff = new Employee { Username = "Black Widow" },
                    Start = new DateTime(2020, 10, 1),
                    End = new DateTime(2020, 10, 5),
                },
                new Holidays
                {
                    Staff = new Employee { Username = "Hulk" },
                    Start = new DateTime(2020, 10, 1),
                    End = new DateTime(2020, 10, 10),
                },
                new Holidays
                {
                    Staff = new Employee { Username = "Iron Man" },
                    Start = new DateTime(2020, 10, 1),
                    End = new DateTime(2020, 10, 10),
                },
            };


            List<Holidays> results = prioritise.PrioritiseHolidays(bookings);


            Assert.IsTrue(CheckList(expectResults, results));
        }


        /// <summary>
        /// Orders requests from staff, include one with no accepted holiday
        /// </summary>
        [TestMethod()]
        public void PrioritiseHolidaysTest_3()
        {
            List<Holidays> bookings = new List<Holidays>
            {
                new Holidays
                {
                    Staff = new Employee { Username = "Captain America" },
                    Start = new DateTime(2020, 10, 1),
                    End = new DateTime(2020, 10, 10),
                },
                new Holidays
                {
                    Staff = new Employee { Username = "Hulk" },
                    Start = new DateTime(2020, 9, 30),
                    End = new DateTime(2020, 10, 9),
                },
            };


            List<Holidays> expectResults = new List<Holidays>
            {
                new Holidays
                {
                    Staff = new Employee { Username = "Hulk" },
                    Start = new DateTime(2020, 9, 30),
                    End = new DateTime(2020, 10, 9),
                },
                new Holidays
                {
                    Staff = new Employee { Username = "Captain America" },
                    Start = new DateTime(2020, 10, 1),
                    End = new DateTime(2020, 10, 10),
                },
            };


            List<Holidays> results = prioritise.PrioritiseHolidays(bookings);


            Assert.IsTrue(CheckList(expectResults, results));
        }
    }
}