using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaAncelmo.Models
{
    public class ClienteViewModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sexo { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string telefone { get; set; }
    }
}
