using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ColoradoDesafio.Web.Models
{
    public class ClienteViewModel
    {
        public int CodigoCliente { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [StringLength(14)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O tipo pessoa é obrigatório")]
        [Display(Name = "Tipo Pessoa")]
        public string TipoPessoa { get; set; }

        [Display(Name = "Documento")]
        public string Documento { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.Date)]
        public DateTime? Cadastro { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Estado")]
        [StringLength(2)]
        public string Estado { get; set; }

        [Display(Name = "Data de Informação")]
        public DateTime DataInformacao { get; set; }

        [Display(Name = "Visualizado")]
        public bool? Visualizado { get; set; }

        public List<TelefoneViewModel> Telefones { get; set; }

        public ClienteViewModel()
        {
            Telefones = new List<TelefoneViewModel>();
        }
    }
}
