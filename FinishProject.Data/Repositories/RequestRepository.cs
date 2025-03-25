
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
    public class RequestRepository:IRequestRepository
    {
        private readonly DataContext _context;

        public RequestRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Request>AddRequestAsync(Request request)
        {
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }
        public async Task<IEnumerable<Request>> GetAllRequestsAsync()
        {
            return await _context.Requests.ToListAsync();
        }

        public async Task<Request> GetRequestByIdAsync(int id)
        {
            return await _context.Requests.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateRequestAsync(Request request)
        {
            _context.Requests.Update(request);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRequestAsync(int id)
        {
            var request = await GetRequestByIdAsync(id);
            if (request != null)
            {
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync();
            }
        }
    }
}
