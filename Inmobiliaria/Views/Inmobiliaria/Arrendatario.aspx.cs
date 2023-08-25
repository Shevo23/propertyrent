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
        #region Variables

        public enum MessageType { Exito, Error, Importante, Advertencia };

        #endregion

        #region Methods
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        private void GetEstadoCivil()
        {
            BTLInmobiliaria.Inmobiliaria inmobiliaria = new BTLInmobiliaria.Inmobiliaria(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsCivil = new DataSet();

            try
            {
                dsCivil = inmobiliaria.GetEstadoCivil();

                if (dsCivil.Tables[0].Rows.Count > 0)
                {
                    cmbEstadoCivil.DataSource = dsCivil;
                    cmbEstadoCivil.DataValueField = "IdEstadoCivil";
                    cmbEstadoCivil.DataTextField = "Descripcion";
                    cmbEstadoCivil.DataBind();

                    cmbEstadoCivil.Items.Insert(0, new ListItem("Seleccione..."));

                    cmbEstadoCivilFiador.DataSource = dsCivil;
                    cmbEstadoCivilFiador.DataValueField = "IdEstadoCivil";
                    cmbEstadoCivilFiador.DataTextField = "Descripcion";
                    cmbEstadoCivilFiador.DataBind();

                    cmbEstadoCivilFiador.Items.Insert(0, new ListItem("Seleccione..."));
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
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
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
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
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
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
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
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
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
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
                        txtEdad.Text = dsTipoIdentificacion.Tables[0].Rows[0]["Edad"].ToString();
                        txtUltimoGradoEstudio.Text = dsTipoIdentificacion.Tables[0].Rows[0]["UltimoGradoEstudio"].ToString();
                        txtCarreraOficio.Text = dsTipoIdentificacion.Tables[0].Rows[0]["CarreraOficio"].ToString();
                        cmbEstado.SelectedValue = dsTipoIdentificacion.Tables[0].Rows[0]["IdEstado"].ToString();
                        GetMunicipios(int.Parse(cmbEstado.SelectedValue));
                        cmbMunicipio.SelectedValue = dsTipoIdentificacion.Tables[0].Rows[0]["IdMunicipio"].ToString();
                        GetAsentamientos(int.Parse(cmbMunicipio.SelectedValue));
                        cmbAsentamiento.SelectedValue = dsTipoIdentificacion.Tables[0].Rows[0]["IdAsentamiento"].ToString();
                        txtNumPersonasHabitar.Text = dsTipoIdentificacion.Tables[0].Rows[0]["NumPersonasHabitar"].ToString();
                        txtNumPersonasDependen.Text = dsTipoIdentificacion.Tables[0].Rows[0]["NumPersonasDependen"].ToString();
                        cmbEstadoCivil.SelectedValue = dsTipoIdentificacion.Tables[0].Rows[0]["IdEstadoCivil"].ToString();
                        txtMovil.Text = dsTipoIdentificacion.Tables[0].Rows[0]["Movil"].ToString();
                        txtEmpresaTrabaja.Text = dsTipoIdentificacion.Tables[0].Rows[0]["EmpresaTrabaja"].ToString();
                        txtAntiguedad.Text = dsTipoIdentificacion.Tables[0].Rows[0]["Antiguedad"].ToString();
                        txtHorario.Text = dsTipoIdentificacion.Tables[0].Rows[0]["Horario"].ToString();
                        txtDireccionEmpleo.Text = dsTipoIdentificacion.Tables[0].Rows[0]["DireccionEmpleo"].ToString();
                        txtFijo.Text = dsTipoIdentificacion.Tables[0].Rows[0]["Fijo"].ToString();
                        txtNombreJefe.Text = dsTipoIdentificacion.Tables[0].Rows[0]["NombreJefe"].ToString();
                        txtPuestoEmpleo.Text = dsTipoIdentificacion.Tables[0].Rows[0]["PuestoEmpleo"].ToString();
                        txtSalarioMensual.Text = dsTipoIdentificacion.Tables[0].Rows[0]["SalarioMensual"].ToString();
                        txtMotivoCambio.Text = dsTipoIdentificacion.Tables[0].Rows[0]["MotivoCambio"].ToString();
                        txtRelacionFiador.Text = dsTipoIdentificacion.Tables[0].Rows[0]["RelacionFiador"].ToString();
                        txtNombreFiador.Text = dsTipoIdentificacion.Tables[0].Rows[0]["NombreFiador"].ToString();
                        txtDireccionFiador.Text = dsTipoIdentificacion.Tables[0].Rows[0]["DireccionFiador"].ToString();
                        txtTelefonoFiador.Text = dsTipoIdentificacion.Tables[0].Rows[0]["TelefonoFiador"].ToString();
                        txtMovilFiador.Text = dsTipoIdentificacion.Tables[0].Rows[0]["MovilFiador"].ToString();
                        cmbEstadoCivilFiador.SelectedValue = dsTipoIdentificacion.Tables[0].Rows[0]["IdEstadoCivil"].ToString();
                        txtTiempoMatrimonio.Text = dsTipoIdentificacion.Tables[0].Rows[0]["TiempoMatrimonio"].ToString();
                        txtEdadFiador.Text = dsTipoIdentificacion.Tables[0].Rows[0]["EdadFiador"].ToString();
                        txtEmpresaTrabajaFiador.Text = dsTipoIdentificacion.Tables[0].Rows[0]["EmpresaTrabajaFiador"].ToString();
                        txtDireccionEmpleoFiador.Text = dsTipoIdentificacion.Tables[0].Rows[0]["DireccionEmpleoFiador"].ToString();
                        txtPuestoEmpleoFiador.Text = dsTipoIdentificacion.Tables[0].Rows[0]["PuestoEmpleoFiador"].ToString();
                        txtSalarioMensualFiador.Text = dsTipoIdentificacion.Tables[0].Rows[0]["SalarioMensualFiador"].ToString();
                        chk_Estatus.Checked = Convert.ToBoolean(dsTipoIdentificacion.Tables[0].Rows[0]["Activo"]);
                        cmbTipoIdentificacion.SelectedValue = dsTipoIdentificacion.Tables[0].Rows[0]["IdTipoIdentificacion"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
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
                    cmbMunicipio.Items.Insert(0, new ListItem("Seleccione..."));
                    cmbAsentamiento.Items.Insert(0, new ListItem("Seleccione..."));

                    GetTipoIdentificacion(0, 0);
                    GetArrendatarios(0, 0);
                    GetEstados();
                    GetEstadoCivil();
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

                lbl_Titulo.Text = "Solicitud de arrendamiento";
                txtNombres.Text = string.Empty;
                txtPaterno.Text = string.Empty;
                txtMaterno.Text = string.Empty;
                //txtEmail.Text = string.Empty;
                txtMovil.Text = string.Empty;
                txtFijo.Text = string.Empty;
                cmbTipoIdentificacion.SelectedIndex = 0;
                chk_Estatus.Checked = true;
                chk_Estatus.Enabled = false;

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

                ViewState["IdArrendatario"] = Convert.ToInt32(grdArrendatario.DataKeys[namingContainer.RowIndex].Values["IdArrendatario"].ToString());

                GetArrendatarios(1, int.Parse(ViewState["IdArrendatario"].ToString()));
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

                ViewState["IdArrendatario"] = Convert.ToInt32(grdArrendatario.DataKeys[namingContainer.RowIndex].Values["IdArrendatario"].ToString());

                GetArchivos(int.Parse(ViewState["IdArrendatario"].ToString()));

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            BTLInmobiliaria.Inmobiliaria inmobiliaria = new BTLInmobiliaria.Inmobiliaria(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());

            var idTipo = int.Parse(cmbTipoIdentificacion.SelectedValue);
            var idAsentamiento = int.Parse(cmbAsentamiento.SelectedValue);
            var idEstadoCivil = int.Parse(cmbEstadoCivil.SelectedValue);
            var idEstadoCivilFia = int.Parse(cmbEstadoCivilFiador.SelectedValue);

            try
            {
                if (bool.Parse(ViewState["oInsertar"].ToString()))
                {
                    

                    inmobiliaria.InsertArrendatario(txtNombres.Text.Trim(), txtPaterno.Text.Trim(), txtMaterno.Text.Trim(), int.Parse(txtEdad.Text.Trim())
                        , txtUltimoGradoEstudio.Text.Trim(), txtCarreraOficio.Text.Trim(),idAsentamiento, int.Parse(txtNumPersonasHabitar.Text.Trim()),
                        int.Parse(txtNumPersonasDependen.Text.Trim()),idEstadoCivil, txtMovil.Text.Trim(), txtEmpresaTrabaja.Text.Trim(),
                        int.Parse(txtAntiguedad.Text.Trim()), txtHorario.Text.Trim(),txtDireccionEmpleo.Text.Trim(),txtFijo.Text.Trim(),
                        txtNombreJefe.Text.Trim(),txtPuestoEmpleo.Text.Trim(), decimal.Parse(txtSalarioMensual.Text.Trim()),txtMotivoCambio.Text.Trim(),
                        txtRelacionFiador.Text.Trim(),txtNombreFiador.Text.Trim(),txtDireccionFiador.Text.Trim(),txtTelefonoFiador.Text.Trim(),
                        txtMovilFiador.Text.Trim(), idEstadoCivilFia, int.Parse(txtTiempoMatrimonio.Text.Trim()), int.Parse(txtEdadFiador.Text.Trim()),
                        txtEmpresaTrabajaFiador.Text.Trim(),txtDireccionEmpleoFiador.Text.Trim(),txtPuestoEmpleoFiador.Text.Trim(),
                        decimal.Parse(txtSalarioMensualFiador.Text.Trim()), Convert.ToInt32(chk_Estatus.Checked), idTipo);

                    ShowMessage("El registro ha sido guardado exitosamente.", MessageType.Exito);

                    GetArrendatarios(0, 0);

                }
                else
                {
                    inmobiliaria.UpdateArrendatario(int.Parse(ViewState["IdArrendatario"].ToString()), txtNombres.Text.Trim(), txtPaterno.Text.Trim(), txtMaterno.Text.Trim(), int.Parse(txtEdad.Text.Trim())
                        , txtUltimoGradoEstudio.Text.Trim(), txtCarreraOficio.Text.Trim(), idAsentamiento, int.Parse(txtNumPersonasHabitar.Text.Trim()),
                        int.Parse(txtNumPersonasDependen.Text.Trim()), idEstadoCivil, txtMovil.Text.Trim(), txtEmpresaTrabaja.Text.Trim(),
                        int.Parse(txtAntiguedad.Text.Trim()), txtHorario.Text.Trim(), txtDireccionEmpleo.Text.Trim(), txtFijo.Text.Trim(),
                        txtNombreJefe.Text.Trim(), txtPuestoEmpleo.Text.Trim(), decimal.Parse(txtSalarioMensual.Text.Trim()), txtMotivoCambio.Text.Trim(),
                        txtRelacionFiador.Text.Trim(), txtNombreFiador.Text.Trim(), txtDireccionFiador.Text.Trim(), txtTelefonoFiador.Text.Trim(),
                        txtMovilFiador.Text.Trim(), idEstadoCivilFia, int.Parse(txtTiempoMatrimonio.Text.Trim()), int.Parse(txtEdadFiador.Text.Trim()),
                        txtEmpresaTrabajaFiador.Text.Trim(), txtDireccionEmpleoFiador.Text.Trim(), txtPuestoEmpleoFiador.Text.Trim(),
                        decimal.Parse(txtSalarioMensualFiador.Text.Trim()), Convert.ToInt32(chk_Estatus.Checked), idTipo);

                    ShowMessage("El registro ha sido actualizado exitosamente.", MessageType.Exito);

                    GetArrendatarios(0, 0);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
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
                    string imageUrl = "~/Inmuebles/Arrendatario/" + Path.GetFileName(path);

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

                ViewState["IdArchivoArrendatario"] = Convert.ToInt32(grdArchivos.DataKeys[namingContainer.RowIndex].Values["IdArchivoArrendatario"].ToString());
                ViewState["IdArrendatario"] = Convert.ToInt32(grdArchivos.DataKeys[namingContainer.RowIndex].Values["IdArrendatario"].ToString());
                ViewState["NombreArchivo"] = grdArchivos.DataKeys[namingContainer.RowIndex].Values["NombreArchivo"].ToString();

                string filePath = Server.MapPath("~/Inmuebles/Arrendatario/") + ViewState["NombreArchivo"].ToString();

                File.Delete(filePath);

                inmobiliaria.DeleteArchivosArrendatario(int.Parse(ViewState["IdArchivoArrendatario"].ToString()));

                GetArchivos(Convert.ToInt32(ViewState["IdArrendatario"].ToString()));

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

        #endregion

    }
}