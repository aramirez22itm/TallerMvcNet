using System;

namespace TallerMvcNet.Models
{
    public class CalendarEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }      
        public DateTime Date { get; set; }     
        public TimeSpan Time { get; set; }     
        public int ReminderMinutes { get; set; }
        public string Details { get; set; }    
    }
}
