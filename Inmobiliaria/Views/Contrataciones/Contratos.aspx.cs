using BTLInmobiliaria;
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

namespace Inmobiliaria.Views.Contrataciones
{
    public partial class Contratos : System.Web.UI.Page
    {
        #region Methods

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
            catch (Exception)
            {

                throw;
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

                        cmbArrendatario.Items.Insert(0, new ListItem("Seleccione..."));

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
            catch (Exception)
            {

                throw;
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

                        cmbTipoIdentificacionArrendatario.DataSource = dsTipoIdentificacion;
                        cmbTipoIdentificacionArrendatario.DataValueField = "IdTipoIdentificacion";
                        cmbTipoIdentificacionArrendatario.DataTextField = "Descripcion";
                        cmbTipoIdentificacionArrendatario.DataBind();

                        cmbTipoIdentificacionArrendatario.Items.Insert(0, new ListItem("Seleccione..."));

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
            catch (Exception)
            {

                throw;
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

                        cmbArrendador.Items.Insert(0, new ListItem("Seleccione..."));

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
            catch (Exception)
            {

                throw;
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

                    cmbAsentamientoArrendatario.Items.Insert(0, new ListItem("Seleccione..."));
                }
            }
            catch (Exception)
            {

                throw;
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

                    cmbMunicipioArrendatario.Items.Insert(0, new ListItem("Seleccione..."));
                }
            }
            catch (Exception)
            {

                throw;
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

                    cmbEstadoArrendatario.Items.Insert(0, new ListItem("Seleccione..."));
                }
            }
            catch (Exception)
            {

                throw;
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

                    cmbAsentamientoArrendatario.DataSource = dsAsentamiento;
                    cmbAsentamientoArrendatario.DataValueField = "IdAsentamiento";
                    cmbAsentamientoArrendatario.DataTextField = "Descripcion";
                    cmbAsentamientoArrendatario.DataBind();

                    cmbAsentamientoArrendatario.Items.Insert(0, new ListItem("Seleccione..."));
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

                    cmbMunicipioArrendatario.DataSource = dsMunicipio;
                    cmbMunicipioArrendatario.DataValueField = "IdMunicipio";
                    cmbMunicipioArrendatario.DataTextField = "Descripcion";
                    cmbMunicipioArrendatario.DataBind();

                    cmbMunicipioArrendatario.Items.Insert(0, new ListItem("Seleccione..."));
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

                    cmbEstadoArrendatario.DataSource = dsEstados;
                    cmbEstadoArrendatario.DataValueField = "IdEstado";
                    cmbEstadoArrendatario.DataTextField = "Descripcion";
                    cmbEstadoArrendatario.DataBind();

                    cmbEstadoArrendatario.Items.Insert(0, new ListItem("Seleccione..."));
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

                        cmbInmueble.Items.Insert(0, new ListItem("Seleccione..."));
                    }
                }
                else
                {
                    dsInmuebles = inmobiliaria.GetInmuebles(idInmueble);

                    if (dsInmuebles.Tables[0].Rows.Count > 0)
                    {
                        //txtNombreInmueble.Text = dsInmuebles.Tables[0].Rows[0]["NombreInmueble"].ToString();
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

        public string GenerarContrato(DatosContrato datosContrato)
        {
            var renderer = new IronPdf.HtmlToPdf();

            string s1, s2;

            //string pathPhsy = HostingEnvironment.ApplicationPhysicalPath.ToString();
            //string completePath = pathPhsy + @"\Contratos\";

            s1 = File.ReadAllText(Server.MapPath("~/Contratos/") + "Contrato.html", Encoding.UTF8);


            s1 = s1.Replace("#DireccionInmueble#", datosContrato.DireccionInmueble);
            s1 = s1.Replace("#NombreArrendador#", datosContrato.NombreArrendador);
            s1 = s1.Replace("#NombreFiador#", datosContrato.NombreFiador);
            s1 = s1.Replace("#CantidadMensual#", datosContrato.CantidadMensual);
            s1 = s1.Replace("#NombreArrendatario#", datosContrato.NombreArrendatario);
            s1 = s1.Replace("#DireccionFiador#", datosContrato.DireccionFiador);
            s1 = s1.Replace("#Fecha#", datosContrato.Fecha);


            s2 = File.ReadAllText(Server.MapPath("~/Contratos/") + "CartaResicion.html", Encoding.UTF8);

            s2 = s2.Replace("#NombreArrendatario#", datosContrato.NombreArrendatario);
            s2 = s2.Replace("#DireccionInmueble#", datosContrato.DireccionInmueble);
            s2 = s2.Replace("#NombreArrendatario#", datosContrato.NombreArrendatario);
            

            var n = Guid.NewGuid().ToString().ToUpper().Replace("-", "");

            //StringReader stringReader = new StringReader(s1);

            //iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);

            //HTMLWorker htmlParser = new HTMLWorker(pdfDoc);

            //using (MemoryStream memoryStream = new MemoryStream())
            //{
            //    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);

            //    pdfDoc.Open();

            //    htmlParser.Parse(stringReader);
            //    pdfDoc.Close();

            //    byte[] bytes = memoryStream.ToArray();
            //    memoryStream.Close();

            //    Response.Clear();
            //    Response.ContentType = "application/force-download";
            //    Response.AddHeader("content-disposition", "attachment; filename=" + n + "Contrato.pdf");
            //    Response.BufferOutput = false;
            //    Response.BinaryWrite(bytes);
            //    Response.Flush();
            //    Response.Close();
            //}




            renderer.RenderHtmlAsPdf(s1).SaveAs(Server.MapPath("~/Inmuebles/Tmp/") + n + "Contrato.pdf");

            renderer.RenderHtmlAsPdf(s2).SaveAs(Server.MapPath("~/Inmuebles/Tmp/") + n + "CartaResicion.pdf");

            System.Diagnostics.Process.Start(Server.MapPath("~/Inmuebles/Tmp/") + n + "Contrato.pdf");
            System.Diagnostics.Process.Start(Server.MapPath("~/Inmuebles/Tmp/") + n + "CartaResicion.pdf");

            return "Contrato.pdf";

        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
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
            catch (Exception)
            {

                throw;
            }
        }

        protected void cmbInmueble_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetInmuebles(int.Parse(cmbInmueble.SelectedValue));
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void cmbArrendador_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetArrendadores(1, int.Parse(cmbArrendador.SelectedValue));
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void cmbArrendatario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetArrendatarios(1, int.Parse(cmbArrendatario.SelectedValue));
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btn_GenerarContrato_Click(object sender, EventArgs e)
        {
            BTLInmobiliaria.DatosContrato datosContrato = new DatosContrato();

            try
            {
                datosContrato.DireccionInmueble = cmbAsentamiento.SelectedItem.Text + " " + cmbMunicipio.SelectedItem.Text + " " + cmbEstado.SelectedItem.Text;
                datosContrato.NombreArrendador = cmbArrendador.SelectedItem.Text;
                datosContrato.NombreArrendatario = cmbArrendatario.SelectedItem.Text;
                datosContrato.NombreFiador = txtNombreFiador.Text;
                datosContrato.DireccionFiador = txtDireccionFiador.Text;
                datosContrato.CantidadMensual = txtCostoMensual.Text;
                datosContrato.Fecha = DateTime.Now.ToLongDateString();

                GenerarContrato(datosContrato);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}