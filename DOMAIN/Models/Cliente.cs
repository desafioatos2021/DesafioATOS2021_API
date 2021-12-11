using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Base.DOMAIN.Models
{
     public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} esta em formato inválido")]
        public string Nome { get; set; }

        public int IdEndereco { get; set; }

        [JsonIgnore]
        public virtual ICollection<Venda> Vendas { get; set; }
    }
}
