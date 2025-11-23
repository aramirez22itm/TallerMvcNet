using System;

namespace TallerMvcNet.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }    // Título de la nota
        public string Content { get; set; }  // Contenido de la nota
        public string Category { get; set; } // Categoría (Trabajo, Ideas, etc.)
        public DateTime Date { get; set; }   // Fecha de creación
    }
}
