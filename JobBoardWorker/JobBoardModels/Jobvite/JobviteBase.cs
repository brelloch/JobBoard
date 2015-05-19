using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class JobviteBase
    {
        public List<JobviteResult> results { get; set; }
        public string totalResults { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }
}
