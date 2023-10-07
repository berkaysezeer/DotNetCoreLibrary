using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.App.SRP.Good
{

    //Temel propertyleri de ayırmış olduk. (3. sorumluluk)
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    //Repository görevini üstlenene classı ayırarak 2. sorumluluğu çözmüş olduk.
    public class ProductRepository
    {
        private static List<Product> ProductList = new List<Product>();

        public ProductRepository()
        {
            ProductList = new()
            {
                new(){Id=1, Name="Kalem1"},
                new(){Id=2, Name="Kalem2"},
                new(){Id=3, Name="Kalem3"},
                new(){Id=4, Name="Kalem4"},
                new(){Id=5, Name="Kalem5"},
            };
        }

        //Kısaca Get ayarı yapıldı. (Property'i dış dünyaya açtık)
        public List<Product> GetProducts => ProductList;
        //public List<Product> GetProducts { get {  return ProductList; } }

        public void SaveOrUpdate(Product product)
        {
            //var hasProduct = products.Contains(product);
            var hasProduct = ProductList.Any(p => p.Id == product.Id);

            if (!hasProduct)
            {
                ProductList.Add(product);
            }
            else
            {
                var index = ProductList.FindIndex(x => x.Id == product.Id);
                ProductList[index] = product;
            }
        }

        public void Delete(int id)
        {
            //var hasProduct = products.Contains(product);
            var hasProduct = ProductList.Find(x => x.Id == id);

            if (hasProduct is null)
            {
                throw new Exception("Ürün Bulunamadı");
            }

            ProductList.Remove(hasProduct);
        }

    }

    //ürünü sunan bir class ayarladık. Bununla birlikte ilk sorumluluğu çözmüş olduk.
    public class ProductPresenter
    {
        public void WriteToConsole(List<Product> ProductList)
        {
            ProductList.ForEach(
                x => Console.WriteLine($"{x.Id} - {x.Name}")
                );
        }
    }
}
