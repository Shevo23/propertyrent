using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inmobiliaria.Views.Settings
{
    public partial class Roles : System.Web.UI.Page
    {
        #region Methods

        private void GetRoles(int busqueda, int idRol)
        {
            BTLInmobiliaria.Catalogos catalogos = new BTLInmobiliaria.Catalogos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsRoles = new DataSet();

            try
            {
                if (busqueda == 0)
                {
                    dsRoles = catalogos.GetRoles(0);

                    if (dsRoles.Tables[0].Rows.Count > 0)
                    {
                        grdRoles.DataSource = dsRoles;
                        grdRoles.DataBind();
                    }
                }
                else
                {
                    dsRoles = catalogos.GetRoles(idRol);

                    if (dsRoles.Tables[0].Rows.Count > 0)
                    {
                        txtDescripcion.Text = dsRoles.Tables[0].Rows[0]["Descripcion"].ToString();
                    }
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
            if (!IsPostBack)
            {
                GetRoles(0, 0);
            }
        }

        protected void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                ViewState["oInsertar"] = true;

                lbl_Titulo.Text = "Agregar nuevo";
                txtDescripcion.Text = string.Empty;
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ibtnEditar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ViewState["oInsertar"] = false;

                lbl_Titulo.Text = "Editar";
                
                ImageButton button = (ImageButton)sender;
                GridViewRow namingContainer = button.NamingContainer as GridViewRow;

                ViewState["IdRol"] = Convert.ToInt32(grdRoles.DataKeys[namingContainer.RowIndex].Values["IdRol"].ToString());

                GetRoles(1, int.Parse(ViewState["IdRol"].ToString()));
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            BTLInmobiliaria.Catalogos catalogos = new BTLInmobiliaria.Catalogos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());

            try
            {
                if (bool.Parse(ViewState["oInsertar"].ToString()))
                {
                    catalogos.InsertRol(txtDescripcion.Text.Trim());

                    // ShowMessage("El registro ha sido guardado exitosamente.", MessageType.Exito);

                    GetRoles(0, 0);

                }
                else
                {
                    catalogos.UpdateRol(int.Parse(ViewState["IdRol"].ToString()), txtDescripcion.Text.Trim());

                    //ShowMessage("El registro ha sido actualizado exitosamente.", MessageType.Exito);

                    GetRoles(0, 0);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                ViewState["oInsertar"] = true;

                lbl_Titulo.Text = "Agregar nuevo";
                txtDescripcion.Text = string.Empty;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion


    }
}