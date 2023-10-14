using Microsoft.AspNetCore.Mvc;
using acme_api.Models;
using acme_api.Repositories;

namespace acme_api.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class EmpleadoController : ControllerBase
{
    private readonly ILogger<EmpleadoController> _logger;
    private readonly EmpleadoRepository empleadoRepository;

    public EmpleadoController(ILogger<EmpleadoController> logger)
    {
        // aqui se crea el EmpleadoRepository
        _logger = logger;
        empleadoRepository = new EmpleadoRepository(); 
    }

    // Method get all employees
    [HttpGet(Name = "GetEmpleado")]
    public async Task<IEnumerable<Empleado>> Get()
    {
        return await empleadoRepository.Get();   
    }
    // method get employee by id
    [HttpGet("{id}", Name = "GetEmpleadoById")]
    public async Task<Empleado> Get(int id)
    {
        return await empleadoRepository.Get(id);   
    }
    // method post, add 1 employee

    [HttpPost(Name = "AddEmpleado")]
    public async Task<Empleado> Post(Empleado empleado){
        return await empleadoRepository.Create(empleado);
    }
    // method delete, delete from database 1 employee
    [HttpDelete("{id}",Name="DeleteEmpleado")]
    public async Task<string> Delete(int id){
        return await empleadoRepository.Delete(id);
    }

    // method patch, similar to Put but you can modify all columns or only the necessary columns

    [HttpPatch(Name="UpdateEmpleado")]
    public async Task<Empleado> Update(Empleado empleado){
        return await empleadoRepository.Update(empleado);
    }
}
