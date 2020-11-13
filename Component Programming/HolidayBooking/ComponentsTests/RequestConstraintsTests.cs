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
    public class RequestConstraintsTests
    {
        private RequestConstraints constraints = new RequestConstraints()
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
                    End = new DateTime(2020, 8, 10),
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
                    End = new DateTime(2020, 8, 10),
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
        public void CheckHolidayTest_01()
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

            testBooking.Error = constraints.CheckHoliday(testBooking);

            // Less that 60% working error
            Assert.IsNotNull(testBooking.Error);
        }


        [TestMethod()]
        public void CheckHolidayTest_02()
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

            testBooking.Error = constraints.CheckHoliday(testBooking);
            
            // Pass
            Assert.IsNull(testBooking.Error);
        }


        [TestMethod()]
        public void CheckHolidayTest_03()
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

            testBooking.Error = constraints.CheckHoliday(testBooking);
            
            // Less that 40% working
            Assert.IsNotNull(testBooking.Error);
        }


        [TestMethod()]
        public void CheckHolidayTest_04()
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

            testBooking.Error = constraints.CheckHoliday(testBooking);
            
            // No holidays can be booked error
            Assert.IsNotNull(testBooking.Error);
        }
        

        [TestMethod()]
        public void CheckHolidayTest_05()
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

            testBooking.Error = constraints.CheckHoliday(testBooking);
            
            // Head / Deputy off
            Assert.IsNotNull(testBooking.Error);
        }


        [TestMethod()]
        public void CheckHolidayTest_06()
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

            testBooking.Error = constraints.CheckHoliday(testBooking);
            
            // Head / Deputy off
            Assert.IsNotNull(testBooking.Error);
        }


        [TestMethod()]
        public void CheckHolidayTest_07()
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

            testBooking.Error = constraints.CheckHoliday(testBooking);
            
            // Senior / Manager off
            Assert.IsNotNull(testBooking.Error);
        }


        [TestMethod()]
        public void CheckHolidayTest_08()
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

            testBooking.Error = constraints.CheckHoliday(testBooking);
            
            // Senior / Manager off
            Assert.IsNotNull(testBooking.Error);
        }


        [TestMethod()]
        public void CheckHolidayTest_09()
        {
            Holidays testBooking = new Holidays
            {
                Staff = new Employee
                {
                    Username = "Harry Plopper",
                    RoleName = "Junior",
                    DepartmentName = "Magic",
                    JoinDate = new DateTime(2020, 1, 1),
                    Entitlement = 9,
                },
                Start = new DateTime(2020, 5, 1),
                End = new DateTime(2020, 5, 10),
            };

            testBooking.Error = constraints.CheckHoliday(testBooking);
            
            // Not enough entitlement remaining
            Assert.IsNotNull(testBooking.Error);
        }


        [TestMethod()]
        public void CheckHolidayTest_10()
        {
            Holidays testBooking = new Holidays
            {
                Staff = new Employee
                {
                    Username = "Harry Plopper",
                    RoleName = "Junior",
                    DepartmentName = "Magic",
                    JoinDate = new DateTime(2015, 1, 1),
                    Entitlement = 30,
                },
                Start = new DateTime(2020, 3, 1),
                End = new DateTime(2020, 3, 31),
            };

            testBooking.Error = constraints.CheckHoliday(testBooking);
            
            // Gain extra day on entitlement
            Assert.IsNull(testBooking.Error);
        }
    }
}