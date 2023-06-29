using InmueblesWeb.Models;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace InmueblesWeb.Data
{
    public class LoginData
    {
        public int ValidaUsuario(LoginModel loginModel)
        {

            loginModel.Password = ConvertirSha256(loginModel.Password);

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetConexionSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_ValidaUsuario", conexion);
                cmd.Parameters.Add(new SqlParameter("Email", loginModel.Email));
                cmd.Parameters.Add(new SqlParameter("Password", loginModel.Password));
                cmd.CommandType = CommandType.StoredProcedure;

                var result = cmd.ExecuteScalar();


                loginModel.IdUsuario = result == null ? 0 : (int)result;

            }

            return loginModel.IdUsuario;
        }

        public static string ConvertirSha256(string texto)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
