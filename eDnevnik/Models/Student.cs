using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eDnevnik.Models
{
    public class Student
    {
        [Required]
        [Display(Name = "Index number")]
        public int broj_indeksa { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string first_name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }

        [Required]
        [Display(Name = "Adress")]
        public string adress { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public string e_mail { get; set; }
    }
}