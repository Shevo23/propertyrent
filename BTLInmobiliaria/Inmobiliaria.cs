using DALInmobiliaria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLInmobiliaria
{
    public class Inmobiliaria
    {
        DataInmobiliariaDataContext context = null;

        public Inmobiliaria(string conexion)
        {
            context = new DataInmobiliariaDataContext(conexion);
        }

        #region Delete

        public void DeleteArchivosArrendatario(int idArchivoArrendatario)
        {
            context.Connection.Open();

            context.sp_DeleteArchivosArrendatario(idArchivoArrendatario);

            context.Connection.Close();
        }

        public void DeleteArchivosArrendador(int idArchivoArrendador)
        {
            context.Connection.Open();

            context.sp_DeleteArchivosArrendador(idArchivoArrendador);

            context.Connection.Close();
        }

        public void DeleteArchivosInmueble(int idArchivoInmueble)
        {
            context.Connection.Open();

            context.sp_DeleteArchivosInmueble(idArchivoInmueble);

            context.Connection.Close();
        }

        public void DeleteImagenesInmueble(int idImagenInmueble)
        {
            context.Connection.Open();

            context.sp_DeleteImagenesInmueble(idImagenInmueble);

            context.Connection.Close();
        }

        #endregion

        #region Update

        public void UpdateArrendatario(int idArrendador, string nombres, string paterno, string materno, int edad, string ultimoGradoEstudio, string carreraOficio, int idAsentamiento, int numPersonasHabitar, int numPersonasDependen, int idEstadoCivil, string movil, string empresaTrabaja, int antiguedad, string horario, string direccionEmpleo,
                                      string fijo, string nombreJefe, string puestoEmpleo, decimal salarioMensual, string motivoCambio, string relacionFiador, string nombreFiador, string direccionFiador, string telefonoFiador, string movilFiador, int idEstadoCivilFiador, int tiempoMatrimonio,
                                      int edadFiador, string empresaTrabajaFiador, string direccionEmpleoFiador, string puestoEmpleoFiador, decimal salarioMensualFiador, int activo, int idTipoIdentificacion)
        {
            context.Connection.Open();

            context.sp_UpdateArrendatarios(idArrendador, nombres, paterno, materno, edad, ultimoGradoEstudio, carreraOficio, idAsentamiento, numPersonasHabitar, numPersonasDependen, idEstadoCivil, movil, empresaTrabaja, antiguedad, horario, direccionEmpleo,
                                        fijo, nombreJefe, puestoEmpleo, salarioMensual, motivoCambio, relacionFiador, nombreFiador, direccionFiador, telefonoFiador, movilFiador, idEstadoCivilFiador, tiempoMatrimonio,
                                        edadFiador, empresaTrabajaFiador, direccionEmpleoFiador, puestoEmpleoFiador, salarioMensualFiador, activo, idTipoIdentificacion);

            context.Connection.Close();
        }

        public void UpdateArrendador(int idArrendador, string nombres, string paterno, string materno, string email, string movil, string fijo, DateTime fechaBaja, int activo, int idTipoIdentificacion)
        {
            context.Connection.Open();

            context.sp_UpdateArrendador(idArrendador, nombres, paterno, materno, email, movil, fijo, fechaBaja, activo, idTipoIdentificacion);

            context.Connection.Close();
        }

        public void UpdateUsuariosInmuebles(int idUsuarioInmueble, int idUsuario)
        {
            context.Connection.Open();

            context.sp_UpdateUsuariosInmuebles(idUsuarioInmueble, idUsuario);

            context.Connection.Close();
        }

        public void UpdateDetalleInmuebles(int idDetalleInmueble, int numRecamaras, int numBanos, int numServicios, int numEstacionamientos, int conAlberca, int numM2, int numTotal)
        {
            context.Connection.Open();

            context.sp_UpdateDetalleInmuebles(idDetalleInmueble, numRecamaras, numBanos, numServicios, numEstacionamientos, conAlberca, numM2, numTotal);

            context.Connection.Close();
        }

        public void UpdateInmuebles(int idInmueble, string nombreInmueble, string descripcion, decimal latitud, decimal longitud, decimal costoTotal, decimal costoMensual, decimal costoMto, int nuevo, int antiguedad, int idTipoPropiedad, int idAsentamiento, int idEstatusInmueble, string calle)
        {
            context.Connection.Open();

            context.sp_UpdateInmuebles(idInmueble, nombreInmueble, descripcion, latitud, longitud, costoTotal, costoMensual, costoMto, nuevo, antiguedad, idTipoPropiedad, idAsentamiento, idEstatusInmueble, calle);

            context.Connection.Close();
        }

        #endregion

        #region Insert

        public void InsertArchivosArrendador(string nombreImagen, string ubicacionImagen, int idArrendador)
        {
            context.Connection.Open();

            context.sp_InsertArchivosArrendador(nombreImagen, ubicacionImagen, idArrendador);

            context.Connection.Close();
        }

        public void InsertArchivosArrendatario(string nombreImagen, string ubicacionImagen, int idArrendador)
        {
            context.Connection.Open();

            context.sp_InsertArchivosArrendatario(nombreImagen, ubicacionImagen, idArrendador);

            context.Connection.Close();
        }

        public void InsertArchivosArchivos(string nombreImagen, string ubicacionImagen, int idArrendador)
        {
            context.Connection.Open();

            context.sp_InsertArchivosArrendador(nombreImagen, ubicacionImagen, idArrendador);

            context.Connection.Close();
        }

        public void InsertArrendatario(string nombres, string paterno, string materno, int edad, string ultimoGradoEstudio, string carreraOficio, int idAsentamiento, int numPersonasHabitar, int numPersonasDependen, int idEstadoCivil, string movil, string empresaTrabaja, int antiguedad, string horario, string direccionEmpleo,
                                      string fijo, string nombreJefe, string puestoEmpleo, decimal salarioMensual, string motivoCambio, string relacionFiador, string nombreFiador, string direccionFiador, string telefonoFiador, string movilFiador, int idEstadoCivilFiador, int tiempoMatrimonio,
                                      int edadFiador, string empresaTrabajaFiador, string direccionEmpleoFiador, string puestoEmpleoFiador, decimal salarioMensualFiador, int activo, int idTipoIdentificacion)
        {
            context.Connection.Open();

            context.sp_InsertArrendatarios(nombres, paterno, materno, edad, ultimoGradoEstudio, carreraOficio, idAsentamiento, numPersonasHabitar, numPersonasDependen, idEstadoCivil, movil, empresaTrabaja, antiguedad, horario, direccionEmpleo,
                                        fijo, nombreJefe, puestoEmpleo, salarioMensual, motivoCambio, relacionFiador, nombreFiador, direccionFiador, telefonoFiador, movilFiador, idEstadoCivilFiador, tiempoMatrimonio,
                                        edadFiador, empresaTrabajaFiador, direccionEmpleoFiador, puestoEmpleoFiador, salarioMensualFiador, activo, idTipoIdentificacion);

            context.Connection.Close();
        }

        public void InsertArrendador(string nombres, string paterno, string materno, string email, string movil, string fijo, DateTime fechaAlta, int activo, int idTipoIdentificacion)
        {
            context.Connection.Open();

            context.sp_InsertArrendador(nombres, paterno, materno, email, movil, fijo, fechaAlta, activo, idTipoIdentificacion);

            context.Connection.Close();
        }

        public void InsertArchivosInmueble(string nombreImagen, string ubicacionImagen, int idInmueble)
        {
            context.Connection.Open();

            context.sp_InsertArchivosInmueble(nombreImagen, ubicacionImagen, idInmueble);

            context.Connection.Close();
        }

        public void InsertUsuariosInmuebles(int idUsuario, int idInmueble, DateTime fechaAlta)
        {
            context.Connection.Open();

            context.sp_InsertUsuariosInmuebles(idUsuario, idInmueble, fechaAlta);

            context.Connection.Close();
        }

        public void InsertImagenesInmueble(string nombreImagen, string ubicacionImagen, int idInmueble)
        {
            context.Connection.Open();

            context.sp_InsertImagenesInmueble(nombreImagen, ubicacionImagen, idInmueble);

            context.Connection.Close();
        }

        public void InsertDetalleInmuebles(int numRecamaras, int numBanos, int numServicios, int numEstacionamientos, int conAlberca, int numM2, int numTotal, int idInmueble)
        {
            context.Connection.Open();

            context.sp_InsertDetalleInmueble(numRecamaras, numBanos, numServicios, numEstacionamientos, conAlberca, numM2, numTotal, idInmueble);

            context.Connection.Close();
        }

        public int? InsertInmuebles(string nombreInmueble, string descripcion, decimal latitud, decimal longitud, decimal costoTotal, decimal costoMensual, decimal costoMto, int nuevo, int antiguedad, int idTipoPropiedad, int idAsentamiento, int idEstatusInmueble, string calle)
        {
            int? idInmueble = 0;

            context.Connection.Open();

            context.sp_InsertInmuebles(nombreInmueble, descripcion, latitud, longitud, costoTotal, costoMensual, costoMto, nuevo, antiguedad, idTipoPropiedad, idAsentamiento, idEstatusInmueble, calle, ref idInmueble);

            context.Connection.Close();

            return idInmueble;
        }

        #endregion

        #region Select

        public DataSet GetEstadoCivil()
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetEstadoCivil();

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        public DataSet GetArchivosArrendatario(int idArrendatario)
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetArchivosArrendatario(idArrendatario);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        public DataSet GetArchivosArrendador(int idArrendador)
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetArchivosArrendador(idArrendador);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        public DataSet GetArrendatarios(int idArrendatario)
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetArrendatarios(idArrendatario);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        public DataSet GetArrendadores(int idArrendador)
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetArrendadores(idArrendador);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        public DataSet GetArchivosInmueble(int idInmueble)
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetArchivosInmueble(idInmueble);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        public DataSet GetImagenesInmueble(int idInmueble)
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetImagenesInmueble(idInmueble);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        public DataSet GetInmuebles(int idInmueble)
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetInmuebles(idInmueble);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        public DataSet GetInmuebles()
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetInmuebles(0);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        #endregion
    }
}
