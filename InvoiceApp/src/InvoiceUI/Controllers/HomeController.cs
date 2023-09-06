using FluentValidation.Results;
using InvoiceData;
using InvoiceData.Entities;
using InvoiceUI.Models;
using InvoiceUI.ValidationRules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceUI.Controllers
{
	public class HomeController : Controller
	{
		Context _context = new Context();
		public IActionResult Index()
		{
			var values = _context.Invoices.Include(x => x.Products).ToList();
			_context.Dispose();
			return View(values);
		}

		public IActionResult AddInvoice()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddInvoice(AddInvoiceVM p)
		{
			try
			{
				#region validation
				InvoiceValidator validator = new InvoiceValidator();
				ValidationResult result = validator.Validate(p);
				if (!result.IsValid)
				{
					foreach (var error in result.Errors)
						ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
					return View();
				}
				#endregion

				Invoice invoice = new Invoice()
				{
					CompanyTitle = p.CompanyTitle,
					InvoiceDate = p.InvoiceDate,
					Products = new List<Product>()
				};

				for (int i = 0; i < p.ProductNames.Count; i++)
				{
					invoice.Products.Add(new Product()
					{
						ProductName = p.ProductNames[i],
						Amount = p.ProductAmounts[i]
					});
				}

				_context.Invoices.Add(invoice);
				_context.SaveChanges();
				_context.Dispose();
				return RedirectToAction("Index");
			}

			catch (Exception e)
			{
				ViewBag.Message = "Bir hata oluştu: " + e.Message;
				return View();
			}
		}

		public IActionResult DeleteInvoice(int invoiceId)
		{
			var value = _context.Invoices.FirstOrDefault(x => x.InvoiceID == invoiceId);
			_context.Invoices.Remove(value);
			_context.SaveChanges();
			_context.Dispose();
			return RedirectToAction("Index");
		}
	}
}
