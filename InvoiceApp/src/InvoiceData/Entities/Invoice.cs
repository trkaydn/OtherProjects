using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceData.Entities
{
	public class Invoice
	{
		[Key]
		public int InvoiceID { get; set; }
		public string CompanyTitle { get; set; }
		public DateTime InvoiceDate { get; set; }
		public ICollection<Product> Products  { get; set; }
	}
}
