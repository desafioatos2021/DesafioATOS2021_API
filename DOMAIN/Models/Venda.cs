using System.Collections.Generic;


namespace Base.DOMAIN.Models
{
    public class Venda
    {
        
        public int IdVenda { get; set; }

        public int IdCliente { get; set; }

        public virtual Cliente Cliente { get; set; }

        public ICollection<ItemVenda> ItemVendas { get; set; }
        

       
    }


    

}
