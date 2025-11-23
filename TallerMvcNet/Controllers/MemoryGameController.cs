using Microsoft.AspNetCore.Mvc;
using TallerMvcNet.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TallerMvcNet.Controllers
{
    public class MemoryGameController : Controller
    {
        // Tabla de puntuaciones altas
        private static List<ScoreRecord> _scores = new List<ScoreRecord>();

        public IActionResult Index()
        {
            // Mostramos los récords ordenados por mayor puntaje
            return View(_scores.OrderByDescending(s => s.Score).ToList());
        }

        [HttpPost]
        public IActionResult SaveScore(string playerName, int moves, int timeSeconds, int score)
        {
            _scores.Add(new ScoreRecord
            {
                Id = _scores.Count + 1,
                PlayerName = playerName,
                Moves = moves,
                TimeSeconds = timeSeconds,
                Score = score,
                Date = DateTime.Now
            });

            return RedirectToAction("Index");
        }
    }
}
