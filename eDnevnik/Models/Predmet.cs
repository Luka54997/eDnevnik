using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eDnevnik.Models
{
    public class Predmet
    {
        [Required]
        [Display(Name = "Index number")]
        public int broj_indeksa { get; set; }

        [Required]
        [Display(Name = "Subject id")]
        public int id_predmeta { get; set; }

        [Required]
        [Display(Name = "ESPB points")]
        public int espb_bodovi { get; set; }

        [Required]
        [Display(Name = "Professor")]
        public string ime_predavaca { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string naziv { get; set; }

        [Required]
        [Display(Name = "Grade")]
        public int ocena { get; set; }
    }
}