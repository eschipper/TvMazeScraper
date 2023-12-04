using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ShowCast
    {
        public string id { get; set; }
        public string Name { get; set;  }
        public Cast[] Cast { get; set; }
    }
}
