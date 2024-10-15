using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Implementations.Services
{
    public class EmployeeService : IEmployeeService
    {
        public Task CreateAsync(EmployeeCreateDto employeeDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<EmployeeItemDto>> GetAllAsync(int page, int take, bool isdeleted)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeItemDto> GetAsync(int id, bool isdeleted)
        {
            throw new NotImplementedException();
        }

        public Task ReverseDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(EmployeeUpdateDto employeeDto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
