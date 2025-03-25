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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Employee> AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<List<Employee>> GetListAsync()
        {
            return await _context.Employees.ToListAsync();
        }
        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await GetEmployeeAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
    
}
