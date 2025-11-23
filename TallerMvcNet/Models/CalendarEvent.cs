using System;

namespace TallerMvcNet.Models
{
    public class CalendarEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }      // Título del evento
        public DateTime Date { get; set; }     // Fecha
        public TimeSpan Time { get; set; }     // Hora exacta
        public int ReminderMinutes { get; set; }// Recordatorio (ej: 30 min antes)
        public string Details { get; set; }    // Detalles extra
    }
}
