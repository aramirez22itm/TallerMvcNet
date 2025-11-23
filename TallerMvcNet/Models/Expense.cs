namespace TallerMvcNet.Models
{
    // Esta clase define cada gasto individual
    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; } // Ej: "Hamburguesa"
        public decimal Amount { get; set; }     // Ej: 15.50
        public string Category { get; set; }    // Ej: "Comida"
        public DateTime Date { get; set; }      // Ej: 2023-10-25
    }

    // Esta clase nos ayuda a mostrar el resumen por mes
    public class ExpenseSummary
    {
        public string MonthYear { get; set; }   // Ej: "2023-10"
        public decimal Total { get; set; }      // Total gastado ese mes
        public Dictionary<string, decimal> CategoryTotals { get; set; } // Desglose por categoría
    }
}