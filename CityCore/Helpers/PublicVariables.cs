using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CityCore.Helpers
{
    public static class PublicVariables
    {
        /// <summary>
        /// Application id for the admin panel application
        /// </summary>
        public static DataRow drClient;

        /// <summary>
        /// Logged in user
        /// </summary>
        public static DataRow drUser;
        
        /// <summary>
        /// Company data
        /// </summary>
        public static DataRow drCompany;

        /// <summary>
        /// Connection string to the database
        /// </summary>
        public static string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["CityCoreConStr"].ConnectionString;


    }
}