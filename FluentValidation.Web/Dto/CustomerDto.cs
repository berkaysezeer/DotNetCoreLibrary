namespace FluentValidation.Web.Dto
{
    public class CustomerDto
    {
        //public int Id { get; set; }
        //public string? Name { get; set; }
        //public string? Email { get; set; }
        //public int Age { get; set; }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }

        public string FullName { get; set; }

        public string NameAge { get; set; }

        //otomatik olarak eşleştirmek için başa class ismini yazıyoruz
        public string CreditCardNumber { get; set; }
        public DateTime CreditCardValidDate { get; set; }

        //eğer aynı name ile kullanmak istiyorsak profile classına includemembers ekleniyor
        public decimal Price { get; set; }
        public string Title { get; set; }
    }
}
