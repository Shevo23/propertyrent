using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inmobiliaria.Views
{
    public partial class ReporteContratos : System.Web.UI.Page
    {
        #region Methods

        private void GetReporteContratos()
        {
            BTLInmobiliaria.Reportes reportes = new BTLInmobiliaria.Reportes(ConfigurationManager.ConnectionStrings["BDPropertyRent"].ToString());
            DataSet dsContratos = new DataSet();

            try
            {
                dsContratos = reportes.ReporteContratos();

                if (dsContratos.Tables[0].Rows.Count > 0)
                {
                    grdContratos.DataSource = dsContratos;
                    grdContratos.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                GetReporteContratos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Reporte_Contratos_" + DateTime.Now.ToShortDateString() + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            grdContratos.GridLines = GridLines.Both;
            grdContratos.HeaderStyle.Font.Bold = true;
            grdContratos.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }

        protected void grdContratos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdContratos.PageIndex = e.NewPageIndex;
            GetReporteContratos();
        }
    }
}