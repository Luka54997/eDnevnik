using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eDnevnik.Models;
using eDnevnik.Cassandra_Data_Layer;

namespace eDnevnik.Controllers.Api
{
    public class SubjectsController : ApiController
    {
        [HttpDelete]
        public void DeleteSubject(int id,int brIndeksa )
        {
            var predmet = DataProvider.GetPredmet(id, brIndeksa);
            DataProvider.DeletePredmet(id, predmet);
        }
    }
}
