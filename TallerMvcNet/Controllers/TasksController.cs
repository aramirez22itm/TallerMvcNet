using Microsoft.AspNetCore.Mvc;
using TallerMvcNet.Models;

namespace TallerMvcNet.Controllers
{
    public class TasksController : Controller
    {
        // Una lista estática para guardar las tareas temporalmente
        private static List<TaskItem> _tasks = new List<TaskItem>();

        public IActionResult Index()
        {
            return View(_tasks);
        }

        [HttpPost]
        public IActionResult Add(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                // Crear ID y guardar
                int newId = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;
                _tasks.Add(new TaskItem { Id = newId, Text = text, IsCompleted = false });
            }
            return RedirectToAction("Index");
        }

        public IActionResult Toggle(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null) task.IsCompleted = !task.IsCompleted;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null) _tasks.Remove(task);
            return RedirectToAction("Index");
        }
    }
}
