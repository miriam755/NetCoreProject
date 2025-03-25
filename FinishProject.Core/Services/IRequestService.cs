using FinishProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishProject.Core.Services
{
    public interface IRequestService
    {
        Task<Request> GetRequestByIdAsync(int id);
        Task<IEnumerable<Request>> GetAllRequestsAsync();
        Task AddRequestAsync(Request request);
        Task UpdateRequestAsync(Request request);
        Task DeleteRequestAsync(int id);
    }
}
