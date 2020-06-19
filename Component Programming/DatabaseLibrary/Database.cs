
using Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DatabaseLibrary
{
    public class Database
    {
        private HolidayDBDataContext db = new HolidayDBDataContext();


        // STAFF QUERIES

        public bool CheckLogin(string username, string password)
        {
            try
            {
                var login = from s in db.Staffs
                            where s.UserID == username && s.Password == password && s.Employed == true
                            select s;

                // If login sucessful
                if (login.Any())
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }
            
            return false;
        }


        public bool UsernameTaken(string username)
        {
            try
            {
                Staff staff = (from s in db.Staffs
                               where s.UserID == username
                               select s).FirstOrDefault();

                // If nothing found
                if (staff == null)
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return true;
        }


        public bool Register(string firstName, string lastName, string password, string username, DateTime dateOfBirth, string address, string phoneNum, string role, string department)
        {
            try
            { 
                int roleID = (from r in db.Roles
                              where (r.Name == role)
                              select r.RoleID).FirstOrDefault();

                int deptID = (from d in db.Departments
                              where (d.DepartmentName == department)
                              select d.DepartmentID).FirstOrDefault();

                int holidayID = (from e in db.Holidays
                                 select e.HolidayID).FirstOrDefault();


                // New staff row
                Staff staff = new Staff() {
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password,
                    UserID = username,
                    JoinDate = DateTime.Now,
                    DoB = dateOfBirth,
                    Address = address,
                    PhoneNumber = phoneNum,
                    RoleID = roleID,
                    DepartmentID = deptID,
                    HolidayID = holidayID,
                    Employed = true,
                };

                db.Staffs.InsertOnSubmit(staff);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: "+ e);
            }

            return false;
        }


        public bool AdminCheck(string username)
        {
            try
            {
                bool admin = (from s in db.Staffs where s.UserID == username select s.Admin).FirstOrDefault();

                return admin;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return false;
        }


        public bool PasswordReset(string username, string password)
        {
            try
            {
                Staff passReset = (from p in db.Staffs
                                   where p.UserID == username
                                   select p).FirstOrDefault();

                passReset.Password = password;

                db.SubmitChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return false;
        }


        public bool EditStaff(string username, string firstName, string lastName, string address, string phoneNum, bool employed, bool admin, string role, string department)
        {
            try
            { 
                Staff staff = (from s in db.Staffs
                               where s.UserID == username
                               select s).FirstOrDefault();

                int roleID = (from r in db.Roles
                              where r.Name == role
                              select r.RoleID).FirstOrDefault();

                int deptID = (from d in db.Departments
                              where d.DepartmentName == department
                              select d.DepartmentID).FirstOrDefault();

                
                staff.UserID = username;
                staff.FirstName = firstName;
                staff.LastName = lastName;
                staff.Address = address;
                staff.PhoneNumber = phoneNum;
                staff.RoleID = roleID;
                staff.DepartmentID = deptID;
                staff.Employed = employed;
                staff.Admin = admin;


                db.SubmitChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return false;
        }


        public bool DeleteStaff(string username)
        {
            try
            {
                Staff staff = (from d in db.Staffs
                               where d.UserID == username
                               select d).FirstOrDefault();

                staff.Employed = false;

                db.SubmitChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return false;
        }


        public List<Employee> GetAllStaff()
        {
            try
            {
                List<Employee> allStaff = (from s in db.Staffs
                                           join aw in db.Departments on
                                           new { A = s.DepartmentID } equals new { A = aw.DepartmentID }
                                           join ci in db.Roles on
                                           new { B = s.RoleID } equals new { B = ci.RoleID }
                                           join d in db.Holidays on
                                           new { C = s.HolidayID } equals new { C = d.HolidayID }
                                           where (s.DepartmentID == aw.DepartmentID) && (s.RoleID == ci.RoleID)
                                           select new Employee
                                           {
                                               Username = s.UserID,
                                               FirstName = s.FirstName,
                                               LastName = s.LastName,
                                               DepartmentName = aw.DepartmentName,
                                               RoleName = ci.Name,
                                               Employed = s.Employed,
                                               JoinDate = s.JoinDate,
                                               Entitlement = d.Entitlement,
                                           }).ToList();

                return allStaff;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return null;
        }


        public Employee GetStaff(string user)
        {
            try
            {
                Employee staff = (from s in db.Staffs
                                  join d in db.Departments on
                                  new { A = s.DepartmentID } equals new { A = d.DepartmentID }
                                  join r in db.Roles on
                                  new { B = s.RoleID } equals new { B = r.RoleID }
                                  join h in db.Holidays on
                                  new { C = s.HolidayID } equals new { C = h.HolidayID }
                                  where (s.DepartmentID == d.DepartmentID) && (s.RoleID == r.RoleID) && (s.UserID == user)
                                  select new Employee
                                  {
                                      Username = s.UserID,
                                      FirstName = s.FirstName,
                                      LastName = s.LastName,
                                      Address = s.Address,
                                      DoB = s.DoB,
                                      JoinDate = s.JoinDate,
                                      PhoneNumber = s.PhoneNumber,
                                      DepartmentName = d.DepartmentName,
                                      RoleName = r.Name,
                                      Employed = s.Employed,
                                      Admin = s.Admin,
                                      Entitlement = h.Entitlement,
                                  }).FirstOrDefault();

                return staff;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return null;
        }


        public List<Holidays> GetLeave(string username)
        {
            try
            {
                List<Holidays> leave = (from hc in db.HolidayChecks
                                        join s in db.Staffs on
                                        new { A = hc.StaffID } equals new { A = s.StaffID }
                                        where s.UserID == username && hc.Approved == true && hc.Cancel == false
                                        orderby s.UserID ascending, hc.StartDate ascending
                                        select new Holidays { Start = hc.StartDate, End = hc.EndDate }).ToList();

                return leave;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return null;
        }



        // JOB QUERIES

        public List<string> GetAllDepartments()
        {
            try
            {
                List<string> dept = (from d in db.Departments
                                     where d.DepartmentName == d.DepartmentName
                                     select d.DepartmentName).ToList();

                return dept;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return null;
        }


        public List<string> GetAllRoles()
        {
            try
            {
                List<string> role = (from r in db.Roles
                                     where r.Name == r.Name
                                     select r.Name).ToList();

                return role;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return null;
        }


        public List<string> GetManagement()
        {
            try
            {
                List<string> management = (from r in db.Roles
                                           where r.Name == "Head" || r.Name == "Deputy Head"
                                           select r.Name).ToList();

                return management;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return null;
        }


        public List<string> GetSeniors()
        {
            try
            {
                List<string> seniors = (from r in db.Roles
                                        where r.Name == "Manager" || r.Name == "Senior Member"
                                        select r.Name).ToList();

                return seniors;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return null;
        }


        public int GetTotalDepartmentNum(string department)
        {
            try
            {
                var staff = (from d in db.Departments
                             join s in db.Staffs on
                             new { A = d.DepartmentID } equals new { A = s.DepartmentID }
                             where d.DepartmentName == department && s.Employed == true
                             select s).ToList();

                return staff.Count();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return 0;
        }


        public int GetTotalRoleNum(string role, string department)
        {
            try
            {
                var staff = (from r in db.Roles
                             join s in db.Staffs on
                             new { A = r.RoleID } equals new { A = s.RoleID }
                             join d in db.Departments on
                             new { A = s.DepartmentID } equals new { A = d.DepartmentID }
                             where r.Name == role && d.DepartmentName == department && s.Employed == true
                             select s).ToList();

                return staff.Count();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return 0;
        }



        // HOLIDAY QUERIES

        public List<Holidays> GetAllHolidays()
        {
            try
            {
                List<Holidays> holidays = (from hc in db.HolidayChecks
                                           join s in db.Staffs on
                                           new { A = hc.StaffID } equals new { A = s.StaffID }
                                           join r in db.Roles on
                                           new { A = s.RoleID } equals new { A = r.RoleID }
                                           join d in db.Departments on
                                           new { A = s.DepartmentID } equals new { A = d.DepartmentID }
                                           join h in db.Holidays on
                                           new { A = s.HolidayID } equals new { A = h.HolidayID }
                                           orderby s.UserID ascending, hc.Approved descending, hc.Pending ascending, hc.Cancel ascending, hc.StartDate ascending
                                           select new Holidays
                                           {
                                               Staff = new Employee
                                               {
                                                   Username = s.UserID,
                                                   FirstName = s.FirstName,
                                                   LastName = s.LastName,
                                                   RoleName = r.Name,
                                                   DepartmentName = d.DepartmentName,
                                                   Entitlement = h.Entitlement,
                                               },
                                               Start = hc.StartDate,
                                               End = hc.EndDate,
                                               Pending = hc.Pending,
                                               Approved = hc.Approved,
                                               Canceled = hc.Cancel,
                                           }).ToList();

                return holidays;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return null;
        }


        public List<Holidays> GetAllOutstandingHolidays()
        {
            try
            {
                List<Holidays> holidays = (from hc in db.HolidayChecks
                                           join s in db.Staffs on
                                           new { A = hc.StaffID } equals new { A = s.StaffID }
                                           join r in db.Roles on
                                           new { A = s.RoleID } equals new { A = r.RoleID }
                                           join d in db.Departments on
                                           new { A = s.DepartmentID } equals new { A = d.DepartmentID }
                                           join h in db.Holidays on
                                           new { A = s.HolidayID } equals new { A = h.HolidayID }
                                           where hc.Pending == true && hc.Approved == false && hc.Cancel == false
                                           orderby s.StaffID ascending, hc.StartDate ascending
                                           select new Holidays
                                           {
                                               Staff = new Employee
                                               {
                                                   Username = s.UserID,
                                                   FirstName = s.FirstName,
                                                   LastName = s.LastName,
                                                   JoinDate = s.JoinDate,
                                                   RoleName = r.Name,
                                                   DepartmentName = d.DepartmentName,
                                                   Entitlement = h.Entitlement,
                                               },
                                               Start = hc.StartDate,
                                               End = hc.EndDate,
                                           }).ToList();

                return holidays;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return null;
        }


        public List<Holidays> GetOutstandingHolidays(string user)
        {
            try
            {
                List<Holidays> holidays = (from hc in db.HolidayChecks
                                           join s in db.Staffs on hc.StaffID equals s.StaffID
                                           join r in db.Roles on s.RoleID equals r.RoleID
                                           join d in db.Departments on s.DepartmentID equals d.DepartmentID
                                           join h in db.Holidays on s.HolidayID equals h.HolidayID
                                           where s.UserID == user
                                           orderby hc.StartDate descending
                                           select new Holidays
                                           {
                                               Start = hc.StartDate,
                                               End = hc.EndDate,
                                               Pending = hc.Pending,
                                               Approved = hc.Approved,
                                               Canceled = hc.Cancel,
                                           }).ToList();

                return holidays;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return null;
        }


        public List<Holidays> GetApprovedHolidays()
        {
            try
            {
                List<Holidays> holidays = (from hc in db.HolidayChecks
                                           join s in db.Staffs on
                                           new { A = hc.StaffID } equals new { A = s.StaffID }
                                           join r in db.Roles on
                                           new { A = s.RoleID } equals new { A = r.RoleID }
                                           join d in db.Departments on
                                           new { A = s.DepartmentID } equals new { A = d.DepartmentID }
                                           where hc.Approved == true && hc.Cancel == false
                                           orderby s.UserID ascending, hc.StartDate ascending
                                           select new Holidays
                                           {
                                               Staff = new Employee
                                               {
                                                   Username = s.UserID,
                                                   FirstName = s.FirstName,
                                                   LastName = s.LastName,
                                                   RoleName = r.Name,
                                                   DepartmentName = d.DepartmentName,
                                               },
                                               Start = hc.StartDate,
                                               End = hc.EndDate,
                                               Pending = hc.Pending,
                                               Approved = hc.Approved,
                                               Canceled = hc.Cancel,
                                           }).ToList();

                return holidays;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return null;
        }


        public List<Holidays> GetStaffStatus(DateTime date)
        {
            try
            {
                List<Holidays> onHoliday = (from s in db.Staffs
                                            join hc in db.HolidayChecks on
                                            s.StaffID equals hc.StaffID
                                            where hc.StartDate <= date && hc.EndDate >= date && hc.Approved == true
                                            orderby s.FirstName ascending, s.LastName ascending
                                            select new Holidays
                                            {
                                                Staff = new Employee
                                                {
                                                    Username = s.UserID,
                                                    FirstName = s.FirstName,
                                                    LastName = s.LastName,
                                                    Status = true,
                                                },
                                                Start = hc.StartDate,
                                                End = hc.EndDate,
                                            }).ToList();


                List<Holidays> working = (from s in db.Staffs
                                          orderby s.FirstName ascending, s.LastName ascending
                                          select new Holidays
                                          {
                                              Staff = new Employee
                                              {
                                                  Username = s.UserID,
                                                  FirstName = s.FirstName,
                                                  LastName = s.LastName,
                                                  Status = false,
                                              }
                                          }).ToList();


                // Combine the two lists
                List<Holidays> sorted = onHoliday;
                foreach (Holidays work in working)
                {
                    bool match = false;

                    foreach (Holidays holiday in onHoliday)
                    {
                        if (holiday.Staff.Username == work.Staff.Username)
                            match = true;
                    }

                    // Add only if not on holiday
                    if (!match)
                        sorted.Add(work);
                }

                return sorted;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return null;
        }


        public bool ApproveBooking(string username, DateTime startDate, DateTime endDate)
        {
            return UpdateBooking(username, startDate, endDate, true);
        }


        public bool RejectBooking(string username, DateTime startDate, DateTime endDate)
        {
            return UpdateBooking(username, startDate, endDate, false);
        }


        private bool UpdateBooking(string username, DateTime startDate, DateTime endDate, bool approve)
        {
            try
            { 
                // Get staff
                int staffID = (from s in db.Staffs
                               where s.UserID == username
                               select s.StaffID).FirstOrDefault();
            
                // Get holiday
                HolidayCheck holiday = (from hc in db.HolidayChecks
                                        where hc.StaffID == staffID && hc.StartDate == startDate && hc.EndDate == endDate
                                        select hc).FirstOrDefault();
            

                holiday.Pending = false;
                holiday.Approved = approve;

                db.SubmitChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return false;
        }


        public bool SubmitBooking(string username, DateTime startDate, DateTime endDate)
        {
            try
            { 
                int staffID = (from s in db.Staffs
                               where s.UserID == username
                               select s.StaffID).FirstOrDefault();

                HolidayCheck holiday = new HolidayCheck() 
                {
                    StaffID = staffID,
                    StartDate = startDate,
                    EndDate = endDate,
                    Pending = true,
                    Approved = false,
                    Cancel = false,
                };

                db.HolidayChecks.InsertOnSubmit(holiday);
                db.SubmitChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return false;
        }



        // CAPACITY QUERIES

        public CapacityDates DefaultOnDuty()
        {
            try
            {
                CapacityDates onDuty = (from c in db.Capacities
                                        where c.Name == "Default"
                                        select new CapacityDates { Minimum = c.Minimum }).FirstOrDefault();

                return onDuty;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return null;
        }


        public List<CapacityDates> GetPeriodTimes()
        {
            try
            {
                List<CapacityDates> dates = (from c in db.Capacities
                                             where c.Name != "Default" && c.Peak == false
                                             select new CapacityDates
                                             {
                                                 Name = c.Name,
                                                 Minimum = c.Minimum,
                                                 Start = c.StartDate,
                                                 End = c.EndDate,
                                                 Annual = c.EveryYear
                                             }).ToList();

                return dates;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return null;
        }


        public List<CapacityDates> GetPeakTimes()
        {
            try
            {
                List<CapacityDates> dates = (from c in db.Capacities
                                             where c.Name != "Default" && c.Peak == true
                                             select new CapacityDates
                                             {
                                                 Name = c.Name,
                                                 Minimum = c.Minimum,
                                                 Start = c.StartDate,
                                                 End = c.EndDate,
                                                 Annual = c.EveryYear
                                             }).ToList();

                return dates;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in " + MethodBase.GetCurrentMethod().Name + "function \nError Message: " + e);
            }

            return null;
        }
    }
}

