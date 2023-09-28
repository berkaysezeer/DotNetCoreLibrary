using FluentValidation.Web.Models;

namespace FluentValidation.Web.FluentValidators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} Alanı Boş Geçilemez";

        public CustomerValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(NotEmptyMessage);

            RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(NotEmptyMessage)
            .EmailAddress()
            .WithMessage("Geçersiz E-posta");

            RuleFor(x => x.Age)
            .NotEmpty()
            .WithMessage(NotEmptyMessage)
            .InclusiveBetween(18, 60)
            .WithMessage("Geçersiz Yaş Aralığı");

            //Custom Validator
            RuleFor(x => x.Birthday)
            .NotEmpty()
            .WithMessage(NotEmptyMessage)
            .Must(x =>
            {
                return DateTime.Now.AddYears(-18) >= x;

            }).WithMessage("Yaşınız 18'den Büyük Olmalıdır");

            //Address validator içerisindeki tüm kuralları customer ile ilgili işlemler yapılırken uygulayabilmek için SetValidator kullandık
            RuleForEach(x => x.Addresses).SetValidator(new AddressValidator());
        }
    }
}
