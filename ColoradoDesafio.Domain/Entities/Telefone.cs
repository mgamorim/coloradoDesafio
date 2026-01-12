using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColoradoDesafio.Domain.Entities
{
    public class Telefone
    {
        [Key]
        public int NumeroTelefone { get; set; }

        [Required(ErrorMessage = "O código do cliente é obrigatório")]
        public int CodigoCliente { get; set; }

        [Required(ErrorMessage = "O tipo telefone é obrigatório")]
        [StringLength(50)]
        public string TipoTelefone { get; set; }

        [Required(ErrorMessage = "O número é obrigatório")]
        [StringLength(20)]
        public string Numero { get; set; }

        [StringLength(10)]
        public string DDD { get; set; }

        public int? DDI { get; set; }

        [StringLength(200)]
        public string Observacao { get; set; }

        public bool? Ativo { get; set; }

        [StringLength(200)]
        public string Descricao { get; set; }

        [ForeignKey("CodigoCliente")]
        public virtual Cliente Cliente { get; set; }
    }
}
