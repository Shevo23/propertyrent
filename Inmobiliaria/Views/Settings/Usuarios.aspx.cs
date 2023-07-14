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
    public partial class Usuarios : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                GetUsuarios(0, 0);
            }
        }

        #region Methods

        private void GetUsuarios(int busqueda, int idUsuario)
        {
            BTLInmobiliaria.Catalogos catalogos = new BTLInmobiliaria.Catalogos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dtUsuario = new DataSet();

            try
            {
                if (busqueda == 0)
                {
                    dtUsuario = catalogos.GetUsuarios();

                    if (dtUsuario.Tables[0].Rows.Count > 0)
                    {
                        grdUsuarios.DataSource = dtUsuario;
                        grdUsuarios.DataBind();
                    }
                }
                else
                {
                    dtUsuario = catalogos.GetUsuarios(idUsuario);

                    if (dtUsuario.Tables[0].Rows.Count > 0)
                    {
                        txtNombre.Text = dtUsuario.Tables[0].Rows[0]["Nombre"].ToString();
                        txtPaterno.Text = dtUsuario.Tables[0].Rows[0]["Paterno"].ToString();
                        txtMaterno.Text = dtUsuario.Tables[0].Rows[0]["Materno"].ToString();
                        txtEmail.Text = dtUsuario.Tables[0].Rows[0]["Email"].ToString();
                        txtNombreUsuario.Text = dtUsuario.Tables[0].Rows[0]["NombreUsuario"].ToString();
                        txtMovil.Text = dtUsuario.Tables[0].Rows[0]["Movil"].ToString();
                        txtPassword.Text = dtUsuario.Tables[0].Rows[0]["Password"].ToString();
                        chk_Estatus.Checked = Convert.ToBoolean(dtUsuario.Tables[0].Rows[0]["Activo"]);
                    }
                }

                
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ViewState["oInsertar"] = true;


                lbl_Titulo.Text = "Agregar nuevo";
                txtNombre.Text = string.Empty;
                txtPaterno.Text = string.Empty;
                txtMaterno.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtNombreUsuario.Text = string.Empty;
                txtMovil.Text = string.Empty;
                txtPassword.Text = string.Empty;
                chk_Estatus.Checked = true;
                chk_Estatus.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            BTLInmobiliaria.Catalogos catalogos = new BTLInmobiliaria.Catalogos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());

            try
            {
                if (bool.Parse(ViewState["oInsertar"].ToString()))
                {
                    catalogos.InsertUsuario(txtNombre.Text.Trim(), txtPaterno.Text.Trim(), txtMaterno.Text.Trim(), txtEmail.Text.Trim(),txtNombreUsuario.Text.Trim(),txtPassword.Text.Trim(), txtMovil.Text.Trim());

                    //ShowMessage("El registro ha sido guardado exitosamente.", MessageType.Exito);

                    GetUsuarios(0, 0);

                }
                else
                {
                    catalogos.UpdateUsuario(int.Parse(ViewState["IdUsuario"].ToString()), txtNombre.Text.Trim(), txtPaterno.Text.Trim(), txtMaterno.Text.Trim(), txtEmail.Text.Trim(), txtNombreUsuario.Text.Trim(), txtPassword.Text.Trim(), txtMovil.Text.Trim(), Convert.ToInt32(chk_Estatus.Checked));

                    //ShowMessage("El registro ha sido actualizado exitosamente.", MessageType.Exito);

                    GetUsuarios(0, 0);
                }
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
                chk_Estatus.Enabled = true;

                ImageButton button = (ImageButton)sender;
                GridViewRow namingContainer = button.NamingContainer as GridViewRow;

                ViewState["IdUsuario"] = Convert.ToInt32(grdUsuarios.DataKeys[namingContainer.RowIndex].Values["IdUsuario"].ToString());

                GetUsuarios(1, int.Parse(ViewState["IdUsuario"].ToString()));
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
                ViewState["oInsertar"] = null;


                lbl_Titulo.Text = "Agregar nuevo";
                txtNombre.Text = string.Empty;
                txtPaterno.Text = string.Empty;
                txtMaterno.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtNombreUsuario.Text = string.Empty;
                txtMovil.Text = string.Empty;
                txtPassword.Text = string.Empty;
                chk_Estatus.Checked = true;
                chk_Estatus.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}