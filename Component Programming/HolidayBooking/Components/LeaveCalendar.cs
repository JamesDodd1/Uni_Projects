using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    public partial class LeaveCalendar : MonthCalendar
    {
        public LeaveCalendar()
        {
            InitializeComponent();
        }


        public LeaveCalendar(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        public void BookHoliday(DateTime startDate, DateTime endDate)
        {
            int duration = Convert.ToInt32((endDate - startDate).TotalDays);

            for (int i = 0; i <= duration; i++)
            {
                this.AddBoldedDate(startDate.AddDays(i));
            }

            // Update calendar
            this.UpdateBoldedDates();
        }


        public void RemoveHoliday(DateTime startDate, DateTime endDate)
        {
            int duration = Convert.ToInt32((endDate - startDate).TotalDays);

            for (int i = 0; i <= duration; i++)
            {
                this.RemoveBoldedDate(startDate.AddDays(i));
            }

            // Update calendar
            this.UpdateBoldedDates();
        }


        public void Clear()
        {
            this.RemoveAllBoldedDates();

            this.UpdateBoldedDates();
        }
    }
}
