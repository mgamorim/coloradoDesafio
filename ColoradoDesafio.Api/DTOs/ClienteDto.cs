using System;
using System.Collections.Generic;

namespace ColoradoDesafio.Api.DTOs
{
    public class ClienteDto
    {
        public int CodigoCliente { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string TipoPessoa { get; set; }
        public string Documento { get; set; }
        public DateTime? Cadastro { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }
        public string Estado { get; set; }
        public DateTime DataInformacao { get; set; }
        public bool? Visualizado { get; set; }
        public List<TelefoneDto> Telefones { get; set; }

        public ClienteDto()
        {
            Telefones = new List<TelefoneDto>();
        }
    }
}
