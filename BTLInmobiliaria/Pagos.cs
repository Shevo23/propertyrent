using DALInmobiliaria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLInmobiliaria
{
    public class Pagos
    {
        DataInmobiliariaDataContext context = null;

        public Pagos(string conexion)
        {
            context = new DataInmobiliariaDataContext(conexion);
        }

        #region Update

        public void UpdatePagoInmueble(decimal cantidad, string fechaPago, int idPagoInmueble)
        {
            context.Connection.Open();

            context.sp_UpdatePagosInmueble(cantidad, fechaPago, idPagoInmueble);

            context.Connection.Close();
        }

        #endregion

        #region Insert

        public void InsertPagoInmueble(int idTipoPago, decimal cantidad, string fechaPago, int idInmueble)
        {
            context.Connection.Open();

            context.sp_InsertPagosInmuebles(idTipoPago, cantidad, fechaPago, idInmueble);

            context.Connection.Close();
        }

        #endregion

        #region Select

        public DataSet GetTipoPago()
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetTipoPago();

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        public DataSet GetPagosInmueble(int idInmueble)
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetPagosInmuebles(idInmueble);

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }

        #endregion

    }
}
