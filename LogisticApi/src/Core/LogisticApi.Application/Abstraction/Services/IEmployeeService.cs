using LogisticApi.Application.DTOs.EmployeeDTOs;
using LogisticApi.Application.DTOs.OfficeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Abstraction.Services
{
    public interface IEmployeeService
    {
        Task<ICollection<EmployeeItemDto>> GetAllAsync(int page, int take, bool isdeleted);
        Task<EmployeeItemDto> GetAsync(int id, bool isdeleted);
        Task CreateAsync(EmployeeCreateDto employeeDto);
        Task UpdateAsync(EmployeeUpdateDto employeeDto, int id);
        Task SoftDeleteAsync(int id);
        Task ReverseDeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
