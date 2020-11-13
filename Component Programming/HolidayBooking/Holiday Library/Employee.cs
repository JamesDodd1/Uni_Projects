using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries
{
    /// <summary>
    /// New staff can be mapped
    /// </summary>
    public class Employee
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DoB { get; set; }
        public DateTime JoinDate { get; set; }
        public string PhoneNumber { get; set; }
        public string RoleName { get; set; }
        public string DepartmentName { get; set; }
        public bool Admin { get; set; }
        public bool Employed { get; set; }
        public bool Status { get; set; }

        public int Entitlement
        {
            get { return entitlement; }
            set
            {
                int bonus = Convert.ToInt32(Math.Floor(((DateTime.Now - JoinDate).TotalDays) / 365.25));
                entitlement = value + bonus;
            }
        }

        private int entitlement;
    }
}
