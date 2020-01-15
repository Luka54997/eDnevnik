using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eDnevnik.Models;
using eDnevnik.Cassandra_Data_Layer;

namespace eDnevnik.Controllers
{
    public class PredmetController : Controller
    {
       
        public ActionResult Details(int id)
        {

            List<Predmet> predmeti = DataProvider.GetPredmetiById(id);

            var predmetViewModel = new PredmetViewModel() { Predmeti = predmeti };


            return View(predmetViewModel);
        }


        public ActionResult New()
        {
            return View();
        }

        public ActionResult Add(Predmet predmet)
        {
            
            DataProvider.AddPredmet(predmet);
            return RedirectToAction("Details","Student",new { id = predmet.broj_indeksa});
        }
        
    }


}