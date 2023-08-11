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

        #endregion

        #region Select

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
