using System.ComponentModel.DataAnnotations;

namespace ColoradoDesafio.Web.Models
{
    public class TelefoneViewModel
    {
        public int NumeroTelefone { get; set; }

        public int CodigoCliente { get; set; }

        [Required(ErrorMessage = "O tipo telefone é obrigatório")]
        [Display(Name = "Tipo")]
        public string TipoTelefone { get; set; }

        [Required(ErrorMessage = "O número é obrigatório")]
        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Display(Name = "DDD")]
        public string DDD { get; set; }

        [Display(Name = "DDI")]
        public int? DDI { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        [Display(Name = "Ativo")]
        public bool? Ativo { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}
