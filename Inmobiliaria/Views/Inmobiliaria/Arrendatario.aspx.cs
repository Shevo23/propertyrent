using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inmobiliaria.Views.Inmobiliaria
{
    public partial class Arrendatario : System.Web.UI.Page
    {
        #region Methods

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
                        cmbTipoIdentificacion.DataSource = dsTipoIdentificacion;
                        cmbTipoIdentificacion.DataValueField = "IdTipoIdentificacion";
                        cmbTipoIdentificacion.DataTextField = "Descripcion";
                        cmbTipoIdentificacion.DataBind();

                        cmbTipoIdentificacion.Items.Insert(0, new ListItem("Seleccione..."));

                    }
                }
                else
                {
                    dsTipoIdentificacion = catalogos.GetTipoIdentificacion(idTipoIdentificacion);

                    if (dsTipoIdentificacion.Tables[0].Rows.Count > 0)
                    {
                        cmbTipoIdentificacion.SelectedValue = dsTipoIdentificacion.Tables[0].Rows[0]["IdTipoIdentificacion"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetArrendatarios(int busqueda, int idArrendador)
        {
            BTLInmobiliaria.Inmobiliaria inmobiliaria = new BTLInmobiliaria.Inmobiliaria(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsTipoIdentificacion = new DataSet();

            try
            {
                if (busqueda == 0)
                {
                    dsTipoIdentificacion = inmobiliaria.GetArrendatarios(0);

                    if (dsTipoIdentificacion.Tables[0].Rows.Count > 0)
                    {
                        grdArrendatario.DataSource = dsTipoIdentificacion;
                        grdArrendatario.DataBind();

                    }
                }
                else
                {
                    dsTipoIdentificacion = inmobiliaria.GetArrendatarios(idArrendador);

                    if (dsTipoIdentificacion.Tables[0].Rows.Count > 0)
                    {
                        txtNombres.Text = dsTipoIdentificacion.Tables[0].Rows[0]["Nombres"].ToString();
                        txtPaterno.Text = dsTipoIdentificacion.Tables[0].Rows[0]["Paterno"].ToString();
                        txtMaterno.Text = dsTipoIdentificacion.Tables[0].Rows[0]["Materno"].ToString();
                        txtEmail.Text = dsTipoIdentificacion.Tables[0].Rows[0]["Email"].ToString();
                        txtMovil.Text = dsTipoIdentificacion.Tables[0].Rows[0]["Movil"].ToString();
                        txtFijo.Text = dsTipoIdentificacion.Tables[0].Rows[0]["Fijo"].ToString();
                        chk_Estatus.Checked = Convert.ToBoolean(dsTipoIdentificacion.Tables[0].Rows[0]["Activo"]);
                        cmbTipoIdentificacion.SelectedValue = dsTipoIdentificacion.Tables[0].Rows[0]["IdTipoIdentificacion"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetArchivos(int idArrendatario)
        {
            BTLInmobiliaria.Inmobiliaria inmobiliaria = new BTLInmobiliaria.Inmobiliaria(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsInmuebles = new DataSet();

            try
            {
                dsInmuebles = inmobiliaria.GetArchivosArrendatario(idArrendatario);

                if (dsInmuebles.Tables[0].Rows.Count >= 0)
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
                    GetTipoIdentificacion(0, 0);
                    GetArrendatarios(0, 0);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                ViewState["oInsertar"] = true;

                lbl_Titulo.Text = "Agregar nuevo";
                txtNombres.Text = string.Empty;
                txtPaterno.Text = string.Empty;
                txtMaterno.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtMovil.Text = string.Empty;
                txtFijo.Text = string.Empty;
                cmbTipoIdentificacion.SelectedIndex = 0;
                chk_Estatus.Checked = true;
                chk_Estatus.Enabled = false;

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

                ViewState["IdArrendatario"] = Convert.ToInt32(grdArrendatario.DataKeys[namingContainer.RowIndex].Values["IdArrendatario"].ToString());

                GetArrendatarios(1, int.Parse(ViewState["IdArrendatario"].ToString()));
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ibtnArchivos_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton button = (ImageButton)sender;
                GridViewRow namingContainer = button.NamingContainer as GridViewRow;

                ViewState["IdArrendatario"] = Convert.ToInt32(grdArrendatario.DataKeys[namingContainer.RowIndex].Values["IdArrendatario"].ToString());

                GetArchivos(int.Parse(ViewState["IdArrendatario"].ToString()));

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            BTLInmobiliaria.Inmobiliaria inmobiliaria = new BTLInmobiliaria.Inmobiliaria(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());

            var idTipo = int.Parse(cmbTipoIdentificacion.SelectedValue);


            try
            {
                if (bool.Parse(ViewState["oInsertar"].ToString()))
                {


                    inmobiliaria.InsertArrendatario(txtNombres.Text.Trim(), txtPaterno.Text.Trim(), txtMaterno.Text.Trim(), txtEmail.Text.Trim()
                        , txtMovil.Text.Trim(), txtFijo.Text.Trim(), DateTime.Now, Convert.ToInt32(chk_Estatus.Checked), idTipo);

                    // ShowMessage("El registro ha sido guardado exitosamente.", MessageType.Exito);

                    GetArrendatarios(0, 0);

                }
                else
                {
                    //catalogos.UpdateUsuariosRoles(int.Parse(ViewState["IdUsuarioRol"].ToString()), idUsuario, idRol);

                    ////ShowMessage("El registro ha sido actualizado exitosamente.", MessageType.Exito);

                    //GetUsuariosRoles(0, 0);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnGuardarArchivosArrendatario_Click(object sender, EventArgs e)
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
                                if (!File.Exists(Server.MapPath("~/Inmuebles/Arrendatario/") +
                            Path.GetFileName(hpf.FileName)))
                                {
                                    DirectoryInfo objDir =
                                        new DirectoryInfo(Server.MapPath("~/Inmuebles/Arrendatario/"));

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
                                        hpf.SaveAs(Server.MapPath("~/Inmuebles/Arrendatario/") + "File_Arrendatario_" + ViewState["IdArrendatario"].ToString() + "_" +
                                            Path.GetFileName(hpf.FileName));

                                        string path = Server.MapPath("~/Inmuebles/Arrendatario/") + "File_Arrendatario_" + ViewState["IdArrendatario"].ToString() + "_" +
                                            Path.GetFileName(hpf.FileName);

                                        string nameCompose = "File_Arrendatario_" + ViewState["IdArrendatario"].ToString() + "_" + hpf.FileName;

                                        inmobiliaria.InsertArchivosArrendatario(nameCompose, path, int.Parse(ViewState["IdArrendatario"].ToString()));

                                        iUploadedCnt += 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
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
                    string imageUrl = "~/Inmuebles/Arrendatario/" + Path.GetFileName(path);

                    (e.Row.FindControl("archivo") as System.Web.UI.WebControls.Image).ImageUrl = imageUrl;

                }

            }
            catch (Exception)
            {

                throw;
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

                ViewState["IdArchivoArrendatario"] = Convert.ToInt32(grdArchivos.DataKeys[namingContainer.RowIndex].Values["IdArchivoArrendatario"].ToString());
                ViewState["IdArrendatario"] = Convert.ToInt32(grdArchivos.DataKeys[namingContainer.RowIndex].Values["IdArrendatario"].ToString());
                ViewState["NombreArchivo"] = grdArchivos.DataKeys[namingContainer.RowIndex].Values["NombreArchivo"].ToString();

                string filePath = Server.MapPath("~/Inmuebles/Arrendatario/") + ViewState["NombreArchivo"].ToString();

                File.Delete(filePath);

                inmobiliaria.DeleteArchivosArrendatario(int.Parse(ViewState["IdArchivoArrendatario"].ToString()));

                GetArchivos(Convert.ToInt32(ViewState["IdArrendatario"].ToString()));

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}