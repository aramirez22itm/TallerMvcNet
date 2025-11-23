using Microsoft.AspNetCore.Mvc;
using TallerMvcNet.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TallerMvcNet.Controllers
{
    public class SurveysController : Controller
    {
        private static List<Survey> _surveys = new List<Survey>();

        // 1. LISTA DE ENCUESTAS
        public IActionResult Index()
        {
            return View(_surveys);
        }

        // 2. CREAR ENCUESTA (Recibe las opciones como texto separado por comas)
        [HttpPost]
        public IActionResult Create(string question, string optionsString)
        {
            if (!string.IsNullOrEmpty(question) && !string.IsNullOrEmpty(optionsString))
            {
                var newSurvey = new Survey
                {
                    Id = _surveys.Count + 1,
                    Question = question
                };

                // TRUCO: Cortamos el texto por cada coma ',' para crear las opciones
                var optionTexts = optionsString.Split(',');

                foreach (var text in optionTexts)
                {
                    // Limpiamos espacios en blanco y agregamos
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        newSurvey.Options.Add(new SurveyOption { Text = text.Trim(), Votes = 0 });
                    }
                }

                _surveys.Add(newSurvey);
            }
            return RedirectToAction("Index");
        }

        // 3. PANTALLA PARA VOTAR (GET)
        public IActionResult Vote(int id)
        {
            var survey = _surveys.FirstOrDefault(s => s.Id == id);
            if (survey == null) return RedirectToAction("Index");

            return View(survey);
        }

        // 4. GUARDAR EL VOTO (POST)
        [HttpPost]
        public IActionResult SubmitVote(int surveyId, string selectedOption)
        {
            var survey = _surveys.FirstOrDefault(s => s.Id == surveyId);
            if (survey != null)
            {
                var option = survey.Options.FirstOrDefault(o => o.Text == selectedOption);
                if (option != null)
                {
                    option.Votes++; // ¡Sumamos un voto!
                }
            }
            // Después de votar, te llevamos a ver los resultados
            return RedirectToAction("Results", new { id = surveyId });
        }

        // 5. VER RESULTADOS
        public IActionResult Results(int id)
        {
            var survey = _surveys.FirstOrDefault(s => s.Id == id);
            if (survey == null) return RedirectToAction("Index");

            return View(survey);
        }
    }
}
