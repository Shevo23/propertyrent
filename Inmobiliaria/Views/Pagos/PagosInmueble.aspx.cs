using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inmobiliaria.Views.Pagos
{
    public partial class PagosInmueble : System.Web.UI.Page
    {
        #region Variables

        public enum MessageType { Exito, Error, Importante, Advertencia };

        #endregion

        #region Methods

        private void GetTipoPago()
        {
            BTLInmobiliaria.Pagos pagos = new BTLInmobiliaria.Pagos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsTipoPago = new DataSet();

            try
            {
                dsTipoPago = pagos.GetTipoPago();

                if (dsTipoPago.Tables[0].Rows.Count > 0)
                {
                    cmbTipoPago.DataSource = dsTipoPago;
                    cmbTipoPago.DataValueField = "IdTipoPago";
                    cmbTipoPago.DataTextField = "Descripcion";
                    cmbTipoPago.DataBind();

                    cmbTipoPago.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetPagosInmueble(int idPagoInmueble, int idInmueble)
        {
            BTLInmobiliaria.Pagos pagos = new BTLInmobiliaria.Pagos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsPagos = new DataSet();

            try
            {
                if (idPagoInmueble == 0 && idInmueble != 0)
                {
                    dsPagos = pagos.GetPagosInmueble(idInmueble);

                    if (dsPagos.Tables[0].Rows.Count > 0)
                    {

                        grdPagosInmueble.DataSource = dsPagos;
                        grdPagosInmueble.DataBind();

                    }
                    else
                    {
                        grdPagosInmueble.DataBind();
                    }
                }
                else
                {
                    dsPagos = pagos.GetPagosInmueble(idInmueble);

                    if (dsPagos.Tables[0].Rows.Count > 0)
                    {
                        //string fecha = dsPagos.Tables[0].Rows[0]["FechaPago"].ToString();
                        //DateTime newDate = DateTime.ParseExact(fecha, "dd/MM/yyyy", null);

                        cmbTipoPago.SelectedValue = dsPagos.Tables[0].Rows[0]["IdTipoPago"].ToString();
                        txtCantidad.Text = dsPagos.Tables[0].Rows[0]["Cantidad"].ToString();
                        txtFechaPago.Text = dsPagos.Tables[0].Rows[0]["FechaPago"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        private void GetInmuebles()
        {
            BTLInmobiliaria.Contratos contratos = new BTLInmobiliaria.Contratos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsContratos = new DataSet();

            try
            {
                dsContratos = contratos.GetContratosActivos();

                if (dsContratos.Tables[0].Rows.Count > 0)
                {
                    cmbInmueble.DataSource = dsContratos;
                    cmbInmueble.DataValueField = "IdInmueble";
                    cmbInmueble.DataTextField = "NombreInmueble";
                    cmbInmueble.DataBind();

                    cmbInmueble.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));
                }

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        private void LimpiarControles()
        {
            cmbInmueble.SelectedIndex = 0;
            cmbTipoPago.SelectedIndex = 0;
            txtFechaPago.Text = string.Empty;
            txtCantidad.Text = string.Empty;

            grdPagosInmueble.DataSource = null;
            grdPagosInmueble.DataBind();

            btn_Agregar.Enabled = false;
            cmbTipoPago.Enabled = true;

            ViewState["IdInmueble"] = null;
        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    btn_Agregar.Enabled = false;

                    GetInmuebles();
                    GetTipoPago();
                }

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void cmbInmueble_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbInmueble.SelectedIndex != 0)
                {
                    btn_Agregar.Enabled = true;

                    GetPagosInmueble(0, int.Parse(cmbInmueble.SelectedValue));

                    ViewState["IdInmueble"] = cmbInmueble.SelectedValue;
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
                LimpiarControles();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            BTLInmobiliaria.Pagos pagos = new BTLInmobiliaria.Pagos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());

            try
            {
                int tipoPago = int.Parse(cmbTipoPago.SelectedItem.Value);
                int idInmueble = int.Parse(ViewState["IdInmueble"].ToString());
                decimal cantidad = decimal.Parse(txtCantidad.Text.Trim());

                if (bool.Parse(ViewState["oInsertar"].ToString()))
                {
                    pagos.InsertPagoInmueble(tipoPago, cantidad, txtFechaPago.Text, idInmueble);

                    ShowMessage("El registro ha sido guardado exitosamente.", MessageType.Exito);

                    GetPagosInmueble(0, idInmueble);

                    LimpiarControles();
                }
                else
                {
                    pagos.UpdatePagoInmueble(cantidad, txtFechaPago.Text, int.Parse(ViewState["IdPagoInmueble"].ToString()));

                    ShowMessage("El registro ha sido actualizado exitosamente.", MessageType.Exito);

                    GetPagosInmueble(0, idInmueble);

                }               
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }


        #endregion

        protected void ibtnEditar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ViewState["oInsertar"] = false;

                cmbTipoPago.Enabled = false;

                ImageButton button = (ImageButton)sender;
                GridViewRow namingContainer = button.NamingContainer as GridViewRow;

                ViewState["IdPagoInmueble"] = grdPagosInmueble.DataKeys[namingContainer.RowIndex].Values["IdPagoInmueble"].ToString();

                GetPagosInmueble(int.Parse(ViewState["IdPagoInmueble"].ToString()), int.Parse(ViewState["IdInmueble"].ToString()));

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
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }
    }
}