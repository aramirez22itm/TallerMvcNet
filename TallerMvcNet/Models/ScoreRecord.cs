using System;

namespace TallerMvcNet.Models
{
    public class ScoreRecord
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }  
        public int Moves { get; set; }          // Cuantos movimientos hizo
        public int TimeSeconds { get; set; }    // Cuanto tardó
        public int Score { get; set; }          
        public DateTime Date { get; set; }      
    }
}
