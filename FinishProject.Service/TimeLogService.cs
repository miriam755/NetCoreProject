using FinishProject.Core.Models;
using FinishProject.Core.Repositories;
using FinishProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishProject.Service
{
    public class TimeLogService:ITimeLogService
    {
       

        private readonly ITimeLogRepository _timeLogRepository;
     public TimeLogService(ITimeLogRepository timeLogRepository)
        {
            _timeLogRepository = timeLogRepository;
        }
       public async Task<TimeLog> AddAsync(TimeLog timeLog)
        {
            return await _timeLogRepository.AddAsync(timeLog);

        }
       public async Task<TimeLog?> GetTimeLogAsync(int id)
        {
            return await _timeLogRepository.GetTimeLogAsync(id);
        }
       public async Task<IEnumerable<TimeLog>> GetListAsync()
        {
            return await _timeLogRepository.GetListAsync();
        }
     public async   Task UpdateAsync(TimeLog timeLog)
        {
            await _timeLogRepository.UpdateAsync(timeLog);
        }
       public async Task DeleteAsync(int id)
        {
            await _timeLogRepository.DeleteAsync(id);
        }
    }
}
