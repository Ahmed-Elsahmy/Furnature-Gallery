using ITI_Project.DAL.DB.ApplicationDB;
using ITI_Project.DAL.Entites;
using ITI_Project.DAL.Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI_Project.DAL.Repo.Impelemntation
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext db;

        public ProductRepo(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public bool Create(Product product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = db.Products.Where(a => a.Id == id).FirstOrDefault();
                if (data.IsDeleted)
                {
                    throw new Exception("The Employee is already deleted");

                }
                data.IsDeleted = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> GetAll()
        {
            var result = db.Products.ToList();
            return result;
        }

        public Product GetByProductId(int id)
        {
            var data = db.Products.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }

        public bool Update(Product product)
        {
            try
            {
                var data = db.Products.Where(a => a.Id == product.Id).FirstOrDefault();
                data.Name = product.Name;
                data.Available = product.Available;
                data.Description = product.Description;
                data.Price = product.Price;
                data.Category = product.Category;
                data.Quantity = product.Quantity;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
