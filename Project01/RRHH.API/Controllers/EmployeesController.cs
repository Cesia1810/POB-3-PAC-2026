
using Microsoft.AspNetCore.Mvc;
using RRHH.API.Dtos.Common;
using RRHH.API.Dtos.Employees;
using RRHH.API.Employees;
using RRHH.API.Entities;
using RRHH.API.Services.Employees;

namespace RRHH.API.Controllers
{
    [Route("api/employees")]//esta es la ruta que se usa
    [ApiController]//aqui demuestro que es un controlador de API
    public class EmployeesController(IEmployeeService employeeService) : ControllerBase
    {
        private readonly List<EmployeeEntity> _employees = new();
        private readonly IEmployeeService _employeService = employeeService;

        [HttpGet]
        public ActionResult<ResponseDto<PageDto<List<EmployeeDto>>>> GetAll(string searchTerm = "", int page = 1, int pageSize = 10)
        {
            var response =_employeService.GetPage();

            return StatusCode(response.StatusCode, new ResponseDto<PageDto<List<EmployeeDto>>>
            {
                Status = response.Status,
                Message = response.Message,
                Data = response.Data
            });
        }

        [HttpGet("{dni}")]//esto es para poner un parametro osea en la direcion especifica
        public async Task<ActionResult<ResponseDto<EmployeeOneDto>>> GetOne(Guid id)//esto para recorrer y buscar a uno en espesifico
        {
            var response = await _employeService.GetOneByIdAsync(id);

            //EmployeeEntity emp = new EmployeeEntity();
            //foreach (var employee in _employees)
            //{
            //    if(employee.DNI != null && employee.DNI.Equals(dni))
            //    {
            //        emp = employee;
            //    }
            //}

            //var emp = _employees.FirstOrDefault(e => e.DNI == dni);

            return StatusCode(response.StatusCode, new ResponseDto<EmployeeOneDto>
            {
                Status = response.Status,
                Message = response.Message,
                Data = response.Data
            });// se puede poner asi(_employees.FirstOrDefault(e => e.DNI == dni);) y no poner lo de arriba
        }

         [HttpPost]
        public async Task<ActionResult<ResponseDto<EmployeeActionResponseDto>>> Post([FromBody] EmployeeCreateDto dto)
        {
            var response = await _employeService.CreateAsync(dto);

            return StatusCode(response.StatusCode, new ResponseDto<EmployeeActionResponseDto>{
                Status = response.Status,
                Message = response.Message,
                Data = response.Data
                
        });
        }

        //put es completa un parche completo y PATCH es PARCIAL

        [HttpPut("{id}")]
        public ActionResult<ResponseDto<EmployeeActionResponseDto>> Put(Guid id, [FromBody] EmployeeEditDto dto)
        {
          var response = _employeService.Edit(id, dto);
           return StatusCode(response.StatusCode, new ResponseDto<EmployeeActionResponseDto>{
                Status = response.Status,
                Message = response.Message,
                Data = response.Data
        });
        }

        [HttpDelete("{dni}")]

        public IActionResult Delete(string dni)
        {
            var oldEmployee = _employees.FirstOrDefault(e => e.DNI == dni);

            if(oldEmployee != null)
            {
                _employees.Remove(oldEmployee);
            }

            return Ok(_employees);
        }

        
    }}