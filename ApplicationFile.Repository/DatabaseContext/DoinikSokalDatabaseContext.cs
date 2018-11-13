using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationFile.Model.Models;

namespace ApplicationFile.Repository.DatabaseContext
{
    public class DoinikSokalDatabaseContext:DbContext
    {
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Post> Posts { get; set; }

        private void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        
    }
}
