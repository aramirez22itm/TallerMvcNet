using System;

namespace TallerMvcNet.Models
{
    public class TimeRecord
    {
        public int Id { get; set; }
        public string Time { get; set; }     // El tiempo en formato texto (00:01:23)
        public DateTime Date { get; set; }   // Cuándo se registró
        public string Comment { get; set; }  // Nota opcional o descripcion
    }
}