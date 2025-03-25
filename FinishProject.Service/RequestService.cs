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
    public class RequestService: IRequestService
    {
        private readonly IRequestRepository _requestRepository;

        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task AddRequestAsync(Request request)
        {
            // כאן ניתן להוסיף לוגיקה נוספת אם יש צורך
             await _requestRepository.AddRequestAsync(request);
        }

        public async Task DeleteRequestAsync(int id)
        {
            // כאן ניתן להוסיף לוגיקה נוספת אם יש צורך
            await _requestRepository.DeleteRequestAsync(id);
        }

        public async Task<IEnumerable<Request>> GetAllRequestsAsync()
        {
            return await _requestRepository.GetAllRequestsAsync();
        }

        public async Task<Request> GetRequestByIdAsync(int id)
        {
            return await _requestRepository.GetRequestByIdAsync(id);
        }

        public async Task UpdateRequestAsync(Request request)
        {
            // כאן ניתן להוסיף לוגיקה נוספת אם יש צורך
            await _requestRepository.UpdateRequestAsync(request);
        }

       
    }
}
