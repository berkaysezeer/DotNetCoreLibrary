namespace FluentValidation.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
        public DateTime? Birthday { get; set; }

        public Gender Gender { get; set; }

        //class'ı complex hale getiriyoruz
        public CreditCard CreditCard { get; set; }

        //Customer.Address[1]
        public IList<Address>? Addresses { get; set; }

        //Get kullanımı CustomerProfil'deki FullName property ile eşleşmesini sağlıyor eğer bu söz dizimi kullanılmazsa manuel eşleştirilmesi gerekir
        public string GetFullName()
        {
            return $"{Name} - {Email} ({Age})";
        }

        public string NameAge()
        {
            return $"{Name} - {Age}";
        }
    }
}
