using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishProject.Core.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Tz { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string Password { get; set; }
        public  List<TimeLog>TimeLogs { get; set; }= new List<TimeLog>();
        public List<Request>Requests { get; set; }=new List<Request>();
    }
}
