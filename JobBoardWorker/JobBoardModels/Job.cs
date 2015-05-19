using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Location { get; set; }
        public string CompanyName { get; set; }

        public virtual Company Company { get; set; }
    }
}
