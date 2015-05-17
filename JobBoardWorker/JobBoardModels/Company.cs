using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public JobBoardType Type { get; set; }

        public virtual List<Job> Jobs { get; set; }
    }

    public enum JobBoardType
    {
        TheResumator,
        Stackoverflow
    }
}
