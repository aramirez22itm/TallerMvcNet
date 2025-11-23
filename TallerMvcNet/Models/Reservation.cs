using System;

namespace TallerMvcNet.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } 
        public string Time { get; set; }   
        public string UserName { get; set; } 
    }
}