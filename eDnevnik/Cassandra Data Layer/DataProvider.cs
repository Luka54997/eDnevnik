using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eDnevnik.Models;
using Cassandra;

namespace eDnevnik.Cassandra_Data_Layer
{
    public static class DataProvider
    {
        #region Student 

        public static Student GetStudent(int brIndeksa)
        {
            ISession session = SessionManager.GetSession();

            Student student = new Student();

            if (session == null)
                return null;

            Row studentData = session.Execute("select * from student where broj_indeksa = " + brIndeksa + "").FirstOrDefault();

            if(studentData != null)
            {
                student.broj_indeksa = Convert.ToInt32( studentData["broj_indeksa"]);
                student.adress = studentData["address"].ToString() ?? string.Empty;
                student.first_name = studentData["first_name"].ToString() ?? string.Empty;
                student.last_name = studentData["last_name"].ToString() ?? string.Empty;
                student.e_mail = studentData["e_mail"].ToString() ?? string.Empty;
            }
            return student;

        }

        public static List<Student> GetStudents()
        {
            ISession session = SessionManager.GetSession();

            
            List<Student> students = new List<Student>();

            if (session == null)
                return null;

            var studentsData = session.Execute("select * from student");

            foreach(var studentData in studentsData)
            {
                Student student = new Student();
                student.broj_indeksa = Convert.ToInt32(studentData["broj_indeksa"]);
                student.adress = studentData["broj_indeksa"].ToString() ?? string.Empty;
                student.first_name = studentData["first_name"].ToString() ?? string.Empty;
                student.last_name = studentData["last_name"].ToString() ?? string.Empty;
                student.e_mail = studentData["e_mail"].ToString() ?? string.Empty;

                students.Add(student);
            }
            return students;
        }

        public static void AddStudent(Student student)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;        
                      

            RowSet studentQuery = session.Execute("insert into student(broj_indeksa,address,e_mail,first_name,last_name) values(" + student.broj_indeksa + ",'" + student.adress + "','" + student.e_mail + "','" + student.first_name + "','" + student.last_name + "')");
        }

        #endregion

        #region Predmet

        public static List<Predmet> GetPredmeti(int broj_indeksa)
        {
            ISession session = SessionManager.GetSession();
            List<Predmet> predmeti = new List<Predmet>();

            if (session == null)
                return null;

            var predmetiData = session.Execute("select * from predmet where broj_indeksa = " + broj_indeksa + " ");

            foreach(var predmetData in predmetiData)
            {
                Predmet predmet = new Predmet();
                predmet.broj_indeksa = Convert.ToInt32(predmetData["broj_indeksa"]);
                predmet.id_predmeta = Convert.ToInt32(predmetData["id_predmeta"]);
                predmet.espb_bodovi = Convert.ToInt32(predmetData["espb_bodovi"]);
                predmet.ocena = Convert.ToInt32(predmetData["ocena"]);
                predmet.naziv = predmetData["naziv"].ToString() ?? string.Empty;
                predmet.ime_predavaca = predmetData["ime_predavaca"].ToString() ?? string.Empty;

                predmeti.Add(predmet);

            }

            return predmeti;

        }

        public static List<Predmet> GetPredmetiById(int id)
        {
            ISession session = SessionManager.GetSession();
            List<Predmet> predmeti = new List<Predmet>();

            if (session == null)
                return null;

            var predmetiData = session.Execute("select * from predmet where id_predmeta = " + id + " ALLOW FILTERING ");

            foreach (var predmetData in predmetiData)
            {
                Predmet predmet = new Predmet();
                predmet.broj_indeksa = Convert.ToInt32(predmetData["broj_indeksa"]);
                predmet.id_predmeta = Convert.ToInt32(predmetData["id_predmeta"]);
                predmet.espb_bodovi = Convert.ToInt32(predmetData["espb_bodovi"]);
                predmet.ocena = Convert.ToInt32(predmetData["ocena"]);
                predmet.naziv = predmetData["naziv"].ToString() ?? string.Empty;
                predmet.ime_predavaca = predmetData["ime_predavaca"].ToString() ?? string.Empty;

                predmeti.Add(predmet);
                break;

            }

            return predmeti;

        }

        public static Predmet GetPredmet(int idPredmeta, int brIndeksa)
        {
            ISession session = SessionManager.GetSession();

            Predmet predmet = new Predmet();

            Row predmetData = session.Execute("select * from predmet where id_predmeta =" + idPredmeta + " and broj_indeksa = " + brIndeksa + "; ").FirstOrDefault();

            if (session == null)
                return null;

            if(predmetData != null)
            {
                predmet.broj_indeksa = Convert.ToInt32(predmetData["broj_indeksa"]);
                predmet.espb_bodovi = Convert.ToInt32(predmetData["espb_bodovi"]);
                predmet.id_predmeta = Convert.ToInt32(predmetData["id_predmeta"]);
                predmet.ocena = Convert.ToInt32(predmetData["ocena"]);
                predmet.ime_predavaca = predmetData["ime_predavaca"].ToString() ?? string.Empty;
                predmet.naziv = predmetData["naziv"].ToString() ?? string.Empty;
            }
                     

            return predmet;
            
        }

        public static void AddPredmet(Predmet predmet)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            var predmetData = session.Execute("insert into predmet(broj_indeksa,id_predmeta,espb_bodovi,ime_predavaca,naziv,ocena) values(" + predmet.broj_indeksa + ","+predmet.id_predmeta+","+predmet.espb_bodovi+",'"+predmet.ime_predavaca+"','"+predmet.naziv+"',"+predmet.ocena+")");
        }

        public static void DeletePredmet(int id,Predmet predmet)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            var predmetData = session.Execute("delete from predmet where id_predmeta = " + id + " and broj_indeksa = "+predmet.broj_indeksa+";");
        }

       

        #endregion
    }
}