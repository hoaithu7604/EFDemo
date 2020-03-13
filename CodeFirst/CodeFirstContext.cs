using CodeFirst.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class CodeFirstContext: DbContext
    {
        public CodeFirstContext():base("name=ShoesDb")
        {
            var ensureDLLIsCopied =
               System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public DbSet<Shoes> Shoes { get; set; }
        public DbSet<ShoesStyle> ShoesStyles { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
