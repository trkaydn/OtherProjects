using FluentValidation;
using InvoiceUI.Models;

namespace InvoiceUI.ValidationRules
{
	public class InvoiceValidator : AbstractValidator<AddInvoiceVM>
	{
		public InvoiceValidator()
		{
			RuleFor(x => x.CompanyTitle)
				.NotEmpty().WithMessage("Lütfen firma ünvanı girin.");

			RuleFor(x => x.InvoiceDate)
				.NotEmpty().WithMessage("Lütfen tarih seçin.");

			RuleFor(x => x.ProductNames.Count)
				.Equal(x => x.ProductAmounts.Count).WithMessage("Ürün adı ve tutar boş geçilemez.");

		}
	}
}
