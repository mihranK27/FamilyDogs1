using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FamilyDogs.Services
{
    public abstract class BaseService
    {
        public static string GetConnection()
        {
            string Connection = "";
            Connection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return Connection;      
        }
    }
}   