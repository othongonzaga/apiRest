using AP.Domain;
using AR.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AR.Apresentacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repository;

        public ClienteController(IClienteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente cliente)
        {
            try
            {
                await _repository.Post(cliente);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                await _repository.RemoveAtt(Cliente.IndexOf(Cliente.First(x => x.Equals(Id))));
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}