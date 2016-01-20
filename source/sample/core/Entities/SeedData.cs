using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace core.Entities
{
    public class SeedData:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            foreach (var cat in GenCategories())
            {
                context.Category.Add(cat);
                context.SaveChanges();
                GenProducts(cat, GenCategories().IndexOf(cat) * 10, GenCategories().IndexOf(cat) + 10)
                    .ForEach(i => context.Product.Add(i));
                context.SaveChanges();
            }
        }

        public List<Category> GenCategories()
        {
            return new List<Category>{
                new Category
                {
                    ID = 1,
                    Name = "category1"
                },
                new Category
                {
                    ID = 2,
                    Name = "category2",
                }
            };
        }

        public List<Product> GenProducts(Category category, int from,int to)
        {
            List<Product> Products = new List<Product>();
            for (int i = from; i < to; i++)
            {
                Products.Add(
                    new Product
                    {
                        ID = i,
                        Name = "Product_" + i,
                        UnitPrice = i * 10000,
                        CategoryID = category.ID,
                        Category = category
                    }
                );
            }
            return Products;
        }
    }
}
