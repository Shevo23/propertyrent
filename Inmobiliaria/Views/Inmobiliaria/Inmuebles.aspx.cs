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
    public partial class Inmuebles : System.Web.UI.Page
    {
        #region Variables

        public enum MessageType { Exito, Error, Importante, Advertencia };

        #endregion

        #region Methods

        private void LimpiarControles()
        {
            try
            {
                txtNombreInmueble.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                txtCostoTotal.Text = string.Empty;
                txtCostoMensual.Text = string.Empty;
                txtCostoMantenimiento.Text = string.Empty;
                txtAntiguedad.Text = string.Empty;
                cmbTipoPropiedad.SelectedIndex = 0;
                cmbEstado.SelectedIndex = 0;
                cmbMunicipio.SelectedIndex = 0;
                cmbAsentamiento.SelectedIndex = 0;
                cmbEstatusInmueble.SelectedIndex = 0;
                txtNumRecamaras.Text = string.Empty;
                txtNumBanos.Text = string.Empty;
                txtNumServicios.Text = string.Empty;
                txtNumEstacionamiento.Text = string.Empty;
                txtNumM2.Text = string.Empty;
                txtNumTotal.Text = string.Empty;
                chkAlberca.Checked = false;
                chkNuevo.Checked = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        private void GetAsentamientos(int idMunicipio)
        {
            BTLInmobiliaria.Catalogos catalogos = new BTLInmobiliaria.Catalogos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsAsentamiento = new DataSet();

            try
            {
                dsAsentamiento = catalogos.GetAsentamientos(idMunicipio);

                if (dsAsentamiento.Tables[0].Rows.Count > 0)
                {
                    cmbAsentamiento.DataSource = dsAsentamiento;
                    cmbAsentamiento.DataValueField = "IdAsentamiento";
                    cmbAsentamiento.DataTextField = "Descripcion";
                    cmbAsentamiento.DataBind();

                    cmbAsentamiento.Items.Insert(0, new ListItem("Seleccione..."));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetMunicipios(int idEstado)
        {
            BTLInmobiliaria.Catalogos catalogos = new BTLInmobiliaria.Catalogos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsMunicipio = new DataSet();

            try
            {
                dsMunicipio = catalogos.GetMunicipios(idEstado);

                if (dsMunicipio.Tables[0].Rows.Count > 0)
                {
                    cmbMunicipio.DataSource = dsMunicipio;
                    cmbMunicipio.DataValueField = "IdMunicipio";
                    cmbMunicipio.DataTextField = "Descripcion";
                    cmbMunicipio.DataBind();

                    cmbMunicipio.Items.Insert(0, new ListItem("Seleccione..."));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetEstados()
        {
            BTLInmobiliaria.Catalogos catalogos = new BTLInmobiliaria.Catalogos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsEstados = new DataSet();

            try
            {
                dsEstados = catalogos.GetEstados();

                if (dsEstados.Tables[0].Rows.Count > 0)
                {
                    cmbEstado.DataSource = dsEstados;
                    cmbEstado.DataValueField = "IdEstado";
                    cmbEstado.DataTextField = "Descripcion";
                    cmbEstado.DataBind();

                    cmbEstado.Items.Insert(0, new ListItem("Seleccione..."));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetTipoPropiedad()
        {
            BTLInmobiliaria.Catalogos catalogos = new BTLInmobiliaria.Catalogos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsTipoPropiedad = new DataSet();

            try
            {
                dsTipoPropiedad = catalogos.GetTipoPropiedad(0);

                if (dsTipoPropiedad.Tables[0].Rows.Count > 0)
                {
                    cmbTipoPropiedad.DataSource = dsTipoPropiedad;
                    cmbTipoPropiedad.DataValueField = "IdTipoPropiedad";
                    cmbTipoPropiedad.DataTextField = "Descripcion";
                    cmbTipoPropiedad.DataBind();

                    cmbTipoPropiedad.Items.Insert(0, new ListItem("Seleccione..."));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetEstatusInmueble()
        {
            BTLInmobiliaria.Catalogos catalogos = new BTLInmobiliaria.Catalogos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsEstatus = new DataSet();

            try
            {
                dsEstatus = catalogos.GetEstatusInmueble();

                if (dsEstatus.Tables[0].Rows.Count > 0)
                {
                    cmbEstatusInmueble.DataSource = dsEstatus;
                    cmbEstatusInmueble.DataValueField = "IdEstatusInmueble";
                    cmbEstatusInmueble.DataTextField = "Descripcion";
                    cmbEstatusInmueble.DataBind();

                    cmbEstatusInmueble.Items.Insert(0, new ListItem("Seleccione..."));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetInmuebles(int idInmueble)
        {
            BTLInmobiliaria.Inmobiliaria inmobiliaria = new BTLInmobiliaria.Inmobiliaria(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsInmuebles = new DataSet();

            try
            {
                if (idInmueble == 0)
                {
                    dsInmuebles = inmobiliaria.GetInmuebles();

                    if (dsInmuebles.Tables[0].Rows.Count > 0)
                    {
                        grdInmuebles.DataSource = dsInmuebles;
                        grdInmuebles.DataBind();
                    }
                }
                else
                {
                    dsInmuebles = inmobiliaria.GetInmuebles(idInmueble);

                    if (dsInmuebles.Tables[0].Rows.Count > 0)
                    {
                        txtNombreInmueble.Text = dsInmuebles.Tables[0].Rows[0]["NombreInmueble"].ToString();
                        txtDescripcion.Text = dsInmuebles.Tables[0].Rows[0]["Descripcion"].ToString();
                        txtCostoTotal.Text = dsInmuebles.Tables[0].Rows[0]["CostoTotal"].ToString();
                        txtCostoMensual.Text = dsInmuebles.Tables[0].Rows[0]["CostoMensual"].ToString();
                        txtCostoMantenimiento.Text = dsInmuebles.Tables[0].Rows[0]["CostoMto"].ToString();
                        txtAntiguedad.Text = dsInmuebles.Tables[0].Rows[0]["Antiguedad"].ToString();
                        cmbTipoPropiedad.SelectedValue = dsInmuebles.Tables[0].Rows[0]["IdTipoPropiedad"].ToString();
                        cmbEstado.SelectedValue = dsInmuebles.Tables[0].Rows[0]["IdEstado"].ToString();
                        GetMunicipios(int.Parse(cmbEstado.SelectedValue));
                        cmbMunicipio.SelectedValue = dsInmuebles.Tables[0].Rows[0]["IdMunicipio"].ToString();
                        GetAsentamientos(int.Parse(cmbMunicipio.SelectedValue));
                        cmbAsentamiento.SelectedValue = dsInmuebles.Tables[0].Rows[0]["IdAsentamiento"].ToString();
                        cmbEstatusInmueble.SelectedValue = dsInmuebles.Tables[0].Rows[0]["IdEstatusInmueble"].ToString();
                        chkNuevo.Checked = Convert.ToBoolean(dsInmuebles.Tables[0].Rows[0]["Nuevo"]);
                        txtNumRecamaras.Text = dsInmuebles.Tables[0].Rows[0]["NumRecamaras"].ToString();
                        txtNumBanos.Text = dsInmuebles.Tables[0].Rows[0]["NumBanos"].ToString();
                        txtNumServicios.Text = dsInmuebles.Tables[0].Rows[0]["NumServicios"].ToString();
                        txtNumEstacionamiento.Text = dsInmuebles.Tables[0].Rows[0]["NumEstacionamientos"].ToString();
                        chkAlberca.Checked = Convert.ToBoolean(dsInmuebles.Tables[0].Rows[0]["ConAlberca"]);
                        txtNumM2.Text = dsInmuebles.Tables[0].Rows[0]["NumM2"].ToString();
                        txtNumTotal.Text = dsInmuebles.Tables[0].Rows[0]["NumTotal"].ToString();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetImagenes(int IdInmueble)
        {
            BTLInmobiliaria.Inmobiliaria inmobiliaria = new BTLInmobiliaria.Inmobiliaria(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsInmuebles = new DataSet();

            try
            {
                dsInmuebles = inmobiliaria.GetImagenesInmueble(IdInmueble);

                if (dsInmuebles.Tables[0].Rows.Count > 0)
                {
                    grdImagenes.DataSource = dsInmuebles;

                    grdImagenes.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetArchivos(int IdInmueble)
        {
            BTLInmobiliaria.Inmobiliaria inmobiliaria = new BTLInmobiliaria.Inmobiliaria(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsInmuebles = new DataSet();

            try
            {
                dsInmuebles = inmobiliaria.GetArchivosInmueble(IdInmueble);

                if (dsInmuebles.Tables[0].Rows.Count > 0)
                {
                    grdArchivos.DataSource = dsInmuebles;

                    grdArchivos.DataBind();
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
            try
            {
                if (!IsPostBack)
                {
                    cmbMunicipio.Items.Insert(0, new ListItem("Seleccione..."));
                    cmbAsentamiento.Items.Insert(0, new ListItem("Seleccione..."));

                    GetInmuebles(0);
                    GetEstados();
                    GetEstatusInmueble();
                    GetTipoPropiedad();
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetMunicipios(int.Parse(cmbEstado.SelectedValue));
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetAsentamientos(int.Parse(cmbMunicipio.SelectedValue));
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            BTLInmobiliaria.Inmobiliaria inmobiliaria = new BTLInmobiliaria.Inmobiliaria(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            int? idInmueble;
            try
            {
                if (bool.Parse(ViewState["oInsertar"].ToString()))
                {
                    idInmueble = inmobiliaria.InsertInmuebles(txtNombreInmueble.Text.Trim(), txtDescripcion.Text.Trim(), 0, 0, decimal.Parse(txtCostoTotal.Text.Trim())
                        , decimal.Parse(txtCostoMensual.Text.Trim()), decimal.Parse(txtCostoMantenimiento.Text.Trim()), Convert.ToInt32(chkNuevo.Checked), int.Parse(txtAntiguedad.Text.Trim())
                        , int.Parse(cmbTipoPropiedad.SelectedValue), int.Parse(cmbAsentamiento.SelectedValue), int.Parse(cmbEstatusInmueble.SelectedValue));

                    inmobiliaria.InsertDetalleInmuebles(int.Parse(txtNumRecamaras.Text.Trim()), int.Parse(txtNumBanos.Text.Trim()), int.Parse(txtNumServicios.Text.Trim())
                        , int.Parse(txtNumEstacionamiento.Text.Trim()), Convert.ToInt32(chkAlberca.Checked), int.Parse(txtNumM2.Text.Trim()), int.Parse(txtNumTotal.Text.Trim())
                        , Convert.ToInt32(idInmueble));

                    inmobiliaria.InsertUsuariosInmuebles(int.Parse(Session["IdUsuario"].ToString()), Convert.ToInt32(idInmueble), DateTime.Now);

                    ShowMessage("El registro ha sido guardado exitosamente.", MessageType.Exito);

                    GetInmuebles(0);
                }
                else
                {
                    inmobiliaria.UpdateInmuebles(int.Parse(ViewState["IdInmueble"].ToString()), txtNombreInmueble.Text.Trim(), txtDescripcion.Text.Trim(), 0, 0, decimal.Parse(txtCostoTotal.Text.Trim())
                        , decimal.Parse(txtCostoMensual.Text.Trim()), decimal.Parse(txtCostoMantenimiento.Text.Trim()), Convert.ToInt32(chkNuevo.Checked), int.Parse(txtAntiguedad.Text.Trim())
                        , int.Parse(cmbTipoPropiedad.SelectedValue), int.Parse(cmbAsentamiento.SelectedValue), int.Parse(cmbEstatusInmueble.SelectedValue));

                    inmobiliaria.UpdateDetalleInmuebles(int.Parse(ViewState["IdDetalleInmueble"].ToString()), int.Parse(txtNumRecamaras.Text.Trim()), int.Parse(txtNumBanos.Text.Trim()), int.Parse(txtNumServicios.Text.Trim())
                        , int.Parse(txtNumEstacionamiento.Text.Trim()), Convert.ToInt32(chkAlberca.Checked), int.Parse(txtNumM2.Text.Trim()), int.Parse(txtNumTotal.Text.Trim()));

                    inmobiliaria.UpdateUsuariosInmuebles(int.Parse(ViewState["IdUsuarioInmueble"].ToString()), int.Parse(Session["IdUsuario"].ToString()));

                    ShowMessage("El registro ha sido actualizado exitosamente.", MessageType.Exito);

                    GetInmuebles(0);
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

                LimpiarControles();

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void btnGuardarImagenInmueble_Click(object sender, EventArgs e)
        {
            BTLInmobiliaria.Inmobiliaria inmobiliaria = new BTLInmobiliaria.Inmobiliaria(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            int iUploadedCnt = 0;
            int iFailedCnt = 0;

            try
            {
                if (flpFotosInmueble.HasFiles)
                {
                    HttpFileCollection hfc = Request.Files;

                    if (hfc.Count <= 10)
                    {
                        for (int i = 0; i <= hfc.Count - 1; i++)
                        {
                            HttpPostedFile hpf = hfc[i];
                            if (hpf.ContentLength > 0)
                            {
                                if (!File.Exists(Server.MapPath("~/Inmuebles/Imagenes/") +
                            Path.GetFileName(hpf.FileName)))
                                {
                                    DirectoryInfo objDir =
                                        new DirectoryInfo(Server.MapPath("~/Inmuebles/Imagenes/"));

                                    string sFileName = Path.GetFileName(hpf.FileName);
                                    string sFileExt = Path.GetExtension(hpf.FileName);

                                    // CHECK FOR DUPLICATE FILES.
                                    FileInfo[] objFI =
                                        objDir.GetFiles(sFileName.Replace(sFileExt, "") + ".*");

                                    if (objFI.Length > 0)
                                    {

                                        foreach (FileInfo file in objFI)
                                        {
                                            string sFileName1 = objFI[0].Name;
                                            string sFileExt1 = Path.GetExtension(objFI[0].Name);

                                            if (sFileName1.Replace(sFileExt1, "") ==
                                                    sFileName.Replace(sFileExt, ""))
                                            {
                                                iFailedCnt += 1;        // NOT ALLOWING DUPLICATE.
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // SAVE THE FILE IN A FOLDER.
                                        hpf.SaveAs(Server.MapPath("~/Inmuebles/Imagenes/") + "Img_Inmueble_" + ViewState["IdInmueble"].ToString() + "_" +
                                            Path.GetFileName(hpf.FileName));

                                        string path = Server.MapPath("~/Inmuebles/Imagenes/") + "Img_Inmueble_" + ViewState["IdInmueble"].ToString() + "_" +
                                            Path.GetFileName(hpf.FileName);

                                        string nameCompose = "Img_Inmueble_" + ViewState["IdInmueble"].ToString() + "_" + hpf.FileName;

                                        inmobiliaria.InsertImagenesInmueble(nameCompose, path, int.Parse(ViewState["IdInmueble"].ToString()));

                                        iUploadedCnt += 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void btnGuardarArchivosInmueble_Click(object sender, EventArgs e)
        {
            BTLInmobiliaria.Inmobiliaria inmobiliaria = new BTLInmobiliaria.Inmobiliaria(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            int iUploadedCnt = 0;
            int iFailedCnt = 0;

            try
            {
                if (flpArchivosInmueble.HasFiles)
                {
                    HttpFileCollection hfc = Request.Files;

                    if (hfc.Count <= 10)
                    {
                        for (int i = 0; i <= hfc.Count - 1; i++)
                        {
                            HttpPostedFile hpf = hfc[i];
                            if (hpf.ContentLength > 0)
                            {
                                if (!File.Exists(Server.MapPath("~/Inmuebles/Archivos/") +
                            Path.GetFileName(hpf.FileName)))
                                {
                                    DirectoryInfo objDir =
                                        new DirectoryInfo(Server.MapPath("~/Inmuebles/Archivos/"));

                                    string sFileName = Path.GetFileName(hpf.FileName);
                                    string sFileExt = Path.GetExtension(hpf.FileName);

                                    // CHECK FOR DUPLICATE FILES.
                                    FileInfo[] objFI =
                                        objDir.GetFiles(sFileName.Replace(sFileExt, "") + ".*");

                                    if (objFI.Length > 0)
                                    {

                                        foreach (FileInfo file in objFI)
                                        {
                                            string sFileName1 = objFI[0].Name;
                                            string sFileExt1 = Path.GetExtension(objFI[0].Name);

                                            if (sFileName1.Replace(sFileExt1, "") ==
                                                    sFileName.Replace(sFileExt, ""))
                                            {
                                                iFailedCnt += 1;        // NOT ALLOWING DUPLICATE.
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // SAVE THE FILE IN A FOLDER.
                                        hpf.SaveAs(Server.MapPath("~/Inmuebles/Archivos/") + "File_Inmueble_" + ViewState["IdInmueble"].ToString() + "_" +
                                            Path.GetFileName(hpf.FileName));

                                        string path = Server.MapPath("~/Inmuebles/Archivos/") + "File_Inmueble_" + ViewState["IdInmueble"].ToString() + "_" +
                                            Path.GetFileName(hpf.FileName);

                                        string nameCompose = "File_Inmueble_" + ViewState["IdInmueble"].ToString() + "_" + hpf.FileName;

                                        inmobiliaria.InsertArchivosInmueble(nameCompose, path, int.Parse(ViewState["IdInmueble"].ToString()));

                                        iUploadedCnt += 1;
                                    }
                                }
                            }
                        }
                    }
                }
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

                ImageButton button = (ImageButton)sender;
                GridViewRow namingContainer = button.NamingContainer as GridViewRow;

                ViewState["IdInmueble"] = Convert.ToInt32(grdInmuebles.DataKeys[namingContainer.RowIndex].Values["IdInmueble"].ToString());
                ViewState["IdDetalleInmueble"] = Convert.ToInt32(grdInmuebles.DataKeys[namingContainer.RowIndex].Values["IdDetalleInmueble"].ToString());
                ViewState["IdUsuarioInmueble"] = Convert.ToInt32(grdInmuebles.DataKeys[namingContainer.RowIndex].Values["IdUsuarioInmueble"].ToString());

                GetInmuebles(Convert.ToInt32(ViewState["IdInmueble"].ToString()));

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void ibtnImagenes_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton button = (ImageButton)sender;
                GridViewRow namingContainer = button.NamingContainer as GridViewRow;

                ViewState["IdInmueble"] = Convert.ToInt32(grdInmuebles.DataKeys[namingContainer.RowIndex].Values["IdInmueble"].ToString());

                GetImagenes(int.Parse(ViewState["IdInmueble"].ToString()));

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void grdImagenes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView dr = (DataRowView)e.Row.DataItem;
                    string path = dr["UbicacionImagen"].ToString();
                    string imageUrl = "~/Inmuebles/Imagenes/" + Path.GetFileName(path);

                    (e.Row.FindControl("img") as System.Web.UI.WebControls.Image).ImageUrl = imageUrl;

                }

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void ibtnArchivos_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton button = (ImageButton)sender;
                GridViewRow namingContainer = button.NamingContainer as GridViewRow;

                ViewState["IdInmueble"] = Convert.ToInt32(grdInmuebles.DataKeys[namingContainer.RowIndex].Values["IdInmueble"].ToString());

                GetArchivos(int.Parse(ViewState["IdInmueble"].ToString()));

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
                ViewState["oInsertar"] = null;

                LimpiarControles();

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void ibtnEliminarImagen_Click(object sender, ImageClickEventArgs e)
        {
            BTLInmobiliaria.Inmobiliaria inmobiliaria = new BTLInmobiliaria.Inmobiliaria(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());

            try
            {
                ViewState["oInsertar"] = false;

                ImageButton button = (ImageButton)sender;
                GridViewRow namingContainer = button.NamingContainer as GridViewRow;

                ViewState["IdImagenInmueble"] = Convert.ToInt32(grdImagenes.DataKeys[namingContainer.RowIndex].Values["IdImagenInmueble"].ToString());
                ViewState["IdInmueble"] = Convert.ToInt32(grdImagenes.DataKeys[namingContainer.RowIndex].Values["IdInmueble"].ToString());
                ViewState["NombreImagen"] = grdImagenes.DataKeys[namingContainer.RowIndex].Values["NombreImagen"].ToString();

                string filePath = Server.MapPath("~/Inmuebles/Imagenes") + ViewState["NombreImagen"].ToString();

                File.Delete(filePath);

                inmobiliaria.DeleteImagenesInmueble(int.Parse(ViewState["IdImagenInmueble"].ToString()));

                GetImagenes(Convert.ToInt32(ViewState["IdInmueble"].ToString()));

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void grdArchivos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView dr = (DataRowView)e.Row.DataItem;
                    string path = dr["UbicacionArchivo"].ToString();
                    string imageUrl = "~/Inmuebles/Archivos/" + Path.GetFileName(path);

                    (e.Row.FindControl("archivo") as System.Web.UI.WebControls.Image).ImageUrl = imageUrl;

                }

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void ibtnEliminarArchivo_Click(object sender, ImageClickEventArgs e)
        {
            BTLInmobiliaria.Inmobiliaria inmobiliaria = new BTLInmobiliaria.Inmobiliaria(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());

            try
            {
                ViewState["oInsertar"] = false;

                ImageButton button = (ImageButton)sender;
                GridViewRow namingContainer = button.NamingContainer as GridViewRow;

                ViewState["IdArchivoInmueble"] = Convert.ToInt32(grdArchivos.DataKeys[namingContainer.RowIndex].Values["IdArchivoInmueble"].ToString());
                ViewState["IdInmueble"] = Convert.ToInt32(grdArchivos.DataKeys[namingContainer.RowIndex].Values["IdInmueble"].ToString());
                ViewState["NombreArchivo"] = grdArchivos.DataKeys[namingContainer.RowIndex].Values["NombreArchivo"].ToString();

                string filePath = Server.MapPath("~/Inmuebles/Archivos/") + ViewState["NombreArchivo"].ToString();

                File.Delete(filePath);

                inmobiliaria.DeleteArchivosInmueble(int.Parse(ViewState["IdArchivoInmueble"].ToString()));

                GetArchivos(Convert.ToInt32(ViewState["IdInmueble"].ToString()));

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        #endregion


    }
}