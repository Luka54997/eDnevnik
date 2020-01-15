using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eDnevnik.Cassandra_Data_Layer;
using eDnevnik.Models;

namespace eDnevnik.Controllers
{
    public class StudentController : Controller
    {
        
        public ActionResult Index()
        {
            List<Student> students = DataProvider.GetStudents();

            var studentViewModel = new StudentViewModel() { Students = students };

            return View(studentViewModel);
        }

        public ActionResult Details(int id)
        {
            var student = DataProvider.GetStudent(id);
            var predmeti = DataProvider.GetPredmeti(id);

            var predmetViewModel = new PredmetViewModel() { Student = student, Predmeti = predmeti };

            return View(predmetViewModel);
        }

        public ActionResult New()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add(Student student)
        {
            List<Student> students = DataProvider.GetStudents();
            
            foreach(var studentIndex in students)
            {
                if(studentIndex.broj_indeksa == student.broj_indeksa)
                {
                    return Content("<script>alert('Student already exists');window.location.href = 'New'; </script>");
                    
                }
                
            }

            DataProvider.AddStudent(student);
            return RedirectToAction("Index","Student");
        }
    }

}