using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALInmobiliaria;

namespace BTLInmobiliaria
{
    public class Catalogos
    {
        DataInmobiliariaDataContext context = null;

        public Catalogos(string conexion)
        {
            context = new DataInmobiliariaDataContext(conexion);
        }

        #region Ubicaciones

        public DataSet GetAsentamientos(int idMunicipio)
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetAsentamientos(idMunicipio);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        public DataSet GetMunicipios(int idEstado)
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetMunicipios(idEstado);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        public DataSet GetEstados()
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetEstados();

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        public DataSet GetPaises()
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetPaises();

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        #endregion

        #region EstatusInmueble

        public DataSet GetEstatusInmueble()
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetEstatusInmueble();

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        #endregion

        #region UsuariosRoles

        public void UpdateUsuariosRoles(int idUsuarioRol, int idUsuario, int idRol)
        {
            context.Connection.Open();

            context.sp_UpdateUsuariosRoles(idUsuarioRol, idUsuario, idRol);

            context.Connection.Close();
        }

        public void InsertUsuariosRoles(int idUsuario, int idRol)
        {
            context.Connection.Open();

            context.sp_InsertUsuariosRoles(idUsuario, idRol);

            context.Connection.Close();
        }

        public DataSet GetUsuariosRoles(int idUsuarioRol)
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetUsuariosRoles(idUsuarioRol);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        public DataSet GetUsuariosRoles()
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetUsuariosRoles(0);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        #endregion

        #region TipoIdentificacion

        public void UpdateTipoIdentificacion(int idTipoIdentificacion, string descripcion)
        {
            context.Connection.Open();

            context.sp_UpdateTipoIdentificacion(idTipoIdentificacion, descripcion);

            context.Connection.Close();
        }

        public void InsertTipoIdentificacion(string descripcion)
        {
            context.Connection.Open();

            context.sp_InsertTipoIdentificacion(descripcion);

            context.Connection.Close();
        }

        public DataSet GetTipoIdentificacion(int idTipoIdentificacion)
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetTiposIdentificacion(idTipoIdentificacion);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        public DataSet GetTipoIdentificacion()
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetTiposIdentificacion(0);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        #endregion

        #region TipoPropiedad

        public void UpdateTipoPropiedad(int idTipoPropiedad, string descripcion)
        {
            context.Connection.Open();

            context.sp_UpdateTipoPropiedad(idTipoPropiedad, descripcion);

            context.Connection.Close();
        }

        public void InsertTipoPropiedad(string descripcion)
        {
            context.Connection.Open();

            context.sp_InsertTipoPropiedad(descripcion);

            context.Connection.Close();
        }

        public DataSet GetTipoPropiedad(int idTipoPropiedad)
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetTipoPropiedad(idTipoPropiedad);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        public DataSet GetTipoPropiedad()
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetTipoPropiedad(0);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        #endregion

        #region Roles

        public void UpdateRol(int idRol, string descripcion)
        {
            context.Connection.Open();

            context.sp_UpdateRoles(idRol, descripcion);

            context.Connection.Close();
        }

        public void InsertRol(string descripcion)
        {
            context.Connection.Open();

            context.sp_InsertRoles(descripcion);

            context.Connection.Close();
        }

        public DataSet GetRoles(int idRol)
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetRoles(idRol);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        public DataSet GetRoles()
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetRoles(0);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        #endregion

        #region Usuarios

        public void UpdateUsuario(int idUsuario, string nombre, string paterno, string materno, string email, string nombreUsuario, string password, string movil, int activo)
        {
            context.Connection.Open();

            context.sp_UpdateUsuario(idUsuario, nombre, paterno, materno, email, nombreUsuario, password, movil, activo);

            context.Connection.Close();
        }

        public void InsertUsuario(string nombre, string paterno, string materno, string email, string nombreUsuario, string password, string movil)
        {
            context.Connection.Open();

            context.sp_InsertUsuario(nombre, paterno, materno, email, nombreUsuario, password, movil, 1);

            context.Connection.Close();
        }

        public DataSet GetUsuarioPermisos(int idUsuario)
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetUsuarioPermisos(idUsuario);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        public DataSet GetValidaUsuario(string email, string password)
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetValidaUsuario(email, password);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        public DataSet GetUsuarios(int idUsuario)
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetUsuarios(idUsuario);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        public DataSet GetUsuarios()
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetUsuarios(0);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        #endregion


    }
}
