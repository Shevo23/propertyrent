using InmueblesWeb.Models;
using System.Data;
using System.Data.SqlClient;

namespace InmueblesWeb.Data
{
    public class TipoPropiedadData
    {
        public bool EditTipoPropiedad(TipoPropiedadModel tipoPropiedadModel)
        {
            bool save;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetConexionSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("sp_EditTipoPropiedad", conexion);
                    cmd.Parameters.Add(new SqlParameter("IdTipoPropiedad", tipoPropiedadModel.IdTipoPropiedad));
                    cmd.Parameters.Add(new SqlParameter("Descripcion", tipoPropiedadModel.Descripcion));
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

        public bool SaveTipoPropiedad(TipoPropiedadModel tipoPropiedadModel)
        {
            bool save;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetConexionSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("sp_SaveTipoPropiedad", conexion);
                    cmd.Parameters.Add(new SqlParameter("Descripcion", tipoPropiedadModel.Descripcion));
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

        public TipoPropiedadModel GetTipoPropiedad(int idTipoPropiedad)
        {
            var oRol = new TipoPropiedadModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetConexionSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_GetTipoPropiedad", conexion);
                cmd.Parameters.Add(new SqlParameter("IdTipoPropiedad", idTipoPropiedad));
                cmd.CommandType = CommandType.StoredProcedure;


                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oRol.IdTipoPropiedad = (int)dr["IdTipoPropiedad"];
                        oRol.Descripcion = (string)dr["Descripcion"];
                    }
                }

            }

            return oRol;
        }

        public List<TipoPropiedadModel> GetTipoPropiedad()
        {
            var oLista = new List<TipoPropiedadModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetConexionSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_GetTipoPropiedad", conexion);
                cmd.Parameters.Add(new SqlParameter("IdTipoPropiedad", 0));
                cmd.CommandType = CommandType.StoredProcedure;


                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new TipoPropiedadModel()
                        {
                            IdTipoPropiedad = (int)dr["IdTipoPropiedad"]
                            ,Descripcion = (string)dr["Descripcion"]
                        });
                    }
                }

            }

            return oLista;
        }

    }
}
