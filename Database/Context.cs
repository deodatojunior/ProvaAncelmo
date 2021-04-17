using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProvaAncelmo.Models;

namespace ProjetoIntegrador.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        
        public DbSet<ClienteViewModel> ClienteViewModels { get; set; }
        public DbSet<ProdutoViewModel> ProdutoViewModels { get; set; }
       
    }
}
