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
    public partial class AlternativeDate : RequestConstraints
    {
        public AlternativeDate()
        {
            InitializeComponent();
        }


        public AlternativeDate(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        public Holidays SuggestNewDate(Holidays holiday)
        {
            // Check next two weeks
            for (int i = 1; i <= 14; i++)
            {
                // Add day to start and end
                holiday.Start = holiday.Start.AddDays(1);
                holiday.End = holiday.End.AddDays(1);

                // If holiday returns no errors
                if (CheckHoliday(holiday) == null)
                    return holiday;
            }

            // Failed to find new holiday times
            return null;
        }
    }
}
