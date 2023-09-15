using DALInmobiliaria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLInmobiliaria
{
    public class Reportes
    {
        DataInmobiliariaDataContext context = null;

        public Reportes(string conexion)
        {
            context = new DataInmobiliariaDataContext(conexion);
        }

        public DataSet ReporteContratos()
        {
            DataTable data;

            context.Connection.Open();

            var dsResult = context.sp_GetReporteContratos();

            data = dsResult.CopyToDataTable();

            context.Connection.Close();

            DataSet resultDataSet = new DataSet();

            resultDataSet.Tables.Add(data);

            return resultDataSet;
        }
    }
}
