namespace TallerMvcNet.Models
{
    public class PasswordModel
    {
        public int Length { get; set; } = 12; // Longitud por defecto
        public bool IncludeLowercase { get; set; } = true;
        public bool IncludeUppercase { get; set; } = true;
        public bool IncludeNumbers { get; set; } = true;
        public bool IncludeSymbols { get; set; } = false;

        public string? GeneratedPassword { get; set; } // El resultado
    }
}