using InmueblesWeb.Models;
using System.Data;
using System.Data.SqlClient;

namespace InmueblesWeb.Data
{
    public class TipoIdentificacionData
    {
        public bool EditTipoIdentificacion(TipoIdentificacionModel tipoIdentificacionModel)
        {
            bool save;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetConexionSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("sp_EditTiposIdentificacion", conexion);
                    cmd.Parameters.Add(new SqlParameter("IdTipoIdentificacion", tipoIdentificacionModel.IdTipoIdentificacion));
                    cmd.Parameters.Add(new SqlParameter("Descripcion", tipoIdentificacionModel.Descripcion));
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

        public bool SaveTipoIdentificacion(TipoIdentificacionModel tipoIdentificacionModel)
        {
            bool save;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetConexionSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("sp_SaveTiposIdentificacion", conexion);
                    cmd.Parameters.Add(new SqlParameter("Descripcion", tipoIdentificacionModel.Descripcion));
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

        public TipoIdentificacionModel GetTipoIdentificacion(int idTipoIdentificacion)
        {
            var oTipo = new TipoIdentificacionModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetConexionSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_GetListTiposIdentificacion", conexion);
                cmd.Parameters.Add(new SqlParameter("IdTipoIdentificacion", idTipoIdentificacion));
                cmd.CommandType = CommandType.StoredProcedure;


                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oTipo.IdTipoIdentificacion = (int)dr["IdTipoIdentificacion"];
                        oTipo.Descripcion = (string)dr["Descripcion"];
                    }
                }

            }

            return oTipo;
        }

        public List<TipoIdentificacionModel> GetTipoIdentificacion()
        {
            var oLista = new List<TipoIdentificacionModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetConexionSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_GetListTiposIdentificacion", conexion);
                cmd.Parameters.Add(new SqlParameter("IdTipoIdentificacion", 0));
                cmd.CommandType = CommandType.StoredProcedure;


                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new TipoIdentificacionModel()
                        {
                            IdTipoIdentificacion = (int)dr["IdTipoIdentificacion"]
                            ,Descripcion = (string)dr["Descripcion"]
                        });
                    }
                }

            }

            return oLista;
        }

    }
}
