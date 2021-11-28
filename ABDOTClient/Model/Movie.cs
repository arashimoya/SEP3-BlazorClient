using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ABDOTClient.Model
{
    public class Movie
    {
    
      
        public int Id { get; private set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Genre { get; set; }
        
        [Required]
        public string Director { get; set; }
        
        [Required]
        public string Language { get; set; }

        [Required]
        public string SubtitleLanguage { get; set; }
        
        [Required]
        public int Year { get; set; }
        
        [Required]
        public int LengthInMinutes { get; set; }
        
        public string PosterSrc { get; set; }
        
    }
}