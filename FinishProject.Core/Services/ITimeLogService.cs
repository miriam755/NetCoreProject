using FinishProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishProject.Core.Services
{
    public interface ITimeLogService
    {
        Task<TimeLog> AddAsync(TimeLog timeLog);
        Task<TimeLog?> GetTimeLogAsync(int id);
        Task<IEnumerable<TimeLog>> GetListAsync();
        Task UpdateAsync(TimeLog timeLog);
        Task DeleteAsync(int id);
    }
}
