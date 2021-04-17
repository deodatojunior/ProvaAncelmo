using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaAncelmo.Models
{
    public class ProdutoViewModel
    {
        public int id { get; set; }
        public string codigoProduto { get; set; }
        public double preco { get; set; }
        public string categoria { get; set; }
        public string observacao { get; set; }

    }
}
