﻿using Base.DOMAIN.Enums;
using System.Collections.Generic;


namespace Base.DOMAIN.Models
{
    public class Produto
    { 
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public double ValorProduto { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int QuantidadeVendas { get; set; }
        public string DescricaoProduto { get; set; }
        
        
    }
}
