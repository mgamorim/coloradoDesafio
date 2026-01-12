using ColoradoDesafio.Api.DTOs;
using ColoradoDesafio.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColoradoDesafio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposTelefoneController : ControllerBase
    {
        private readonly ITipoTelefoneRepository _repository;

        public TiposTelefoneController(ITipoTelefoneRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoTelefoneDto>>> GetAll()
        {
            var tipos = await _repository.GetAllAsync();
            var tiposDto = tipos.Select(t => new TipoTelefoneDto
            {
                Id = t.Id,
                Descricao = t.Descricao,
                Ativo = t.Ativo
            }).ToList();

            return Ok(tiposDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoTelefoneDto>> GetById(int id)
        {
            var tipo = await _repository.GetByIdAsync(id);
            
            if (tipo == null)
            {
                return NotFound(new { message = "Tipo de telefone não encontrado" });
            }

            var tipoDto = new TipoTelefoneDto
            {
                Id = tipo.Id,
                Descricao = tipo.Descricao,
                Ativo = tipo.Ativo
            };

            return Ok(tipoDto);
        }
    }
}
