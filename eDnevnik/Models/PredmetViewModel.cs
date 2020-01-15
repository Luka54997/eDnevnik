using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDnevnik.Models
{
    public class PredmetViewModel
    {
        public Student Student { get; set; }
        public List<Predmet> Predmeti { get; set; }
    }
}