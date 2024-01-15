﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inmobiliaria.Views.Settings
{
    public partial class TipoPropiedad : System.Web.UI.Page
    {
        #region Variables

        public enum MessageType { Exito, Error, Importante, Advertencia };

        #endregion

        #region Methods
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        private void GetTipoPropiedad(int busqueda, int idTipoPropiedad)
        {
            BTLInmobiliaria.Catalogos catalogos = new BTLInmobiliaria.Catalogos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsTipoPropiedad = new DataSet();

            try
            {
                if (busqueda == 0)
                {
                    dsTipoPropiedad = catalogos.GetTipoPropiedad(0);

                    if (dsTipoPropiedad.Tables[0].Rows.Count > 0)
                    {
                        grdTipoPropiedades.DataSource = dsTipoPropiedad;
                        grdTipoPropiedades.DataBind();
                    }
                }
                else
                {
                    dsTipoPropiedad = catalogos.GetTipoPropiedad(idTipoPropiedad);

                    if (dsTipoPropiedad.Tables[0].Rows.Count > 0)
                    {
                        txtDescripcion.Text = dsTipoPropiedad.Tables[0].Rows[0]["Descripcion"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GetTipoPropiedad(0, 0);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
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

                ViewState["IdTipoPropiedad"] = Convert.ToInt32(grdTipoPropiedades.DataKeys[namingContainer.RowIndex].Values["IdTipoPropiedad"].ToString());

                GetTipoPropiedad(1, int.Parse(ViewState["IdTipoPropiedad"].ToString()));
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
                    catalogos.InsertTipoPropiedad(txtDescripcion.Text.Trim());

                    ShowMessage("El registro ha sido guardado exitosamente.", MessageType.Exito);

                    GetTipoPropiedad(0, 0);

                }
                else
                {
                    catalogos.UpdateTipoPropiedad(int.Parse(ViewState["IdTipoPropiedad"].ToString()), txtDescripcion.Text.Trim());

                    ShowMessage("El registro ha sido actualizado exitosamente.", MessageType.Exito);

                    GetTipoPropiedad(0, 0);
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

        protected void grdTipoPropiedades_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTipoPropiedades.PageIndex = e.NewPageIndex;
            GetTipoPropiedad(0, 0);
        }
    }
}