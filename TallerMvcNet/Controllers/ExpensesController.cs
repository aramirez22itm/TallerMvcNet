using Microsoft.AspNetCore.Mvc;
using TallerMvcNet.Models;

namespace TallerMvcNet.Controllers
{
    public class ExpensesController : Controller
    {
        // Lista en memoria para guardar los gastos
        private static List<Expense> _expenses = new List<Expense>();

        public IActionResult Index()
        {
            // Se Prepara el RESUMEN 
            // Agrupamos los gastos por Mes y Año
            var summary = _expenses
                .GroupBy(e => e.Date.ToString("yyyy-MM"))
                .Select(grupo => new ExpenseSummary
                {
                    MonthYear = grupo.Key,
                    Total = grupo.Sum(e => e.Amount),
                    // Dentro de cada mes, agrupamos por Categoría
                    CategoryTotals = grupo.GroupBy(e => e.Category)
                                          .ToDictionary(k => k.Key, v => v.Sum(x => x.Amount))
                })
                .OrderByDescending(s => s.MonthYear)
                .ToList();

            // Guarda el resumen en una "bolsa" llamada ViewBag para enviarlo a la vista
            ViewBag.Summary = summary;

            // Envia la lista completa de gastos ordenada por fecha
            return View(_expenses.OrderByDescending(e => e.Date).ToList());
        }

        [HttpPost]
        public IActionResult Add(Expense expense)
        {
            // Se Asigna un ID simple
            expense.Id = _expenses.Count + 1;
            _expenses.Add(expense);

            // Vuelve a cargar la página
            return RedirectToAction("Index");
        }
    }
}