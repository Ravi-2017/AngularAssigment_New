using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp_Data.Model;
using WebApp_Dto;
using System.Linq;
namespace WebApp_Businiess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SampleDBContext _context;
        public EmployeeRepository(SampleDBContext context)
        {
            _context = context;
        }
        public async Task<List<EmpDto>> GetEmplyeeAsync()
        {
            var q = await (from emp in _context.Employee select new EmpDto { EmpAddress = emp.EmpAddress, EmpID = emp.EmpId, EmpName = emp.EmpName }).ToListAsync();
            return q;
        }
        public async Task<int> SaveEmployeeDataAsync(EmpDto empDto)
        {
            var emp = _context.Employee.Where(x => x.EmpId == empDto.EmpID).FirstOrDefault();
            if (emp != null)
            {
                emp.EmpAddress = empDto.EmpAddress;
                emp.EmpName = empDto.EmpName;
                _context.Employee.Update(emp);
                 await _context.SaveChangesAsync();
                return emp.EmpId;
            }
            else
            {
                Employee employee = new Employee();
                employee.EmpAddress = empDto.EmpAddress;
                employee.EmpName = empDto.EmpName;
                await _context.Employee.AddAsync(employee);
                await _context.SaveChangesAsync();
                return employee.EmpId;
            }
        }
        public async Task<EmpDto> GetEmplyeeDatabyId(int id)
        {
            var q = await (from emp in _context.Employee.Where(x=>x.EmpId==id) select new EmpDto { EmpAddress = emp.EmpAddress, EmpID = emp.EmpId, EmpName = emp.EmpName }).FirstOrDefaultAsync();
            return q;
        }
    }
    public interface IEmployeeRepository
    {
        Task<List<EmpDto>> GetEmplyeeAsync();
        Task<  EmpDto> GetEmplyeeDatabyId(int Id);
        Task< int> SaveEmployeeDataAsync(EmpDto empDto);
    }
}
