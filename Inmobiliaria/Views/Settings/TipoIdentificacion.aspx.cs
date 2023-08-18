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
    public partial class TipoIdentificacion : System.Web.UI.Page
    {
        #region Variables
        public enum MessageType { Exito, Error, Importante, Advertencia };

        #endregion

        #region Methods
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        private void GetTipoIdentificacion(int busqueda, int idTipoIdentificacion)
        {
            BTLInmobiliaria.Catalogos catalogos = new BTLInmobiliaria.Catalogos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsTipoIdentificacion = new DataSet();

            try
            {
                if (busqueda == 0)
                {
                    dsTipoIdentificacion = catalogos.GetTipoIdentificacion(0);

                    if (dsTipoIdentificacion.Tables[0].Rows.Count > 0)
                    {
                        grdTipoIdentificacion.DataSource = dsTipoIdentificacion;
                        grdTipoIdentificacion.DataBind();
                    }
                }
                else
                {
                    dsTipoIdentificacion = catalogos.GetTipoIdentificacion(idTipoIdentificacion);

                    if (dsTipoIdentificacion.Tables[0].Rows.Count > 0)
                    {
                        txtDescripcion.Text = dsTipoIdentificacion.Tables[0].Rows[0]["Descripcion"].ToString();
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
                GetTipoIdentificacion(0, 0);
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
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
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

                ViewState["IdTipoIdentificacion"] = Convert.ToInt32(grdTipoIdentificacion.DataKeys[namingContainer.RowIndex].Values["IdTipoIdentificacion"].ToString());

                GetTipoIdentificacion(1, int.Parse(ViewState["IdTipoIdentificacion"].ToString()));
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            BTLInmobiliaria.Catalogos catalogos = new BTLInmobiliaria.Catalogos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());

            try
            {
                if (bool.Parse(ViewState["oInsertar"].ToString()))
                {
                    catalogos.InsertTipoIdentificacion(txtDescripcion.Text.Trim());

                    ShowMessage("El registro ha sido guardado exitosamente.", MessageType.Exito);

                    GetTipoIdentificacion(0, 0);

                }
                else
                {
                    catalogos.UpdateTipoIdentificacion(int.Parse(ViewState["IdTipoIdentificacion"].ToString()), txtDescripcion.Text.Trim());

                    ShowMessage("El registro ha sido actualizado exitosamente.", MessageType.Exito);

                    GetTipoIdentificacion(0, 0);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
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
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        #endregion


    }
}