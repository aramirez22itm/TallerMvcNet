namespace TallerMvcNet.Models
{
    // Esta clase define cada gasto individual
    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; } 
        public decimal Amount { get; set; }     
        public string Category { get; set; }    
        public DateTime Date { get; set; }          }

    // Esta clase muestra el resumen por mes
    public class ExpenseSummary
    {
        public string MonthYear { get; set; }   
        public decimal Total { get; set; }      
        public Dictionary<string, decimal> CategoryTotals { get; set; } 
    }
}