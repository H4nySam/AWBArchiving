using AWBArchiving.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

namespace AWBArchiving.DAL
{
   public class BaseContext : DbContext 
    {
        public BaseContext()
        {
                
        }
        public BaseContext(string connStringName) : base(connStringName)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<View> Views { get; set; }
        public DbSet<ArchivingDB> Databases { get; set; }
    }
}
