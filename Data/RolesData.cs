using InmueblesWeb.Models;
using System.Data;
using System.Data.SqlClient;

namespace InmueblesWeb.Data
{
    public class RolesData
    {
        public bool EditRol(RolesModel rolesModel)
        {
            bool save;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetConexionSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("sp_EditRoles", conexion);
                    cmd.Parameters.Add(new SqlParameter("IdRol", rolesModel.IdRol));
                    cmd.Parameters.Add(new SqlParameter("Descripcion", rolesModel.Descripcion));
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

        public bool SaveRol(RolesModel rolesModel)
        {
            bool save;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetConexionSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("sp_SaveRoles", conexion);
                    cmd.Parameters.Add(new SqlParameter("Descripcion", rolesModel.Descripcion));
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

        public RolesModel GetRol(int idRol)
        {
            var oRol = new RolesModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetConexionSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_GetRoles", conexion);
                cmd.Parameters.Add(new SqlParameter("IdRol", idRol));
                cmd.CommandType = CommandType.StoredProcedure;


                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oRol.IdRol = (int)dr["IdRol"];
                        oRol.Descripcion = (string)dr["Descripcion"];   
                    }
                }

            }

            return oRol;
        }

        public List<RolesModel> GetRoles() 
        {
            var oLista = new List<RolesModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetConexionSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_GetRoles", conexion);
                cmd.Parameters.Add(new SqlParameter("IdRol", 0));
                cmd.CommandType = CommandType.StoredProcedure;


                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new RolesModel()
                        {
                            IdRol = (int)dr["IdRol"]
                            ,Descripcion = (string)dr["Descripcion"]
                        });
                    }
                }

            }

            return oLista;
        }

    }
}
