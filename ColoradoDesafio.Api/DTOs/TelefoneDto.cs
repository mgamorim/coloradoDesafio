namespace ColoradoDesafio.Api.DTOs
{
    public class TelefoneDto
    {
        public int NumeroTelefone { get; set; }
        public int CodigoCliente { get; set; }
        public string TipoTelefone { get; set; }
        public string Numero { get; set; }
        public string DDD { get; set; }
        public int? DDI { get; set; }
        public string Observacao { get; set; }
        public bool? Ativo { get; set; }
        public string Descricao { get; set; }
    }
}
