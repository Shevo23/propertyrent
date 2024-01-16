using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inmobiliaria.Master
{
    public partial class Site : System.Web.UI.MasterPage
    {
        #region Variables

        #endregion

        #region Methods

        private void MuestraMenu(string usuario)
        {
            BTLInmobiliaria.Catalogos catalogos = new BTLInmobiliaria.Catalogos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dataSet = new DataSet();
            string perfil;

            try
            {
                dataSet = catalogos.GetUsuarioPermisos(int.Parse(usuario));

                perfil = dataSet.Tables[0].Rows[0]["Descripcion"].ToString();

                lblUsuario.InnerText = dataSet.Tables[0].Rows[0]["Nombre"].ToString();
                lblRol.InnerText = dataSet.Tables[0].Rows[0]["Descripcion"].ToString();
                Session["IdUsuario"] = dataSet.Tables[0].Rows[0]["IdUsuario"].ToString();

                switch (perfil)
                {
                    case "Administrador":

                        menuContratos.Visible = true;
                        menuConfiguracion.Visible = true;
                        menuInmuebles.Visible = true;
                        menuPagos.Visible = true;
                        menuReportes.Visible = true;

                        break;
                    case "Gerente":

                        menuContratos.Visible = true;
                        menuConfiguracion.Visible = false;
                        menuInmuebles.Visible = true;
                        menuPagos.Visible = false;
                        menuReportes.Visible = false;

                        break;
                    case "Soporte":

                        menuContratos.Visible = true;
                        menuConfiguracion.Visible = true;
                        menuInmuebles.Visible = true;
                        menuPagos.Visible = true;
                        menuReportes.Visible = true;

                        break;
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            else if (!string.IsNullOrEmpty(Session["IdUsuario"].ToString()))
            {
                MuestraMenu(Session["IdUsuario"].ToString());
            }
        }

        protected void lnkSalir_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();

                Response.Redirect("~/Views/Login.aspx");
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion



    }
}