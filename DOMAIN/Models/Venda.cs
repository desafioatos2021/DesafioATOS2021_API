using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Base.DOMAIN.Models 
{
    public class Venda 
    {
        public int IdVenda { get; set; }

        public string numeroPedido { get; set; }

        public int IdCliente { get; set; }

        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<ItemVenda> ItemVendas { get; set; }
    }
}
