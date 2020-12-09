using System.ComponentModel.DataAnnotations;

namespace Stock.Models
{
    public class Stock
    {   
        [Key]
        public int Id { get; set; }
        [Required]
        public string SKU { get; set; }
        public string Descricao { get; set; }
        [Required]
        public int Quantidade { get; set; }
        public int Caixa_Altura { get; set; }
        public int Caixa_Largura { get; set; }
        public int Caixa_Comprimento { get; set; }
        public string Localizacao { get; set; }
        public int Custo { get; set; }
        public string Fornecedor { get; set; }
    }
}