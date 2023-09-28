using FluentValidation.Web.Models;

namespace FluentValidation.Web.FluentValidators
{
    //https://docs.fluentvalidation.net/en/latest/configuring.html#
    public class AddressValidator : AbstractValidator<Address>
    {
        public string NotEmptyMessage { get; set; } = "{PropertyName} Alanı Boş Geçilemez";

        public AddressValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage(NotEmptyMessage);

            RuleFor(x => x.Province)
                .NotEmpty()
                .WithMessage(NotEmptyMessage);

            RuleFor(x => x.PostCode)
                .NotEmpty()
                .WithMessage(NotEmptyMessage)
                .MaximumLength(5)
                .WithMessage("{PropertyName} alanı en fazla {MaxLength} karakter olabilir");
        }
    }
}
