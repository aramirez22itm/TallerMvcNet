using Microsoft.AspNetCore.Mvc;
using TallerMvcNet.Models;

namespace TallerMvcNet.Controllers
{
    public class PasswordController : Controller
    {
        public IActionResult Index()
        {
            return View(new PasswordModel());
        }

        [HttpPost]
        public IActionResult Generate(PasswordModel model)
        {
            // Definimos los caracteres posibles
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string number = "0123456789";
            const string symbol = "!@#$%^&*()-=_+";

            string charPool = "";

            // Vamos sumando al 'saco' de letras según lo que marcó el usuario
            if (model.IncludeLowercase) charPool += lower;
            if (model.IncludeUppercase) charPool += upper;
            if (model.IncludeNumbers) charPool += number;
            if (model.IncludeSymbols) charPool += symbol;

            // Si no marcó nada, le damos error
            if (string.IsNullOrEmpty(charPool))
            {
                model.GeneratedPassword = "¡Debes seleccionar al menos una opción!";
                return View("Index", model);
            }

            // Generación aleatoria
            var random = new Random();
            // char[] es un array de caracteres (letras sueltas)
            var result = new char[model.Length];

            for (int i = 0; i < model.Length; i++)
            {
                // Elegimos una letra al azar del 'saco'
                result[i] = charPool[random.Next(charPool.Length)];
            }

            // Convertimos las letras sueltas en un texto final
            model.GeneratedPassword = new string(result);

            return View("Index", model);
        }
    }
}
