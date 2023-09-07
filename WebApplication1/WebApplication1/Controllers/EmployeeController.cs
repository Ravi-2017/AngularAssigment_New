using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Businiess;
using WebApp_Dto;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("Api/[Controller]")]
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
          
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        [Route("GetEmployeeData")]
        public async Task< IActionResult> GetEmployeeDataAsync()
        {
            var result = await _employeeRepository.GetEmplyeeAsync();
            return   Ok(result);
        }
        [HttpPost]
        [Route("SaveEmployeeData")]
        public async Task<IActionResult> SaveEmployeeDataAsync([FromBody] EmpDto empDto)
        {
            var result = await _employeeRepository.SaveEmployeeDataAsync(empDto);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetEmployeeDatabyId/{id}")]
        public async Task<IActionResult> GetEmployeeDatabyId(int id)
        {
            var result = await _employeeRepository.GetEmplyeeDatabyId(id);
            return Ok(result);
        }
       
    }
}
