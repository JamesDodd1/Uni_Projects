using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries
{
    /// <summary>
    /// New time periods can be mapped
    /// </summary>
    public class CapacityDates
    {
        public string Name { get; set; }
        public int Minimum { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Annual { get; set; }
        public bool Peak { get; set; }
    }
}
