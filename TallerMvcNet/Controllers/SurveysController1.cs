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

        // LISTA DE ENCUESTAS
        public IActionResult Index()
        {
            return View(_surveys);
        }

        // CREAR ENCUESTA
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

                // Se separa el texto por cada coma ',' para crear las opciones
                var optionTexts = optionsString.Split(',');

                foreach (var text in optionTexts)
                {
                    // Limpia espacios en blanco y agregamos
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        newSurvey.Options.Add(new SurveyOption { Text = text.Trim(), Votes = 0 });
                    }
                }

                _surveys.Add(newSurvey);
            }
            return RedirectToAction("Index");
        }

        // PANTALLA PARA VOTAR 
        public IActionResult Vote(int id)
        {
            var survey = _surveys.FirstOrDefault(s => s.Id == id);
            if (survey == null) return RedirectToAction("Index");

            return View(survey);
        }

        // GUARDAR EL VOTO 
        [HttpPost]
        public IActionResult SubmitVote(int surveyId, string selectedOption)
        {
            var survey = _surveys.FirstOrDefault(s => s.Id == surveyId);
            if (survey != null)
            {
                var option = survey.Options.FirstOrDefault(o => o.Text == selectedOption);
                if (option != null)
                {
                    option.Votes++; 
                }
            }
            // Después de votar, se muestran los resultados
            return RedirectToAction("Results", new { id = surveyId });
        }

        // VER RESULTADOS
        public IActionResult Results(int id)
        {
            var survey = _surveys.FirstOrDefault(s => s.Id == id);
            if (survey == null) return RedirectToAction("Index");

            return View(survey);
        }
    }
}
