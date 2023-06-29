using InmueblesWeb.Models;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Security.Cryptography;

namespace InmueblesWeb.Data
{
    public class UsuarioData
    {
        public List<UsuarioModel> GetUsuarios()
        {
            var oLista = new List<UsuarioModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetConexionSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_GetUsuarios", conexion);
                cmd.Parameters.Add(new SqlParameter("IdUsuario", 0));
                cmd.CommandType = CommandType.StoredProcedure;


                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new UsuarioModel()
                        {
                            IdUsuario = (int)dr["IdUsuario"]
                            ,Nombre = (string)dr["Nombre"]
                            ,Paterno = (string)dr["Paterno"]
                            ,Materno = (string)dr["Materno"]
                            ,NombreUsuario = (string)dr["NombreUsuario"]
                            ,Email = (string)dr["Email"]
                            ,Movil = (string)dr["Movil"]
                            ,Activo = (int)dr["Activo"]
                        });
                    }
                }

            }

            return oLista;
        }

        public UsuarioModel GetUsuario(int idUsuario)
        {
            var oUsuario = new UsuarioModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetConexionSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_GetUsuarios", conexion);
                cmd.Parameters.Add(new SqlParameter("IdUsuario", idUsuario));
                cmd.CommandType = CommandType.StoredProcedure;


                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oUsuario.IdUsuario = (int)dr["IdUsuario"];
                        oUsuario.Nombre = (string)dr["Nombre"];
                        oUsuario.Paterno = (string)dr["Paterno"];
                        oUsuario.Materno = (string)dr["Materno"];
                        oUsuario.NombreUsuario = (string)dr["NombreUsuario"];
                        oUsuario.Email = (string)dr["Email"];
                        oUsuario.Movil = (string)dr["Movil"];
                        oUsuario.Movil = (string)dr["Password"];
                        oUsuario.Activo = (int)dr["Activo"];
                    }
                }

            }

            return oUsuario;
        }

        public bool SaveUsuario(UsuarioModel usuarioModel)
        {
            bool save;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetConexionSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("sp_SaveUsuario", conexion);
                    cmd.Parameters.Add(new SqlParameter("Nombre", usuarioModel.Nombre));
                    cmd.Parameters.Add(new SqlParameter("Paterno", usuarioModel.Paterno));
                    cmd.Parameters.Add(new SqlParameter("Materno", usuarioModel.Materno));
                    cmd.Parameters.Add(new SqlParameter("Email", usuarioModel.Email));
                    cmd.Parameters.Add(new SqlParameter("NombreUsuario", usuarioModel.NombreUsuario));
                    cmd.Parameters.Add(new SqlParameter("Movil", usuarioModel.Movil));
                    cmd.Parameters.Add(new SqlParameter("Password", ConvertirSha256(usuarioModel.Password)));
                    cmd.Parameters.Add(new SqlParameter("Activo", usuarioModel.Activo));
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                save = true;

            }
            catch (Exception)
            {
                save = false;
            }

            return save;
        }

        public bool EditUsuario(UsuarioModel usuarioModel)
        {
            bool save;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetConexionSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("sp_EditUsuario", conexion);
                    cmd.Parameters.Add(new SqlParameter("IdUsuario", usuarioModel.IdUsuario));
                    cmd.Parameters.Add(new SqlParameter("Nombre", usuarioModel.Nombre));
                    cmd.Parameters.Add(new SqlParameter("Paterno", usuarioModel.Paterno));
                    cmd.Parameters.Add(new SqlParameter("Materno", usuarioModel.Materno));
                    cmd.Parameters.Add(new SqlParameter("NombreUsuario", usuarioModel.NombreUsuario));
                    cmd.Parameters.Add(new SqlParameter("Email", usuarioModel.Email));
                    cmd.Parameters.Add(new SqlParameter("Movil", usuarioModel.Movil));
                    cmd.Parameters.Add(new SqlParameter("Password", ConvertirSha256(usuarioModel.Password)));
                    cmd.Parameters.Add(new SqlParameter("Activo", usuarioModel.Activo));
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                save = true;

            }
            catch (Exception)
            {
                save = false;
            }

            return save;
        }

        public bool DeleteUsuario(int IdUsuario, int activo)
        {
            bool save;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetConexionSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("sp_DeleteUsuario", conexion);
                    cmd.Parameters.Add(new SqlParameter("IdUsuario", IdUsuario));
                    cmd.Parameters.Add(new SqlParameter("Activo", activo));
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                save = true;

            }
            catch (Exception)
            {
                save = false;
            }

            return save;
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
