using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.App.SRP
{

    /*
     SRP için kötü kdolama örneğidir. Çünkü;
    1-WriteToConsole: Class'ın konsola yazma görevi var
    2- SaveOrUpdate ve Delete işlemleri yapıyor (crud)
    3- Property bilgilerini de aynı class'ta tutuyoruz. Temel property tanımlamaları farklı classta olmalıydı
     */
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }


        private static List<Product> ProductList = new List<Product>();

        //Kısaca Get ayarı yapıldı (Property'i dış dünyaya açtık)
        public List<Product> GetProducts => ProductList;

        //public List<Product> GetProducts { get {  return ProductList; } }

        public Product()
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

        public void WriteToConsole()
        {
            ProductList.ForEach(
                x => Console.WriteLine($"{x.Id} - {x.Name}")
                );
        }
    }
}
