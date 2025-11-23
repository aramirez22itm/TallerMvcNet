using Microsoft.AspNetCore.Mvc;
using TallerMvcNet.Models;
using System.Linq;
using System.Collections.Generic; 

namespace TallerMvcNet.Controllers
{
    public class CalendarController : Controller
    {
        private static List<CalendarEvent> _events = new List<CalendarEvent>();

        // PANTALLA PRINCIPAL: Lista y Formulario de Agregar
        public IActionResult Index()
        {
            // Ordena por fecha y luego por hora
            return View(_events.OrderBy(e => e.Date).ThenBy(e => e.Time).ToList());
        }

        [HttpPost]
        public IActionResult Add(CalendarEvent evt)
        {
            evt.Id = _events.Count > 0 ? _events.Max(e => e.Id) + 1 : 1;
            _events.Add(evt);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var evt = _events.FirstOrDefault(e => e.Id == id);
            if (evt != null) _events.Remove(evt);
            return RedirectToAction("Index");
        }


        // Cargar la pantalla de edición
        public IActionResult Edit(int id)
        {
            var evt = _events.FirstOrDefault(e => e.Id == id);
            if (evt == null) return RedirectToAction("Index");

            return View(evt);
        }

        // Guardar los cambios
        [HttpPost]
        public IActionResult Update(CalendarEvent evt)
        {
            var original = _events.FirstOrDefault(e => e.Id == evt.Id);
            if (original != null)
            {
                original.Title = evt.Title;
                original.Date = evt.Date;
                original.Time = evt.Time;
                original.ReminderMinutes = evt.ReminderMinutes;
                original.Details = evt.Details;
            }
            return RedirectToAction("Index");
        }
    }
}