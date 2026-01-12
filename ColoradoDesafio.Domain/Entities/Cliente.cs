using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ColoradoDesafio.Domain.Entities
{
    public class Cliente
    {
        [Key]
        public int CodigoCliente { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(200)]
        public string Nome { get; set; }

        [StringLength(14)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O tipo pessoa é obrigatório")]
        [StringLength(20)]
        public string TipoPessoa { get; set; }

        [StringLength(200)]
        public string Documento { get; set; }

        public DateTime? Cadastro { get; set; }

        [StringLength(100)]
        public string Cidade { get; set; }

        [StringLength(200)]
        public string Endereco { get; set; }

        [StringLength(2)]
        public string Estado { get; set; }

        public DateTime DataInformacao { get; set; }

        public bool? Visualizado { get; set; }

        public virtual ICollection<Telefone> Telefones { get; set; }

        public Cliente()
        {
            Telefones = new List<Telefone>();
            DataInformacao = DateTime.Now;
        }
    }
}
