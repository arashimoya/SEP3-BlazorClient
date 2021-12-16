using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ABDOTClient.Model
{
    public class Movie
    {
    
      
        public int Id { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "Enter valid title")]
        [MinLength(1, ErrorMessage = "Enter valid title")]
        public string Title { get; set; }
        
        [Required]
        [StringLength(1000, ErrorMessage = "Enter valid description")]
        [MinLength(5, ErrorMessage = "Enter valid description")]
        public string Description { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "Enter valid street")]
        [MinLength(4, ErrorMessage = "Enter valid street")]
        public string Genre { get; set; }
        
        [Required]
        [StringLength(25, ErrorMessage = "Enter valid director")]
        [MinLength(5, ErrorMessage = "Enter valid director")]
        public string Director { get; set; }
        
        [Required]
        [StringLength(30, ErrorMessage = "Enter valid language")]
        [MinLength(2, ErrorMessage = "Enter valid language")]
        public string Language { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Enter valid subtitle language")]
        [MinLength(3, ErrorMessage = "Enter valid subtitle language")]
        public string SubtitleLanguage { get; set; }
        
        [Required]
        [Range(1800, 2500, ErrorMessage = "enter valid year")]
        public int Year { get; set; }
        
        [Required]
        public int LengthInMinutes { get; set; }
        
        public string PosterSrc { get; set; }

        public override string ToString()
        {
            string returnString = "Movie{\nId : " + Id + "\nTitle : " + Title + "\nDescription : " + Description + "\nGenre : " +
                                  Genre
                                  + "\nDirector : " + Director + "\nLanguage : " + Language + "\nSubtitleLanguage : " +
                                  SubtitleLanguage + "\nYear : " + Year
                                  + "\nLengthInMinutes : " + LengthInMinutes + "\nPosterSrc : " + PosterSrc  + "\n}";
            return returnString;
        }
    }
}