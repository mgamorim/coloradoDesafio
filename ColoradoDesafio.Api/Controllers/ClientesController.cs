using ColoradoDesafio.Api.DTOs;
using ColoradoDesafio.Domain.Entities;
using ColoradoDesafio.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColoradoDesafio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetAll()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            var clientesDto = clientes.Select(MapToDto).ToList();
            return Ok(clientesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> GetById(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            
            if (cliente == null)
            {
                return NotFound(new { message = "Cliente não encontrado" });
            }

            return Ok(MapToDto(cliente));
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDto>> Create([FromBody] ClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cliente = MapToEntity(clienteDto);
            var createdCliente = await _clienteRepository.CreateAsync(cliente);
            var resultDto = MapToDto(createdCliente);

            return CreatedAtAction(nameof(GetById), new { id = resultDto.CodigoCliente }, resultDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteDto>> Update(int id, [FromBody] ClienteDto clienteDto)
        {
            if (id != clienteDto.CodigoCliente)
            {
                return BadRequest(new { message = "ID do cliente não corresponde" });
            }

            if (!await _clienteRepository.ExistsAsync(id))
            {
                return NotFound(new { message = "Cliente não encontrado" });
            }

            var cliente = MapToEntity(clienteDto);
            var updatedCliente = await _clienteRepository.UpdateAsync(cliente);
            return Ok(MapToDto(updatedCliente));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!await _clienteRepository.ExistsAsync(id))
            {
                return NotFound(new { message = "Cliente não encontrado" });
            }

            var result = await _clienteRepository.DeleteAsync(id);
            if (result)
            {
                return NoContent();
            }

            return BadRequest(new { message = "Erro ao deletar cliente" });
        }

        private ClienteDto MapToDto(Cliente cliente)
        {
            return new ClienteDto
            {
                CodigoCliente = cliente.CodigoCliente,
                Nome = cliente.Nome,
                CPF = cliente.CPF,
                TipoPessoa = cliente.TipoPessoa,
                Documento = cliente.Documento,
                Cadastro = cliente.Cadastro,
                Cidade = cliente.Cidade,
                Endereco = cliente.Endereco,
                Estado = cliente.Estado,
                DataInformacao = cliente.DataInformacao,
                Visualizado = cliente.Visualizado,
                Telefones = cliente.Telefones?.Select(t => new TelefoneDto
                {
                    NumeroTelefone = t.NumeroTelefone,
                    CodigoCliente = t.CodigoCliente,
                    TipoTelefone = t.TipoTelefone,
                    Numero = t.Numero,
                    DDD = t.DDD,
                    DDI = t.DDI,
                    Observacao = t.Observacao,
                    Ativo = t.Ativo,
                    Descricao = t.Descricao
                }).ToList() ?? new List<TelefoneDto>()
            };
        }

        private Cliente MapToEntity(ClienteDto dto)
        {
            return new Cliente
            {
                CodigoCliente = dto.CodigoCliente,
                Nome = dto.Nome,
                CPF = dto.CPF,
                TipoPessoa = dto.TipoPessoa,
                Documento = dto.Documento,
                Cadastro = dto.Cadastro,
                Cidade = dto.Cidade,
                Endereco = dto.Endereco,
                Estado = dto.Estado,
                Visualizado = dto.Visualizado,
                Telefones = dto.Telefones?.Select(t => new Telefone
                {
                    NumeroTelefone = t.NumeroTelefone,
                    CodigoCliente = t.CodigoCliente,
                    TipoTelefone = t.TipoTelefone,
                    Numero = t.Numero,
                    DDD = t.DDD,
                    DDI = t.DDI,
                    Observacao = t.Observacao,
                    Ativo = t.Ativo,
                    Descricao = t.Descricao
                }).ToList() ?? new List<Telefone>()
            };
        }
    }
}
