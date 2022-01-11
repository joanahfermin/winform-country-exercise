using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace winform_country_exercise
{
    /// <summary>
    /// Utility classfor database operations.
    /// </summary>
    class DButil
    {
        /// <summary>
        /// The connection string to the database.  Change this to suit the setup of your machine machine.
        /// </summary>
        private static string CONNECTION_STRING = "server=localhost;database=joanahdb;User ID=jo;Password=jo;";

        /// <summary>
        /// Common method to connect to the database.  This is for exercise use only.  It needs to be improved for proper productionuse.
        /// </summary>
        public static SqlConnection getConnection()
        {
            SqlConnection cnn = new SqlConnection(CONNECTION_STRING);
            cnn.Open();

            return cnn;
        }
    }
}
