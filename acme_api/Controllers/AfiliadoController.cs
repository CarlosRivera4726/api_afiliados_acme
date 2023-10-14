using Microsoft.AspNetCore.Mvc;
using acme_api.Models;
using acme_api.Repositories;

namespace acme_api.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class AfiliadoController : ControllerBase
{
    private readonly ILogger<AfiliadoController> _logger;
    private readonly AfiliadoRepository afiliadoRepository;

    public AfiliadoController(ILogger<AfiliadoController> logger)
    {
        // aqui se crea el AfiliadoRepository
        _logger = logger;
        afiliadoRepository = new AfiliadoRepository(); 
    }

    // Method get all employees
    [HttpGet(Name = "GetAfiliado")]
    public async Task<IEnumerable<Afiliado>> Get()
    {
        try {
            _logger.LogInformation("[Status]: Trying to get all Afiliados from the database!");
            return await afiliadoRepository.Get();   
        } catch(Exception ex){
            _logger.LogError($"Error: {ex.Message}");
            return new Afiliado[1];
        }
    }
    // method get employee by id
    [HttpGet("{id}", Name = "GetAfiliadoById")]
    public async Task<Afiliado> Get(int id)
    {
        try {
            _logger.LogWarning("[Status]: Trying to get the Afiliado from the database!");
            var afiliado = await afiliadoRepository.Get(id);
            _logger.LogInformation("[Status]: Afiliado obtained");
            return afiliado;   
        } catch(Exception ex){
            _logger.LogError($"Error: {ex.Message}");
            return new Afiliado{};
        }  
    }
    // method post, add 1 employee

    [HttpPost(Name = "AddAfiliado")]
    public async Task<Afiliado> Post(Afiliado afiliado){
        return await afiliadoRepository.Create(afiliado);
    }
    // method delete, delete from database 1 employee
    [HttpDelete("{id}", Name="DeleteAfiliado")]
    public async Task<string> Delete(int id){
        return await afiliadoRepository.Delete(id);
    }

    // method patch, similar to Put but you can modify all columns or only the necessary columns

    [HttpPatch(Name="UpdateAfiliado")]
    public async Task<Afiliado> Update(Afiliado afiliado){
        return await afiliadoRepository.Update(afiliado);
    }
}
