using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Restanta_Saniuta_Robert.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Movie Title")]
        public string Title { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele autorului trebuie sa fie de forma 'Prenume Nume'"), Required, StringLength(50,
MinimumLength = 3)]

        public string Regizor { get; set; }

        [Range(1, 10)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Rating { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public int ProductionID { get; set; }
        public Production Production { get; set; }

        public ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
