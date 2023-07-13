using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sesEntities
{
    public class Record
    {
        public string eventVersion { get; set; }
        public SES ses { get; set; }
        public string eventSource { get; set; }
    }
}
