using FinishProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishProject.Core.Repositories
{
    public interface IEmployeeRepository
    {
  
      
        Task<Employee> AddAsync(Employee employee);
        Task<Employee?> GetEmployeeAsync(int id);
        Task<List<Employee>> GetListAsync();
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
    }
}
