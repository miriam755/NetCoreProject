using FinishProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishProject.Core.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetListAsync();
        Task<Employee> GetEmployeeAsync(int id);
        Task<Employee> AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
    }
}
