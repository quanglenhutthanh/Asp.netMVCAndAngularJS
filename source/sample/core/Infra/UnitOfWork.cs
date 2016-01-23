using core.Entities;
using core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Infra
{
    public class UnitOfWork
    {
        private DataContext context = new DataContext();
        private GenericRepository<Product> productRepository;
        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                    this.productRepository = new GenericRepository<Product>(context);
                return productRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
