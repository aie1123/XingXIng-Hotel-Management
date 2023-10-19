using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StudentWeb.DAL
{
    public class ConnectionFactory
    {
        public static readonly string strConn = ConfigurationManager.ConnectionStrings["StudentDB"].ConnectionString;

        public static IDbConnection CreateConnection()
        {
            return new SqlConnection(strConn);
        }
    }
}
