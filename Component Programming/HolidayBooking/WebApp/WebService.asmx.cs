using DatabaseLibrary;
using Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApp
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        private Database db = new Database();

        [WebMethod]
        public bool CheckLogin(string username, string password)
        {
            return db.CheckLogin(username, password);
        }


        [WebMethod]
        public Employee GetStaff(string user)
        {
            return db.GetStaff(user);
        }


        [WebMethod]
        public List<string> GetManagement()
        {
            return db.GetManagement();
        }


        [WebMethod]
        public List<string> GetSeniors()
        {
            return db.GetSeniors();
        }


        [WebMethod]
        public int GetTotalRoleNum(string role, string department)
        {
            return db.GetTotalRoleNum(role, department);
        }


        [WebMethod]
        public int GetTotalDepartmentNum(string department)
        {
            return db.GetTotalDepartmentNum(department);
        }


        [WebMethod]
        public List<Holidays> GetApprovedHolidays()
        {
            return db.GetApprovedHolidays();
        }


        [WebMethod]
        public List<Holidays> GetOutstandingHolidays(string user)
        {
            return db.GetOutstandingHolidays(user);
        }


        [WebMethod]
        public bool SubmitBooking(string username, DateTime startDate, DateTime endDate)
        {
            return db.SubmitBooking(username, startDate, endDate);
        }


        [WebMethod]
        public CapacityDates DefaultOnDuty()
        {
            return db.DefaultOnDuty();
        }


        [WebMethod]
        public List<CapacityDates> GetPeriodTimes()
        {
            return db.GetPeriodTimes();
        }
    }
}
