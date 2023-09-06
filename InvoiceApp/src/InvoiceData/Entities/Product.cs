namespace InvoiceData.Entities
{
	public class Product
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public double Amount { get; set; }
		public int InvoiceID { get; set; }
		public Invoice Invoice { get; set; }
	}
}
