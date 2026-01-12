using System.ComponentModel.DataAnnotations;

namespace ColoradoDesafio.Domain.Entities
{
    public class TipoTelefone
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        public bool Ativo { get; set; } = true;
    }
}
