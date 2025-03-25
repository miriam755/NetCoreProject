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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

  public async Task<Employee> AddAsync(Employee employee)
        {
            return await _employeeRepository.AddAsync(employee);
        }
        public async Task<IEnumerable<Employee>> GetListAsync()
        {
            return await _employeeRepository.GetListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await _employeeRepository.GetEmployeeAsync(id);
        }

        

        public async Task UpdateAsync(Employee employee)
        {
            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteAsync(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }
    }


}
