using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.App.ISP
{
    #region Bad
    //class library Read Impl.
    //class library Create/Update/Delete Impl

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //Classın sadece okuma görevi varken Create/Update/Delete işlemlerini de yüklemiş olduk
    public class ReadProductRepository : IProductRepository
    {
        public Product Create(Product p)
        {
            throw new NotImplementedException();
        }

        public Product Delete(Product p)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product p)
        {
            throw new NotImplementedException();
        }
    }

    public interface IProductRepository
    {
        //Read Impl
        List<Product> GetAll();
        Product GetById(int id);

        //Create/Update/Delete
        Product Create(Product p);
        Product Update(Product p);
        Product Delete(Product p);
    }
    #endregion

}
