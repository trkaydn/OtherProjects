using EntityLayer;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
	public class DepartmentValidator : AbstractValidator<Department>
	{
		public DepartmentValidator()
		{
			RuleFor(x => x.DepartmentName)
				.NotEmpty().WithMessage("Departman adı boş geçilemez.")
				.MinimumLength(2).WithMessage("Departman adı en az 2 karakter uzunluğunda olmalıdır.")
				.MaximumLength(50).WithMessage("Departman adı en fazla 50 karakter uzunluğunda olmalıdır.");
		}
	}
}
