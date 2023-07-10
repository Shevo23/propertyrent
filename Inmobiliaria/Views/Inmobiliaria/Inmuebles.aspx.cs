using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inmobiliaria.Views
{
    public partial class Inmuebles : System.Web.UI.Page
    {
        #region Methods

        private void GetAsentamientos(int idMunicipio)
        {
            BTLInmobiliaria.Catalogos catalogos = new BTLInmobiliaria.Catalogos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
            DataSet dsAsentamiento = new DataSet();

            try
            {
                dsAsentamiento = catalogos.GetMunicipios(idMunicipio);

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

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GetEstados();
                    GetEstatusInmueble();
                    GetTipoPropiedad();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        protected void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetMunicipios(int.Parse(cmbEstado.SelectedValue));
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetAsentamientos(int.Parse(cmbMunicipio.SelectedValue));
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}