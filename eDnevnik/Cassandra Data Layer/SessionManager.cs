using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cassandra;

namespace eDnevnik.Cassandra_Data_Layer
{
    public static class SessionManager
    {
        public static ISession session;

        public static ISession GetSession()
        {
            if(session == null)
            {
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                session = cluster.Connect("dnevnik");
            }
            
            return session;
        }
    }
}