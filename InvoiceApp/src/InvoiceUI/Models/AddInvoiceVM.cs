using System;
using System.Collections.Generic;

namespace InvoiceUI.Models
{
	public class AddInvoiceVM
	{
		public string CompanyTitle { get; set; }
		public DateTime InvoiceDate { get; set; }
		public List<string> ProductNames { get; set; }
		public List<double> ProductAmounts { get; set; }
	}
}
