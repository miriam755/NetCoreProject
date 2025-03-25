using FinishProject.Core.Models;
using FinishProject.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishProject.Data.Repositories
{
    public class TimeLogRepository:ITimeLogRepository
    {
        private readonly DataContext _context;

        public TimeLogRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<TimeLog> AddAsync(TimeLog timeLog)
        {await _context.TimeLogs.AddAsync(timeLog);
            await _context.SaveChangesAsync();
            return timeLog;
        }
       public  async Task<TimeLog?> GetTimeLogAsync(int id)
        {
            return await _context.TimeLogs.FirstOrDefaultAsync(t => t.Id == id);
        }


        public async Task<IEnumerable<TimeLog>> GetListAsync()
        {
       return await _context.TimeLogs.ToListAsync();
        }
        public async Task UpdateAsync(TimeLog timeLog)
        {
            _context.TimeLogs.Update(timeLog);
            await _context.SaveChangesAsync();
        }
       
             public async Task DeleteAsync(int id)
        {
            var timeLog = await GetTimeLogAsync(id);
            if (timeLog != null)
            {
                _context.TimeLogs.Remove(timeLog);
                await _context.SaveChangesAsync();
            }
        }
    }
}

