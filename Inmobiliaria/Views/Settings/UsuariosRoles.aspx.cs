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
    public partial class UsuariosRoles : System.Web.UI.Page
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
                        cmbRoles.DataSource = dsRoles;
                        cmbRoles.DataValueField = "IdRol";
                        cmbRoles.DataTextField = "Descripcion";
                        cmbRoles.DataBind();

                        cmbRoles.Items.Insert(0, new ListItem("Seleccione..."));
                    }
                }
                else
                {
                    dsRoles = catalogos.GetRoles(idRol);

                    if (dsRoles.Tables[0].Rows.Count > 0)
                    {
                        cmbUsuarios.SelectedValue = dsRoles.Tables[0].Rows[0]["IdRol"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

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
                        
                        cmbUsuarios.DataSource = dtUsuario;
                        cmbUsuarios.DataValueField = "IdUsuario";
                        cmbUsuarios.DataTextField = "Nombre";
                        cmbUsuarios.DataBind();
                        cmbUsuarios.Items.Insert(0, new ListItem("Seleccione..."));
                    }
                }
                else
                {
                    dtUsuario = catalogos.GetUsuarios(idUsuario);

                    if (dtUsuario.Tables[0].Rows.Count > 0)
                    {
                        cmbUsuarios.SelectedValue = dtUsuario.Tables[0].Rows[0]["IdUsuario"].ToString();
                        
                    }
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetUsuariosRoles(int busqueda, int idUsuarioRol)
        {
            BTLInmobiliaria.Catalogos catalogos = new BTLInmobiliaria.Catalogos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsUsuariosRoles = new DataSet();

            try
            {
                if (busqueda == 0)
                {
                    dsUsuariosRoles = catalogos.GetUsuariosRoles(0);

                    if (dsUsuariosRoles.Tables[0].Rows.Count > 0)
                    {
                        grdUsuariosRoles.DataSource = dsUsuariosRoles;
                        grdUsuariosRoles.DataBind();
                    }
                }
                else
                {
                    dsUsuariosRoles = catalogos.GetUsuariosRoles(idUsuarioRol);

                    if (dsUsuariosRoles.Tables[0].Rows.Count > 0)
                    {
                        cmbUsuarios.SelectedValue = dsUsuariosRoles.Tables[0].Rows[0]["IdUsuario"].ToString();
                        cmbRoles.SelectedValue = dsUsuariosRoles.Tables[0].Rows[0]["IdRol"].ToString();
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
                GetUsuariosRoles(0, 0);
                GetUsuarios(0, 0);
                GetRoles(0, 0);
            }
        }

        protected void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                ViewState["oInsertar"] = true;

                lbl_Titulo.Text = "Agregar nuevo";
                cmbUsuarios.SelectedIndex = 0;
                cmbRoles.SelectedIndex = 0;

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

                ViewState["IdUsuarioRol"] = Convert.ToInt32(grdUsuariosRoles.DataKeys[namingContainer.RowIndex].Values["IdUsuarioRol"].ToString());

                GetUsuariosRoles(1, int.Parse(ViewState["IdUsuarioRol"].ToString()));
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            BTLInmobiliaria.Catalogos catalogos = new BTLInmobiliaria.Catalogos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());

            var idUsuario = int.Parse(cmbUsuarios.SelectedValue);
            var idRol = int.Parse(cmbRoles.SelectedValue);

            try
            {
                if (bool.Parse(ViewState["oInsertar"].ToString()))
                {
                    

                    catalogos.InsertUsuariosRoles(idUsuario, idRol);

                    // ShowMessage("El registro ha sido guardado exitosamente.", MessageType.Exito);

                    GetUsuariosRoles(0, 0);

                }
                else
                {
                    catalogos.UpdateUsuariosRoles(int.Parse(ViewState["IdUsuarioRol"].ToString()), idUsuario, idRol);

                    //ShowMessage("El registro ha sido actualizado exitosamente.", MessageType.Exito);

                    GetUsuariosRoles(0, 0);
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
                ViewState["oInsertar"] = null;

                lbl_Titulo.Text = "Agregar nuevo";
                cmbUsuarios.SelectedIndex = 0;
                cmbRoles.SelectedIndex = 0;
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        protected void grdUsuariosRoles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUsuariosRoles.PageIndex = e.NewPageIndex;
            GetUsuariosRoles(0, 0);
        }
    }
}