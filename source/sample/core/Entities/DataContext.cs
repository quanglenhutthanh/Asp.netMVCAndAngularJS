using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace core.Entities
{
    public class DataContext:DbContext
    {
        public DataContext() : this(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString) { }
        public DataContext(string connectString) : base(connectString) { }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
