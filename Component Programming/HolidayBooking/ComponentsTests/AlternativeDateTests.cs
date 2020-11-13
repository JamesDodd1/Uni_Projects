using Microsoft.VisualStudio.TestTools.UnitTesting;
using Components;
using Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.Tests
{
    [TestClass()]
    public class AlternativeDateTests
    {
        private AlternativeDate altDates = new AlternativeDate()
        {
            Management = new List<string> { "Head", "Deputy" },
            SeniorStaff = new List<string> { "Senior", "Manager" },

            DefaultTime = new CapacityDates { Minimum = 60 },
            TimePeriods = new List<CapacityDates>
            {
                new CapacityDates
                {
                    Name = "August",
                    Minimum = 40,
                    Start = new DateTime(2020, 8, 1),
                    End = new DateTime(2020, 8, 31),
                },
                new CapacityDates
                {
                    Name = "New Year",
                    Minimum = 0,
                    Start = new DateTime(2020, 12, 1),
                    End = new DateTime(2020, 12, 31),
                },
            },

            RoleTotal = 5,
            DepartmentTotal = 5,

            AcceptedHolidays = new List<Holidays>
            {
                new Holidays
                {
                    Staff = new Employee
                    {
                        Username = "Albus Dumbledore",
                        RoleName = "Head",
                        DepartmentName = "Magic",
                    },
                    Start = new DateTime(2020, 8, 1),
                    End = new DateTime(2020, 8, 20),
                },
                new Holidays
                {
                    Staff = new Employee
                    {
                        Username = "Minerva McGonagall",
                        RoleName = "Deputy",
                        DepartmentName = "Magic",
                    },
                    Start = new DateTime(2020, 6, 1),
                    End = new DateTime(2020, 6, 10),
                },
                new Holidays
                {
                    Staff = new Employee
                    {
                        Username = "Severus Snape",
                        RoleName = "Manager",
                        DepartmentName = "Magic",
                    },
                    Start = new DateTime(2020, 8, 1),
                    End = new DateTime(2020, 8, 20),
                },
                new Holidays
                {
                    Staff = new Employee
                    {
                        Username = "Percy Weasley",
                        RoleName = "Senior",
                        DepartmentName = "Magic",
                    },
                    Start = new DateTime(2020, 6, 1),
                    End = new DateTime(2020, 6, 10),
                },
                new Holidays
                {
                    Staff = new Employee
                    {
                        Username = "Harry Potter",
                        RoleName = "Apprentice",
                        DepartmentName = "Magic",
                    },
                    Start = new DateTime(2020, 8, 1),
                    End = new DateTime(2020, 8, 10),
                },
            },
        };

        [TestMethod()]
        public void SuggestNewDateTest_1()
        {
            Holidays testBooking = new Holidays
            {
                Staff = new Employee
                {
                    Username = "Harry Plopper",
                    RoleName = "Junior",
                    DepartmentName = "Magic",
                    JoinDate = new DateTime(2020, 1, 1),
                    Entitlement = 30,
                },
                Start = new DateTime(2020, 6, 1),
                End = new DateTime(2020, 6, 10),
            };

            testBooking = altDates.SuggestNewDate(testBooking);

            // Finds another holiday period
            Assert.IsNotNull(testBooking);
        }


        [TestMethod()]
        public void SuggestNewDateTest_2()
        {
            Holidays testBooking = new Holidays
            {
                Staff = new Employee
                {
                    Username = "Harry Plopper",
                    RoleName = "Junior",
                    DepartmentName = "Magic",
                    JoinDate = new DateTime(2020, 1, 1),
                    Entitlement = 30,
                },
                Start = new DateTime(2020, 5, 1),
                End = new DateTime(2020, 5, 10),
            };

            testBooking = altDates.SuggestNewDate(testBooking);

            // Finds another holiday period
            Assert.IsNotNull(testBooking);
        }


        [TestMethod()]
        public void SuggestNewDateTest_3()
        {
            Holidays testBooking = new Holidays
            {
                Staff = new Employee
                {
                    Username = "Harry Plopper",
                    RoleName = "Junior",
                    DepartmentName = "Magic",
                    JoinDate = new DateTime(2020, 1, 1),
                    Entitlement = 30,
                },
                Start = new DateTime(2020, 8, 1),
                End = new DateTime(2020, 8, 10),
            };

            testBooking = altDates.SuggestNewDate(testBooking);

            // Cannot find another holiday period
            Assert.IsNull(testBooking);
        }


        [TestMethod()]
        public void SuggestNewDateTest_4()
        {
            Holidays testBooking = new Holidays
            {
                Staff = new Employee
                {
                    Username = "Harry Plopper",
                    RoleName = "Junior",
                    DepartmentName = "Magic",
                    JoinDate = new DateTime(2020, 1, 1),
                    Entitlement = 30,
                },
                Start = new DateTime(2020, 12, 1),
                End = new DateTime(2020, 12, 10),
            };

            testBooking = altDates.SuggestNewDate(testBooking);

            // Finds another holiday period
            Assert.IsNull(testBooking);
        }
        

        [TestMethod()]
        public void SuggestNewDateTest_5()
        {
            Holidays testBooking = new Holidays
            {
                Staff = new Employee
                {
                    Username = "Harry Plopper",
                    RoleName = "Head",
                    DepartmentName = "Magic",
                    JoinDate = new DateTime(2020, 1, 1),
                    Entitlement = 30,
                },
                Start = new DateTime(2020, 6, 1),
                End = new DateTime(2020, 6, 10),
            };

            testBooking = altDates.SuggestNewDate(testBooking);

            // Finds another holiday period
            Assert.IsNotNull(testBooking);
        }


        [TestMethod()]
        public void SuggestNewDateTest_6()
        {
            Holidays testBooking = new Holidays
            {
                Staff = new Employee
                {
                    Username = "Harry Plopper",
                    RoleName = "Head",
                    DepartmentName = "Magic",
                    JoinDate = new DateTime(2020, 1, 1),
                    Entitlement = 30,
                },
                Start = new DateTime(2020, 8, 1),
                End = new DateTime(2020, 8, 10),
            };

            testBooking = altDates.SuggestNewDate(testBooking);

            // Cannot find another holiday period
            Assert.IsNull(testBooking);
        }


        [TestMethod()]
        public void SuggestNewDateTest_7()
        {
            Holidays testBooking = new Holidays
            {
                Staff = new Employee
                {
                    Username = "Harry Plopper",
                    RoleName = "Senior",
                    DepartmentName = "Magic",
                    JoinDate = new DateTime(2020, 1, 1),
                    Entitlement = 30,
                },
                Start = new DateTime(2020, 8, 1),
                End = new DateTime(2020, 8, 10),
            };

            testBooking = altDates.SuggestNewDate(testBooking);

            // Cannot find another holiday period
            Assert.IsNull(testBooking);
        }


        [TestMethod()]
        public void SuggestNewDateTest_8()
        {
            Holidays testBooking = new Holidays
            {
                Staff = new Employee
                {
                    Username = "Harry Plopper",
                    RoleName = "Senior",
                    DepartmentName = "Magic",
                    JoinDate = new DateTime(2020, 1, 1),
                    Entitlement = 30,
                },
                Start = new DateTime(2020, 8, 1),
                End = new DateTime(2020, 8, 10),
            };

            testBooking = altDates.SuggestNewDate(testBooking);

            // Cannot find another holiday period
            Assert.IsNull(testBooking);
        }
    }
}