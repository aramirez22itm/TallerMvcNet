using Microsoft.AspNetCore.Mvc;
using TallerMvcNet.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace TallerMvcNet.Controllers
{
    public class StopwatchController : Controller
    {
        // Historial de tiempos guardados
        private static List<TimeRecord> _records = new List<TimeRecord>();

        public IActionResult Index()
        {
            // Mostramos los tiempos ordenados del más reciente al más antiguo
            return View(_records.OrderByDescending(r => r.Date).ToList());
        }

        [HttpPost]
        public IActionResult SaveTime(string timeRecorded, string comment)
        {
            if (!string.IsNullOrEmpty(timeRecorded))
            {
                _records.Add(new TimeRecord
                {
                    Id = _records.Count + 1,
                    Time = timeRecorded,
                    Date = DateTime.Now,
                    Comment = comment ?? "Sin comentarios"
                });
            }
            return RedirectToAction("Index");
        }

        // Acción para borrar el historial si quieres limpiar
        public IActionResult ClearHistory()
        {
            _records.Clear();
            return RedirectToAction("Index");
        }
    }
}