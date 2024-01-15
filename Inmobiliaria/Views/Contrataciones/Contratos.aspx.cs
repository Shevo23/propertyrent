using BTLInmobiliaria;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Inmobiliaria.Views.Contrataciones
{
    public partial class Contratos : System.Web.UI.Page
    {
        #region Variables

        public enum MessageType { Exito, Error, Importante, Advertencia };

        #endregion

        #region Methods

        private void LimpiarControles()
        {
            try
            {
                lbl_Titulo.Text = "Nuevo contrato";

                txtFechaInicioContrato.Text = string.Empty;
                txtFechaFinContrato.Text = string.Empty;
                txtMesesContrato.Text = string.Empty;
                txtAnioContrato.Text = string.Empty;

                cmbInmueble.SelectedIndex = 0;
                txtDescripcion.Text = string.Empty;
                txtCostoTotal.Text = string.Empty;
                txtCostoMensual.Text = string.Empty;
                txtCostoMantenimiento.Text = string.Empty;
                txtAntiguedad.Text = string.Empty;
                txtCalleInmueble.Text = string.Empty;
                cmbTipoPropiedad.SelectedIndex = 0;
                cmbEstado.SelectedIndex = 0;
                cmbMunicipio.SelectedIndex = 0;
                cmbAsentamiento.SelectedIndex = 0;
                cmbEstatusInmueble.SelectedIndex = 0;
                chkNuevo.Checked = true;
                txtNumRecamaras.Text = string.Empty;
                txtNumBanos.Text = string.Empty;
                txtNumServicios.Text = string.Empty;
                txtNumEstacionamiento.Text = string.Empty;
                chkAlberca.Checked = true;
                txtNumM2.Text = string.Empty;
                txtNumTotal.Text = string.Empty;

                cmbArrendador.SelectedIndex = 0;
                txtNombres.Text = string.Empty;
                txtPaterno.Text = string.Empty;
                txtMaterno.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtMovil.Text = string.Empty;
                txtFijo.Text = string.Empty;
                chk_Estatus.Checked = true;
                cmbTipoIdentificacion.SelectedIndex = 0;

                cmbArrendatario.SelectedIndex = 0;
                txtEdad.Text = string.Empty;
                txtUltimoGradoEstudio.Text = string.Empty;
                txtCarreraOficio.Text = string.Empty;
                cmbEstadoArrendatario.SelectedIndex = 0;
                cmbMunicipioArrendatario.SelectedIndex = 0;
                cmbAsentamientoArrendatario.SelectedIndex = 0;
                txtNumPersonasHabitar.Text = string.Empty;
                txtNumPersonasDependen.Text = string.Empty;
                cmbEstadoCivil.SelectedIndex = 0;
                txtMovilArrendatario.Text = string.Empty;
                txtEmpresaTrabaja.Text = string.Empty;
                txtAntiguedadArrendatario.Text = string.Empty;
                txtHorario.Text = string.Empty;
                txtDireccionEmpleo.Text = string.Empty;
                txtFijoArrendatario.Text = string.Empty;
                txtNombreJefe.Text = string.Empty;
                txtPuestoEmpleo.Text = string.Empty;
                txtSalarioMensual.Text = string.Empty;
                txtMotivoCambio.InnerText = string.Empty;
                txtRelacionFiador.Text = string.Empty;
                txtNombreFiador.Text = string.Empty;
                txtDireccionFiador.Text = string.Empty;
                txtTelefonoFiador.Text = string.Empty;
                txtMovilFiador.Text = string.Empty;
                cmbEstadoCivilFiador.SelectedIndex = 0;
                txtTiempoMatrimonio.Text = string.Empty;
                txtEdadFiador.Text = string.Empty;
                txtEmpresaTrabajaFiador.Text = string.Empty;
                txtDireccionEmpleoFiador.Text = string.Empty;
                txtPuestoEmpleoFiador.Text = string.Empty;
                txtSalarioMensualFiador.Text = string.Empty;
                cmbTipoIdentificacionArrendatario.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        private void DownloadCarta(string pathCarta)
        {
            try
            {
                byte[] vs = File.ReadAllBytes(pathCarta);
                Response.Clear();
                Response.ContentType = "application/force-download";
                Response.ContentType = ContentType;
                Response.AddHeader("content-disposition", "attachment; filename=" + System.IO.Path.GetFileName(pathCarta));
                Response.AppendHeader("content-disposition", "attachment; filename=" + System.IO.Path.GetFileName(pathCarta));
                Response.WriteFile(pathCarta);
                Response.BufferOutput = false;
                Response.BinaryWrite(vs);
                Response.Flush();
                Response.Close();
                Response.End();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        private void DownloadContrato(string pathContrato)
        {
            try
            {
                byte[] vs = File.ReadAllBytes(pathContrato);
                Response.Clear();
                Response.ContentType = "application/force-download";
                Response.ContentType = ContentType;
                Response.AddHeader("content-disposition", "attachment; filename=" + System.IO.Path.GetFileName(pathContrato));
                Response.AppendHeader("content-disposition", "attachment; filename=" + System.IO.Path.GetFileName(pathContrato));
                Response.WriteFile(pathContrato);
                Response.BufferOutput = false;
                Response.BinaryWrite(vs);
                Response.Flush();
                Response.Close();
                Response.End();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        private void GetContratos()
        {
            BTLInmobiliaria.Contratos contratos = new BTLInmobiliaria.Contratos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsContratos = new DataSet();

            string colorHex = "#28a745";

            try
            {
                dsContratos = contratos.GetContratos();

                if (dsContratos.Tables[0].Rows.Count > 0)
                {
                    grdContratos.DataSource = dsContratos;
                    grdContratos.DataBind();

                    foreach (GridViewRow row in grdContratos.Rows)
                    {
                        Label labels = row.FindControl("lblEstatus") as Label;

                        if (labels.Text == "Activo")
                        {

                            row.Cells[17].BackColor = ColorTranslator.FromHtml(colorHex);
                        }


                        ImageButton imageButtonContrato = row.FindControl("ibtnContratos") as ImageButton;
                        ScriptManager scriptManagerContrato = ScriptManager.GetCurrent(this.Page);
                        scriptManagerContrato.RegisterPostBackControl(imageButtonContrato);


                        ImageButton imageButtonCarta = row.FindControl("ibtnCartaRecision") as ImageButton;
                        ScriptManager scriptManagerCarta = ScriptManager.GetCurrent(this.Page);
                        scriptManagerCarta.RegisterPostBackControl(imageButtonCarta);
                    }

                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        private int GetNumeroContrato()
        {
            BTLInmobiliaria.Contratos contratos = new BTLInmobiliaria.Contratos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsNumero = new DataSet();

            int consecutivo = 0;

            try
            {
                dsNumero = contratos.GetNumeroContrato();

                if (dsNumero.Tables[0].Rows.Count > 0)
                {
                    consecutivo = int.Parse(dsNumero.Tables[0].Rows[0]["IdContrato"].ToString()) + 1;
                }
                else
                {
                    consecutivo = 1;
                }

                return consecutivo;

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);

                return consecutivo;
            }
        }

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

                    cmbEstadoCivil.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));

                    cmbEstadoCivilFiador.DataSource = dsCivil;
                    cmbEstadoCivilFiador.DataValueField = "IdEstadoCivil";
                    cmbEstadoCivilFiador.DataTextField = "Descripcion";
                    cmbEstadoCivilFiador.DataBind();

                    cmbEstadoCivilFiador.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        private void GetArrendatarios(int busqueda, int idArrendatario)
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
                        cmbArrendatario.DataSource = dsTipoIdentificacion;
                        cmbArrendatario.DataValueField = "IdArrendatario";
                        cmbArrendatario.DataTextField = "NombreCompleto";
                        cmbArrendatario.DataBind();

                        cmbArrendatario.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));

                    }
                }
                else
                {
                    dsTipoIdentificacion = inmobiliaria.GetArrendatarios(idArrendatario);

                    if (dsTipoIdentificacion.Tables[0].Rows.Count > 0)
                    {
                        txtEdad.Text = dsTipoIdentificacion.Tables[0].Rows[0]["Edad"].ToString();
                        txtUltimoGradoEstudio.Text = dsTipoIdentificacion.Tables[0].Rows[0]["UltimoGradoEstudio"].ToString();
                        txtCarreraOficio.Text = dsTipoIdentificacion.Tables[0].Rows[0]["CarreraOficio"].ToString();
                        cmbEstadoArrendatario.SelectedValue = dsTipoIdentificacion.Tables[0].Rows[0]["IdEstado"].ToString();
                        GetMunicipiosArrendatario(int.Parse(cmbEstadoArrendatario.SelectedValue));
                        cmbMunicipioArrendatario.SelectedValue = dsTipoIdentificacion.Tables[0].Rows[0]["IdMunicipio"].ToString();
                        GetAsentamientosArrendatario(int.Parse(cmbMunicipioArrendatario.SelectedValue));
                        cmbAsentamientoArrendatario.SelectedValue = dsTipoIdentificacion.Tables[0].Rows[0]["IdAsentamiento"].ToString();
                        txtNumPersonasHabitar.Text = dsTipoIdentificacion.Tables[0].Rows[0]["NumPersonasHabitar"].ToString();
                        txtNumPersonasDependen.Text = dsTipoIdentificacion.Tables[0].Rows[0]["NumPersonasDependen"].ToString();
                        cmbEstadoCivil.SelectedValue = dsTipoIdentificacion.Tables[0].Rows[0]["IdEstadoCivil"].ToString();
                        txtMovilArrendatario.Text = dsTipoIdentificacion.Tables[0].Rows[0]["Movil"].ToString();
                        txtEmpresaTrabaja.Text = dsTipoIdentificacion.Tables[0].Rows[0]["EmpresaTrabaja"].ToString();
                        txtAntiguedadArrendatario.Text = dsTipoIdentificacion.Tables[0].Rows[0]["Antiguedad"].ToString();
                        txtHorario.Text = dsTipoIdentificacion.Tables[0].Rows[0]["Horario"].ToString();
                        txtDireccionEmpleo.Text = dsTipoIdentificacion.Tables[0].Rows[0]["DireccionEmpleo"].ToString();
                        txtFijoArrendatario.Text = dsTipoIdentificacion.Tables[0].Rows[0]["Fijo"].ToString();
                        txtNombreJefe.Text = dsTipoIdentificacion.Tables[0].Rows[0]["NombreJefe"].ToString();
                        txtPuestoEmpleo.Text = dsTipoIdentificacion.Tables[0].Rows[0]["PuestoEmpleo"].ToString();
                        txtSalarioMensual.Text = dsTipoIdentificacion.Tables[0].Rows[0]["SalarioMensual"].ToString();
                        txtMotivoCambio.InnerText = dsTipoIdentificacion.Tables[0].Rows[0]["MotivoCambio"].ToString();
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
                        cmbTipoIdentificacionArrendatario.SelectedValue = dsTipoIdentificacion.Tables[0].Rows[0]["IdTipoIdentificacion"].ToString();
                    }
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

                        cmbTipoIdentificacion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));

                        cmbTipoIdentificacionArrendatario.DataSource = dsTipoIdentificacion;
                        cmbTipoIdentificacionArrendatario.DataValueField = "IdTipoIdentificacion";
                        cmbTipoIdentificacionArrendatario.DataTextField = "Descripcion";
                        cmbTipoIdentificacionArrendatario.DataBind();

                        cmbTipoIdentificacionArrendatario.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));

                    }
                }
                else
                {
                    dsTipoIdentificacion = catalogos.GetTipoIdentificacion(idTipoIdentificacion);

                    if (dsTipoIdentificacion.Tables[0].Rows.Count > 0)
                    {
                        cmbTipoIdentificacion.SelectedValue = dsTipoIdentificacion.Tables[0].Rows[0]["IdTipoIdentificacion"].ToString();

                        cmbTipoIdentificacionArrendatario.SelectedValue = dsTipoIdentificacion.Tables[0].Rows[0]["IdTipoIdentificacion"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        private void GetArrendadores(int busqueda, int idArrendador)
        {
            BTLInmobiliaria.Inmobiliaria inmobiliaria = new BTLInmobiliaria.Inmobiliaria(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsTipoIdentificacion = new DataSet();

            try
            {
                if (busqueda == 0)
                {
                    dsTipoIdentificacion = inmobiliaria.GetArrendadores(0);

                    if (dsTipoIdentificacion.Tables[0].Rows.Count > 0)
                    {
                        cmbArrendador.DataSource = dsTipoIdentificacion;
                        cmbArrendador.DataValueField = "IdArrendador";
                        cmbArrendador.DataTextField = "NombreCompleto";
                        cmbArrendador.DataBind();

                        cmbArrendador.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));

                    }
                }
                else
                {
                    dsTipoIdentificacion = inmobiliaria.GetArrendadores(idArrendador);

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
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        private void GetAsentamientosArrendatario(int idMunicipio)
        {
            BTLInmobiliaria.Catalogos catalogos = new BTLInmobiliaria.Catalogos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsAsentamiento = new DataSet();

            try
            {
                dsAsentamiento = catalogos.GetAsentamientos(idMunicipio);

                if (dsAsentamiento.Tables[0].Rows.Count > 0)
                {
                    cmbAsentamientoArrendatario.DataSource = dsAsentamiento;
                    cmbAsentamientoArrendatario.DataValueField = "IdAsentamiento";
                    cmbAsentamientoArrendatario.DataTextField = "Descripcion";
                    cmbAsentamientoArrendatario.DataBind();

                    cmbAsentamientoArrendatario.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        private void GetMunicipiosArrendatario(int idEstado)
        {
            BTLInmobiliaria.Catalogos catalogos = new BTLInmobiliaria.Catalogos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsMunicipio = new DataSet();

            try
            {
                dsMunicipio = catalogos.GetMunicipios(idEstado);

                if (dsMunicipio.Tables[0].Rows.Count > 0)
                {
                    cmbMunicipioArrendatario.DataSource = dsMunicipio;
                    cmbMunicipioArrendatario.DataValueField = "IdMunicipio";
                    cmbMunicipioArrendatario.DataTextField = "Descripcion";
                    cmbMunicipioArrendatario.DataBind();

                    cmbMunicipioArrendatario.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        private void GetEstadosArrendatario()
        {
            BTLInmobiliaria.Catalogos catalogos = new BTLInmobiliaria.Catalogos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsEstados = new DataSet();

            try
            {
                dsEstados = catalogos.GetEstados();

                if (dsEstados.Tables[0].Rows.Count > 0)
                {
                    cmbEstadoArrendatario.DataSource = dsEstados;
                    cmbEstadoArrendatario.DataValueField = "IdEstado";
                    cmbEstadoArrendatario.DataTextField = "Descripcion";
                    cmbEstadoArrendatario.DataBind();

                    cmbEstadoArrendatario.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));
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

                    cmbAsentamiento.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));

                    cmbAsentamientoArrendatario.DataSource = dsAsentamiento;
                    cmbAsentamientoArrendatario.DataValueField = "IdAsentamiento";
                    cmbAsentamientoArrendatario.DataTextField = "Descripcion";
                    cmbAsentamientoArrendatario.DataBind();

                    cmbAsentamientoArrendatario.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));
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

                    cmbMunicipio.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));

                    cmbMunicipioArrendatario.DataSource = dsMunicipio;
                    cmbMunicipioArrendatario.DataValueField = "IdMunicipio";
                    cmbMunicipioArrendatario.DataTextField = "Descripcion";
                    cmbMunicipioArrendatario.DataBind();

                    cmbMunicipioArrendatario.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));
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

                    cmbEstado.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));

                    cmbEstadoArrendatario.DataSource = dsEstados;
                    cmbEstadoArrendatario.DataValueField = "IdEstado";
                    cmbEstadoArrendatario.DataTextField = "Descripcion";
                    cmbEstadoArrendatario.DataBind();

                    cmbEstadoArrendatario.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
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

                    cmbTipoPropiedad.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
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
                        cmbInmueble.DataSource = dsInmuebles;
                        cmbInmueble.DataValueField = "IdInmueble";
                        cmbInmueble.DataTextField = "NombreInmueble";
                        cmbInmueble.DataBind();

                        cmbInmueble.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));
                    }
                }
                else
                {
                    dsInmuebles = inmobiliaria.GetInmuebles(idInmueble);

                    if (dsInmuebles.Tables[0].Rows.Count > 0)
                    {
                        txtDescripcion.Text = dsInmuebles.Tables[0].Rows[0]["Descripcion"].ToString();
                        txtCostoTotal.Text = dsInmuebles.Tables[0].Rows[0]["CostoTotal"].ToString();
                        txtCostoMensual.Text = dsInmuebles.Tables[0].Rows[0]["CostoMensual"].ToString();
                        txtCostoMantenimiento.Text = dsInmuebles.Tables[0].Rows[0]["CostoMto"].ToString();
                        txtAntiguedad.Text = dsInmuebles.Tables[0].Rows[0]["Antiguedad"].ToString();
                        cmbTipoPropiedad.SelectedValue = dsInmuebles.Tables[0].Rows[0]["IdTipoPropiedad"].ToString();
                        txtCalleInmueble.Text = dsInmuebles.Tables[0].Rows[0]["Calle"].ToString();
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
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
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

                    cmbEstatusInmueble.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        public void GenerarContratoCarta(DatosContrato datosContrato, int? idContrato)
        {
            BTLInmobiliaria.Contratos contratos = new BTLInmobiliaria.Contratos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());

            string s1, s2;
            string pathContrato, fileNameContrato;
            string pathCarta, fileNameCarta;

            try
            {
                //Contrato
                s1 = File.ReadAllText(Server.MapPath("~/Contratos/") + "Contrato.html", Encoding.UTF8);

                s1 = s1.Replace("#DireccionInmueble#", datosContrato.DireccionInmueble.ToUpper());
                s1 = s1.Replace("#NombreArrendador#", datosContrato.NombreArrendador.ToUpper());
                s1 = s1.Replace("#NombreFiador#", datosContrato.NombreFiador.ToUpper());
                s1 = s1.Replace("#CantidadMensual#", datosContrato.CantidadMensual);
                s1 = s1.Replace("#NombreArrendatario#", datosContrato.NombreArrendatario.ToUpper());
                //s1 = s1.Replace("#DireccionArrendatario#", datosContrato.DireccionArrendatario.ToUpper());
                s1 = s1.Replace("#DireccionFiador#", datosContrato.DireccionFiador.ToUpper());
                s1 = s1.Replace("#Fecha#", datosContrato.Fecha);

                fileNameContrato = "Contrato-" + datosContrato.NumContrato + ".pdf";
                pathContrato = Server.MapPath("~/Inmuebles/Tmp/") + "Contrato-" + datosContrato.NumContrato + ".pdf";


                StringReader stringReaderContrato = new StringReader(s1);
                Document pdfDocContrato = new Document(PageSize.A4);
                HTMLWorker htmlParserContrato = new HTMLWorker(pdfDocContrato);


                using (MemoryStream memoryStream = new MemoryStream())
                {

                    PdfWriter wri = PdfWriter.GetInstance(pdfDocContrato, new FileStream(Server.MapPath("~/Inmuebles/Tmp/") + "Contrato-" + datosContrato.NumContrato + ".pdf", FileMode.Create));

                    pdfDocContrato.Open();

                    htmlParserContrato.Parse(stringReaderContrato);
                    pdfDocContrato.Close();

                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();

                }

                //Carta

                s2 = File.ReadAllText(Server.MapPath("~/Contratos/") + "CartaResicion.html", Encoding.UTF8);

                s2 = s2.Replace("#NombreArrendatario#", datosContrato.NombreArrendatario.ToUpper());
                s2 = s2.Replace("#DireccionInmueble#", datosContrato.DireccionInmueble.ToUpper());
                s2 = s2.Replace("#NombreArrendatario#", datosContrato.NombreArrendatario.ToUpper());

                fileNameCarta = "Carta-" + datosContrato.NumContrato + ".pdf";
                pathCarta = Server.MapPath("~/Inmuebles/Tmp/") + "Carta-" + datosContrato.NumContrato + ".pdf";

                StringReader stringReaderCarta = new StringReader(s2);
                Document pdfDocCarta = new Document(PageSize.A4);
                HTMLWorker htmlParserCarta = new HTMLWorker(pdfDocCarta);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    PdfWriter wri = PdfWriter.GetInstance(pdfDocCarta, new FileStream(Server.MapPath("~/Inmuebles/Tmp/") + "Carta-" + datosContrato.NumContrato + ".pdf", FileMode.Create));

                    pdfDocCarta.Open();

                    htmlParserCarta.Parse(stringReaderCarta);
                    pdfDocCarta.Close();

                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();

                }

                contratos.InsertArchivoContrato(fileNameContrato, pathContrato, Convert.ToInt32(idContrato));
                contratos.InsertArchivoCartas(fileNameCarta, pathCarta, Convert.ToInt32(idContrato));
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        public string RellenarCadena(string numeroContrato)
        {
            numeroContrato = numeroContrato.PadLeft(6, '0');

            return numeroContrato;
        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    cmbMunicipio.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));
                    cmbAsentamiento.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));
                    cmbMunicipioArrendatario.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));
                    cmbAsentamientoArrendatario.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));

                    GetContratos();
                    GetEstadoCivil();
                    GetInmuebles(0);
                    GetTipoPropiedad();
                    GetEstados();
                    GetEstadosArrendatario();
                    GetEstatusInmueble();
                    GetArrendadores(0, 0);
                    GetTipoIdentificacion(0, 0);
                    GetArrendatarios(0, 0);
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
                GetInmuebles(int.Parse(cmbInmueble.SelectedValue));
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void cmbArrendador_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetArrendadores(1, int.Parse(cmbArrendador.SelectedValue));
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void cmbArrendatario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetArrendatarios(1, int.Parse(cmbArrendatario.SelectedValue));
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            BTLInmobiliaria.Contratos contratos = new BTLInmobiliaria.Contratos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DatosContrato datosContrato = new DatosContrato();
            Moneda moneda = new Moneda();

            // Insercion
            int idInmueble = int.Parse(cmbInmueble.SelectedItem.Value);
            int idArrendador = int.Parse(cmbArrendador.SelectedItem.Value);
            int idArrendatario = int.Parse(cmbArrendatario.SelectedItem.Value);
            int idUsuario = int.Parse(Session["IdUsuario"].ToString());
            double cantidadNumero = double.Parse(txtCostoMensual.Text);
            string cantidadLetra = moneda.Convertir(txtCostoMensual.Text, true, "PESOS");

            // DatosContrato
            datosContrato.NumContrato = txtNumContrato.Text.Trim();
            datosContrato.DireccionInmueble = txtCalleInmueble.Text + ", " + cmbAsentamiento.SelectedItem.Text + ", " + cmbMunicipio.SelectedItem.Text + ", " + cmbEstado.SelectedItem.Text;
            datosContrato.NombreArrendador = cmbArrendador.SelectedItem.Text;
            datosContrato.NombreArrendatario = cmbArrendatario.SelectedItem.Text;
            datosContrato.DireccionArrendatario =  cmbAsentamientoArrendatario.SelectedItem.Text + ", " + cmbMunicipioArrendatario.SelectedItem.Text + ", " + cmbEstadoArrendatario.SelectedItem.Text;
            datosContrato.NombreFiador = txtNombreFiador.Text;
            datosContrato.DireccionFiador = txtDireccionFiador.Text;
            datosContrato.CantidadMensual = cantidadNumero.ToString("C") + " " + cantidadLetra;
            datosContrato.Fecha = DateTime.Now.ToLongDateString();

            try
            {
                int? idContrato = contratos.InserContrato(txtNumContrato.Text.Trim(), int.Parse(txtMesesContrato.Text.Trim()), int.Parse(txtAnioContrato.Text.Trim()), txtFechaInicioContrato.Text.Trim(), txtFechaFinContrato.Text.Trim()
                     , idArrendador, idArrendatario, idInmueble, idUsuario);

                if (idContrato == 0)
                {
                    ShowMessage("El inmueble ya contiene un contrato vigente", MessageType.Advertencia);

                    LimpiarControles();

                    GetContratos();

                }
                else
                {
                    GenerarContratoCarta(datosContrato, idContrato);

                    ShowMessage("El registro ha sido guardado exitosamente.", MessageType.Exito);

                    GetContratos();
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
                txtNumContrato.Text = "IMSERV" + RellenarCadena(GetNumeroContrato().ToString());

                LimpiarControles();

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void txtFechaFinContrato_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime inicio = DateTime.Parse(txtFechaInicioContrato.Text);
                DateTime final = DateTime.Parse(txtFechaFinContrato.Text);

                int months;
                var totalYears = final - inicio;
                
                double years = (double)(totalYears.TotalDays / 365.25);

                if (years > 0)
                {
                    months = Convert.ToInt32(Math.Round(years * 12));
                }
                else
                {
                    months = Convert.ToInt32(Math.Round((decimal)(((totalYears.TotalDays / 365.25) - years) * 12)));
                }

                txtAnioContrato.Text = Math.Round(years).ToString();
                txtMesesContrato.Text = months.ToString();

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void ibtnContratos_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton button = (ImageButton)sender;
                GridViewRow namingContainer = button.NamingContainer as GridViewRow;

                ViewState["UbicacionContrato"] = grdContratos.DataKeys[namingContainer.RowIndex].Values["UbicacionContrato"].ToString();

                DownloadContrato(ViewState["UbicacionContrato"].ToString());

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        protected void ibtnCartaRecision_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton button = (ImageButton)sender;
                GridViewRow namingContainer = button.NamingContainer as GridViewRow;

                ViewState["UbicacionCarta"] = grdContratos.DataKeys[namingContainer.RowIndex].Values["UbicacionCarta"].ToString();

                DownloadCarta(ViewState["UbicacionCarta"].ToString());
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

        #endregion

    }
}