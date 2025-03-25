using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishProject.Core.Repositories
{
    public interface IRepositoryManger
    {
        IEmployeeRepository Employee { get; }

        Task SaveAsync();
    }
}
