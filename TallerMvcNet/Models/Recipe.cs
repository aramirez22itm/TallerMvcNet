using System.Collections.Generic;

namespace TallerMvcNet.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public string Category { get; set; }    
        public string Ingredients { get; set; } 
        public int TimeMinutes { get; set; }    // Tiempo de preparación
        public bool IsSaved { get; set; }       // ¿Está guardada en favoritos?
    }
}
