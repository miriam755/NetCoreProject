using FinishProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishProject.Data.Repositories
{
    public class RepositoryManager:IRepositoryManger
    {
        private readonly DataContext _context;
        public IEmployeeRepository Employee { get; }

        public RepositoryManager(DataContext context,IEmployeeRepository employeeRepository)
                  {
            _context = context;
            Employee = employeeRepository;
        }

        public async Task  SaveAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}
