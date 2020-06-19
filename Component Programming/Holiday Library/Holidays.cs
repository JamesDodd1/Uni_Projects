using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries
{
    /// <summary>
    /// New Holidays can be mapped
    /// </summary>
    public class Holidays
    {
        public Employee Staff { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Pending { get; set; }
        public bool Approved { get; set; }
        public bool Canceled { get; set; }

        public int PeakTotal{ get; set; }

        public List<string> Error { get; set; }
    }
}
