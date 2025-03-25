using FinishProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishProject.Core.DTOs
{
    public class TimeLogDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public Double Duration => EndTime.HasValue ? (EndTime.Value - StartTime.Value).TotalHours : 0;
        public DateOnly Date { get; set; }
      //  public Employee Employee { get; set; }
    }
}
