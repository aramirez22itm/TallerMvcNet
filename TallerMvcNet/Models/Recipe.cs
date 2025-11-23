using System.Collections.Generic;

namespace TallerMvcNet.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }        // Nombre del plato
        public string Category { get; set; }    // Tipo (Italiana, Mexicana...)
        public string Ingredients { get; set; } // Lista de ingredientes (texto simple)
        public int TimeMinutes { get; set; }    // Tiempo de preparación
        public bool IsSaved { get; set; }       // ¿Está guardada en favoritos?
    }
}
