using Microsoft.AspNetCore.Mvc;
using TallerMvcNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace TallerMvcNet.Controllers
{
    public class RecipesController : Controller
    {
        // Simulamos una base de datos con recetas precargadas
        private static List<Recipe> _recipes = new List<Recipe>
        {
            new Recipe { Id = 1, Name = "Pasta Carbonara", Category = "Italiana", TimeMinutes = 20, IsSaved = false, Ingredients = "pasta, huevo, queso, tocineta" },
            new Recipe { Id = 2, Name = "Tacos al Pastor", Category = "Mexicana", TimeMinutes = 45, IsSaved = true, Ingredients = "tortillas, cerdo, piña, cilantro" },
            new Recipe { Id = 3, Name = "Sushi Roll", Category = "Asiática", TimeMinutes = 60, IsSaved = false, Ingredients = "arroz, algas, salmon, aguacate" },
            new Recipe { Id = 4, Name = "Ensalada César", Category = "Saludable", TimeMinutes = 15, IsSaved = false, Ingredients = "lechuga, pollo, crotones, aderezo" },
            new Recipe { Id = 5, Name = "Pizza Margarita", Category = "Italiana", TimeMinutes = 30, IsSaved = false, Ingredients = "masa, tomate, queso, albahaca" },
            new Recipe { Id = 6, Name = "Burritos", Category = "Mexicana", TimeMinutes = 25, IsSaved = false, Ingredients = "tortilla, frijoles, carne, queso" }
        };

        // GET: Muestra las recetas filtradas
        public IActionResult Index(string category, string ingredient)
        {
            var results = _recipes.AsQueryable();

            // 1. Filtro por Categoría
            if (!string.IsNullOrEmpty(category) && category != "Todas")
            {
                results = results.Where(r => r.Category == category);
            }

            // 2. Filtro por Ingrediente (Búsqueda parcial)
            if (!string.IsNullOrEmpty(ingredient))
            {
                results = results.Where(r => r.Ingredients.ToLower().Contains(ingredient.ToLower()));
            }

            // Guardamos los filtros para mantenerlos en los inputs de la vista
            ViewBag.CurrentCategory = category;
            ViewBag.CurrentIngredient = ingredient;

            return View(results.ToList());
        }

        // Acción para guardar/desguardar en favoritos
        public IActionResult ToggleSave(int id)
        {
            var recipe = _recipes.FirstOrDefault(r => r.Id == id);
            if (recipe != null)
            {
                recipe.IsSaved = !recipe.IsSaved; // Invertimos el valor
            }

            // Esta línea es la clave: siempre debe devolver algo
            return RedirectToAction("Index");
        }
    }
}