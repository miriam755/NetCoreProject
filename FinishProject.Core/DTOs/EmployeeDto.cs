using FinishProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishProject.Core.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Tz { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }   
        public List<Request> Requests { get; set; }
    }
}
