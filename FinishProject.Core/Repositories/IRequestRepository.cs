using FinishProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishProject.Core.Repositories
{
    public interface IRequestRepository
    {
        Task<Request> GetRequestByIdAsync(int id);
        Task<IEnumerable<Request>> GetAllRequestsAsync();
        Task<Request> AddRequestAsync(Request request);
        Task UpdateRequestAsync(Request request);
        Task DeleteRequestAsync(int id);
    }
}
