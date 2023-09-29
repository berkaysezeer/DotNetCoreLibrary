namespace FluentValidation.Web.Dto
{
    public class CustomerDto
    {
        //public int Id { get; set; }
        //public string? Name { get; set; }
        //public string? Email { get; set; }
        //public int Age { get; set; }

        public int Id { get; set; }
        public string? Isim { get; set; }
        public string? Eposta { get; set; }
        public int Yas { get; set; }

        public string FullName { get; set; }

        public string NameAge { get; set; }
    }
}
