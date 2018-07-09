using System.Data.SqlClient; // dodajemo

namespace Trafika
{
    class Konekcija
    {
        public static SqlConnection KreirajKonekciju()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();

            connectionStringBuilder.DataSource = @"VUKAN\SQLEXPRESS";
            connectionStringBuilder.InitialCatalog = @"Trafika";
            connectionStringBuilder.IntegratedSecurity = true;

            SqlConnection Connection = new SqlConnection(connectionStringBuilder.ToString());

            return Connection;
        }
    }
}