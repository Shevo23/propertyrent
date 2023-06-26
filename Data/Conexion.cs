using System.Data.SqlClient;

namespace InmueblesWeb.Data
{
    public class Conexion
    {
        private readonly string conexionSQL = string.Empty;

        public Conexion()
        {
            var root = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            conexionSQL = root.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string GetConexionSQL()
        {
            return conexionSQL;
        }
    }
}
