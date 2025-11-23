using Microsoft.AspNetCore.Mvc;
using TallerMvcNet.Models;

namespace TallerMvcNet.Controllers
{
    public class BookingsController : Controller
    {
        // Base de datos simulada
        private static List<Reservation> _reservations = new List<Reservation>();

        // Definimos los horarios que ofrece nuestro negocio
        private List<string> _allSlots = new List<string>
        {
            "09:00", "10:00", "11:00", "12:00", "14:00", "15:00", "16:00"
        };

        // GET: Muestra el calendario y disponibilidad
        public IActionResult Index(DateTime? searchDate)
        {
            // 1. Si no eligieron fecha, usamos la de HOY
            DateTime date = searchDate ?? DateTime.Today;

            // 2. Buscamos qué horas YA están ocupadas para esa fecha
            var takenTimes = _reservations
                .Where(r => r.Date.Date == date.Date)
                .Select(r => r.Time)
                .ToList();

            // 3. Calculamos las libres (Todas - Ocupadas)
            // "Except" es una función de LINQ que hace la resta de listas
            var availableSlots = _allSlots.Except(takenTimes).ToList();

            // 4. Pasamos los datos a la vista usando ViewBag
            ViewBag.CurrentDate = date;
            ViewBag.AvailableSlots = availableSlots;
            ViewBag.Message = TempData["Message"]; // Para mensajes de éxito/error

            // 5. Devolvemos la lista de TODAS las reservas hechas para ver el historial
            return View(_reservations.OrderByDescending(r => r.Date).ThenBy(r => r.Time).ToList());
        }

        // POST: Guarda la reserva
        [HttpPost]
        public IActionResult Book(DateTime date, string time, string userName)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(time))
            {
                TempData["Message"] = "❌ Faltan datos.";
                return RedirectToAction("Index", new { searchDate = date });
            }

            // Doble validación: Verificar que no se nos adelantó alguien
            bool isTaken = _reservations.Any(r => r.Date.Date == date.Date && r.Time == time);

            if (isTaken)
            {
                TempData["Message"] = $"❌ Error: El horario {time} ya está ocupado.";
            }
            else
            {
                _reservations.Add(new Reservation
                {
                    Id = _reservations.Count + 1,
                    Date = date,
                    Time = time,
                    UserName = userName
                });
                TempData["Message"] = $"✅ ¡Reserva confirmada para {userName} a las {time}!";
            }

            // Recargamos la página manteniendo la fecha seleccionada
            return RedirectToAction("Index", new { searchDate = date });
        }
    }
}
