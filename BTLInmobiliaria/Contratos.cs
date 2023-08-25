using DALInmobiliaria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLInmobiliaria
{
    public class Contratos
    {
        DataInmobiliariaDataContext context = null;

        public Contratos(string conexion)
        {
            context = new DataInmobiliariaDataContext(conexion);
        }

        #region Delete

        #endregion

        #region Update

        #endregion

        #region Insert

        public void InsertArchivoCartas(string nombreImagen, string ubicacionImagen, int idContrato)
        {
            context.Connection.Open();

            context.sp_InsertArchivosCartas(nombreImagen, ubicacionImagen, idContrato);

            context.Connection.Close();
        }

        public void InsertArchivoContrato(string nombreImagen, string ubicacionImagen, int IdContrato)
        {
            context.Connection.Open();

            context.sp_InsertArchivosContratos(nombreImagen, ubicacionImagen, IdContrato);

            context.Connection.Close();
        }

        public int? InserContrato(string numContrato, int contratoMeses, int contratoAnio, string fechaVigenciaInicio, string fechaVigenciaFin, int idArrendador, int idArrendatario, int idInmueble, int idUsuario)
        {
            int? idContrato = 0;

            context.Connection.Open();

            context.sp_InsertContratos(numContrato, contratoMeses, contratoAnio, fechaVigenciaInicio, fechaVigenciaFin, idArrendador, idArrendatario, idInmueble, idUsuario, ref idContrato);

            context.Connection.Close();

            return idContrato;
        }

        #endregion

        #region Select

        public DataSet GetNumeroContrato()
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetNumeroContrato();

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        public DataSet GetContratos()
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetContratos();

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        #endregion

    }
}
