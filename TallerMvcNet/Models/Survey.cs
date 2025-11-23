using System.Collections.Generic;

namespace TallerMvcNet.Models
{
    // Clase principal: La encuesta
    public class Survey
    {
        public int Id { get; set; }
        public string Question { get; set; } // La pregunta 
        public List<SurveyOption> Options { get; set; } = new List<SurveyOption>(); // Lista de opciones
    }

    // Clase secundaria: Cada opción disponible
    public class SurveyOption
    {
        public string Text { get; set; } 
        public int Votes { get; set; }   // Contador de votos 
    }
}