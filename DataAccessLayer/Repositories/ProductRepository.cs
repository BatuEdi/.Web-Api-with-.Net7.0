using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ProductRepository : IProductDal
    {
        Context con = new Context();
        public Product CreateProduct(Product product)
        {
            con.Products.Add(product);
            con.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            var deletedProduct = GetProductById(id);
            con.Products.Remove(deletedProduct);
            con.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
           return con.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return con.Products.Find(id);
        }

        public Product UpdateProduct(Product product)
        {
            con.Products.Update(product);
            con.SaveChanges();
            return product;
        }
    }
}
