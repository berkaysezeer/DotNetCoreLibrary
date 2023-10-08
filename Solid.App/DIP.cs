using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.App.DIP
{
    //high level modül low level modüle bağlı olmamalı. Arada interface kullanılmalı

    #region Bad   
    //public class ProductService
    //{
    //    //High level class low level classı (ProductRepositoryFromSql) doğrudan biliypr
    //    //ProductRepositoryFromSql'de bir değişiklik olduğunda ProductService de etkilenecek
    //    private readonly ProductRepositoryFromSql _repository;

    //    public ProductService(ProductRepositoryFromSql repository)
    //    {
    //        _repository = repository;
    //    }

    //    public List<string> GetAll()
    //    {
    //        return _repository.GetAll();
    //    }
    //}

    //public class ProductRepositoryFromSql
    //{
    //    public List<string> GetAll()
    //    {
    //        return new List<string>() { "Sql Kalem1", "Sql Kalem2" };
    //    }
    //}

    #endregion

    #region Good   
    public class ProductService
    {
        //yapıcı metot olarak interfaceyi kullnacağız. interface'ye vereceğimiz classa göre ProductService'in davranışı değişecek
        private readonly IRepository _repository;

        public ProductService(IRepository repository)
        {
            _repository = repository;
        }

        public List<string> GetAll()
        {
            return _repository.GetAll();
        }
    }

    public class ProductRepositoryFromSql : IRepository
    {
        public List<string> GetAll()
        {
            return new List<string>() { "Sql Kalem1", "Sql Kalem2" };
        }
    }

    public class ProductRepositoryFromOracle : IRepository
    {
        public List<string> GetAll()
        {
            return new List<string>() { "Oracle Kalem1", "Oracle Kalem2" };
        }
    }

    public interface IRepository
    {
        List<string> GetAll();
    }
    #endregion
}
