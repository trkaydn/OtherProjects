using EntityLayer;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BusinessLayer.ValidationRules
{
	public class AdminValidator : AbstractValidator<Admin>
	{
		public AdminValidator()
		{
			RuleFor(x => x.FirstName)
				.NotEmpty().WithMessage("İsim boş geçilemez.")
				.MinimumLength(2).WithMessage("İsim en az 2 karakter olmalıdır.")
				.MaximumLength(25).WithMessage("İsim en fazla 25 karakter olmalıdır.");

			RuleFor(x => x.LastName)
				.NotEmpty().WithMessage("Soyisim boş geçilemez.")
				.MinimumLength(2).WithMessage("Soyisim en az 2 karakter olmalıdır.")
				.MaximumLength(25).WithMessage("Soyisim en fazla 25 karakter olmalıdır.");


			RuleFor(x => x.MailAddress)
				.NotEmpty().WithMessage("E-Posta boş geçilemez.")
				.EmailAddress().WithMessage("Lütfen geçerli bir E-Posta adresi girin.")
				.MaximumLength(25).WithMessage("E-Posta en fazla 25 karakter olmalıdır.");

			RuleFor(x => x.Password)
				.NotEmpty().WithMessage("Şifre boş geçilemez.")
				.MinimumLength(5).WithMessage("Şifreniz en az 5 karakterden oluşmalıdır.")
				.MaximumLength(25).WithMessage("Şifreniz en fazla 25 karakterden oluşmalıdır.")
				.Must(IsPasswordValid).WithMessage("Şifreniz en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.");

		}

		private bool IsPasswordValid(string arg)
		{
			if (string.IsNullOrEmpty(arg))
				return false;

			Regex regex = new Regex(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).+");
			return regex.IsMatch(arg);
		}
	}
}
