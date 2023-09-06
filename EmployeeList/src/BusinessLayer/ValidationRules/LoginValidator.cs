using EntityLayer;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
	public class LoginValidator : AbstractValidator<Admin>
	{
		public LoginValidator()
		{
			RuleFor(x => x.MailAddress)
				.NotEmpty().WithMessage("Lütfen bir E-Posta adresi girin.")
				.EmailAddress().WithMessage("Lütfen geçerli bir E-Posta adresi girin.");

			RuleFor(x => x.Password)
				.NotEmpty().WithMessage("Lütfen bir şifre girin.");
		}
	}
}
