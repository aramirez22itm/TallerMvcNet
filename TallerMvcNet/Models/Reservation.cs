using System;

namespace TallerMvcNet.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } // Fecha de la cita
        public string Time { get; set; }   // Hora (ej: "09:00")
        public string UserName { get; set; } // Nombre del cliente
    }
}