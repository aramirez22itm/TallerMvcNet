using Microsoft.AspNetCore.Mvc;
using TallerMvcNet.Models;
using System.Linq; // Necesario para las búsquedas

namespace TallerMvcNet.Controllers
{
    public class NotesController : Controller
    {
        // Almacén de notas en memoria
        private static List<Note> _notes = new List<Note>();

        // GET: Muestra las notas (y aplica filtros si los hay)
        public IActionResult Index(string searchQuery, string categoryFilter)
        {
            // Empezamos con TODAS las notas
            var results = _notes.AsQueryable();

            // 1. Si el usuario seleccionó una categoría, filtramos
            if (!string.IsNullOrEmpty(categoryFilter) && categoryFilter != "Todas")
            {
                results = results.Where(n => n.Category == categoryFilter);
            }

            // 2. Si el usuario escribió algo en el buscador, filtramos por título O contenido
            if (!string.IsNullOrEmpty(searchQuery))
            {
                // Convertimos a minúsculas para que no importe si escriben mayúsculas o minúsculas
                string query = searchQuery.ToLower();
                results = results.Where(n => n.Title.ToLower().Contains(query) ||
                                             n.Content.ToLower().Contains(query));
            }

            // Guardamos los filtros actuales para que no se borren de la pantalla
            ViewBag.CurrentSearch = searchQuery;
            ViewBag.CurrentCategory = categoryFilter;

            // Enviamos los resultados ordenados por los más recientes primero
            return View(results.OrderByDescending(n => n.Date).ToList());
        }

        // POST: Guarda una nueva nota
        [HttpPost]
        public IActionResult Add(Note note)
        {
            // Asignamos ID y Fecha automática
            note.Id = _notes.Count + 1;
            note.Date = DateTime.Now;

            _notes.Add(note);
            return RedirectToAction("Index");
        }

        // GET: Elimina una nota
        public IActionResult Delete(int id)
        {
            var note = _notes.FirstOrDefault(n => n.Id == id);
            if (note != null) _notes.Remove(note);
            return RedirectToAction("Index");
        }
    }
}
