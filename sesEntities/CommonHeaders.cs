using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sesEntities
{
    public class CommonHeaders
    {
        public string returnPath { get; set; }
        public List<string> from { get; set; }
        public string date { get; set; }
        public List<string> to { get; set; }
        public string messageId { get; set; }
        public string subject { get; set; }
    }
}
