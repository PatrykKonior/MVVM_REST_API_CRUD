namespace Backend_API.Models.Entities
{
    public class Expense
    {
        public int ExpenseID { get; set; }
        public int? ProjectID { get; set; }
        public DateTime? ExpenseDate { get; set; }
        public string ExpenseDescription { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal? VATAmount { get; set; }
        public decimal? GrossAmount { get; set; }
    }
}