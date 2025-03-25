using FinishProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishProject.Core.Models
{
    public class TimeLog
    {
        public int Id { get; set; }
       public int EmployeeId { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public DateOnly Date { get; set; }
        public  Employee Employee { get; set;}

    }
}


