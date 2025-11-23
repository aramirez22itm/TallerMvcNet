namespace TallerMvcNet.Models
{
    public class TipModel
    {
        // Datos de entrada
        public decimal BillAmount { get; set; } // Monto de la cuenta
        public decimal TipPercentage { get; set; } // Porcentaje (10, 15, 20...)

        // Resultados
        public decimal TipAmount { get; set; } // Monto de la propina
        public decimal TotalAmount { get; set; } // Total final
    }
}