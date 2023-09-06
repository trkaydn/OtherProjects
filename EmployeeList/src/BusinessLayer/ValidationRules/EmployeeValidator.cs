using EntityLayer;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
	public class EmployeeValidator : AbstractValidator<Employee>
	{
		public EmployeeValidator()
		{
			RuleFor(x => x.FirstName)
				.NotEmpty().WithMessage("İsim boş geçilemez.")
				.MinimumLength(2).WithMessage("İsim en az 2 karakter olmalıdır.")
				.MaximumLength(25).WithMessage("İsim en fazla 25 karakter olmalıdır.");

			RuleFor(x => x.LastName)
				.NotEmpty().WithMessage("Soyisim boş geçilemez.")
				.MinimumLength(2).WithMessage("Soyisim en az 2 karakter olmalıdır.")
				.MaximumLength(25).WithMessage("Soyisim en fazla 25 karakter olmalıdır.");

			RuleFor(x => x.Phone)
				.NotEmpty().WithMessage("Telefon numarası boş geçilemez.")
				.MinimumLength(3).WithMessage("Telefon numarası en az 3 sayıdan oluşmalıdır.")
				.MaximumLength(25).WithMessage("Telefon numarası en fazla 25 sayıdan oluşmalıdır.")
				.Matches(@"^[0-9]+$").WithMessage("Telefon numarası sayılardan oluşmalıdır.");
		}
	}
}
