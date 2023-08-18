<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contratos.aspx.cs" MasterPageFile="~/Master/Site.Master" Inherits="Inmobiliaria.Views.Contrataciones.Contratos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />
        <br />
        <br />
        <div id="divAgregar" class="modal fade" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog modal-xl" role="document">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal‐title">
                                    <asp:Label runat="server" ID="lbl_Titulo"></asp:Label></h4>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-sm-5">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing-sm">Numero de contrato:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtNumContraro" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="container">
                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <ul class="nav nav-tabs" id="myTab" role="tablist">
                                                    <li class="nav-item">
                                                        <a class="nav-link active" id="home-tab" data-toggle="tab" href="#inmuebles" role="tab" aria-controls="inmuebles" aria-selected="true">Información del Inmueble</a>
                                                    </li>
                                                    <li class="nav-item">
                                                        <a class="nav-link" id="profile-tab" data-toggle="tab" href="#arrendador" role="tab" aria-controls="arrendador" aria-selected="false">Información del Arrendador</a>
                                                    </li>
                                                    <li class="nav-item">
                                                        <a class="nav-link" id="contact-tab" data-toggle="tab" href="#arrendatario" role="tab" aria-controls="arrendatario" aria-selected="false">Información del Arrendatario</a>
                                                    </li>
                                                </ul>
                                                <div class="tab-content" id="myTabContent">
                                                    <%-- Inmueble --%>
                                                    <div class="tab-pane fade show active" id="inmuebles" role="tabpanel" aria-labelledby="home-tab">
                                                        <br />
                                                        <div class="row">
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-4">
                                                                    <div class="input-group-prepend">
                                                                        <label class="input-group-text" for="cmbInmueble">Nombre del Inmueble:</label>
                                                                    </div>
                                                                    <asp:DropDownList CssClass="custom-select font-weight-bold" runat="server" ID="cmbInmueble" AutoPostBack="true" OnSelectedIndexChanged="cmbInmueble_SelectedIndexChanged"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-6">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGroup-sizing-">Descripcion:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtDescripcion" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGroup-sizing">Costo total:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtCostoTotal" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGroup">Costo mensual:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtCostoMensual" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGroup-sizin">Costo mantenimiento:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtCostoMantenimiento" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGroup-sizi">Antigüedad:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtAntiguedad" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <label class="input-group-text" for="cmbTipoPropiedad">Tipo propiedad</label>
                                                                    </div>
                                                                    <asp:DropDownList CssClass="custom-select font-weight-bold" runat="server" ID="cmbTipoPropiedad" Enabled="false"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <label class="input-group-text" for="cmbEstado">Estado:</label>
                                                                    </div>
                                                                    <asp:DropDownList CssClass="custom-select font-weight-bold" runat="server" ID="cmbEstado" AutoPostBack="true" Enabled="false"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <label class="input-group-text" for="cmbMunicipio">Municipio:</label>
                                                                    </div>
                                                                    <asp:DropDownList CssClass="custom-select font-weight-bold" runat="server" ID="cmbMunicipio" AutoPostBack="true" Enabled="false"></asp:DropDownList>
                                                                </div>

                                                            </div>
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <label class="input-group-text" for="cmbAsentamiento">Colonia:</label>
                                                                    </div>
                                                                    <asp:DropDownList CssClass="custom-select font-weight-bold" runat="server" ID="cmbAsentamiento" Enabled="false"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <label class="input-group-text" for="cmbEstatusInmueble">Estatus:</label>
                                                                    </div>
                                                                    <asp:DropDownList CssClass="custom-select font-weight-bold" runat="server" ID="cmbEstatusInmueble" Enabled="false"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <div class="form-group">
                                                                    <asp:CheckBox ID="chkNuevo" Text=" El inmueble es nuevo?" runat="server" Enabled="false" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"># recamaras:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtNumRecamaras" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"># baños:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtNumBanos" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"># servicios:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtNumServicios" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"># estacionamientos:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtNumEstacionamiento" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text">total m2:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtNumM2" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text">total construccion:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtNumTotal" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <div class="form-group">
                                                                    <asp:CheckBox ID="chkAlberca" Text=" Cuenta con alberca?" runat="server" Enabled="false" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <%-- Arrendador --%>
                                                    <div class="tab-pane fade" id="arrendador" role="tabpanel" aria-labelledby="profile-tab">
                                                        <br />
                                                        <div class="row">
                                                            <div class="col-md-5">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <label class="input-group-text" for="cmbInmueble">Nombre del Arrendador:</label>
                                                                    </div>
                                                                    <asp:DropDownList CssClass="custom-select font-weight-bold" runat="server" ID="cmbArrendador" AutoPostBack="true" OnSelectedIndexChanged="cmbArrendador_SelectedIndexChanged"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-4">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="intGroup-sizing-sm">Nombre(s):</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtNombres" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-4">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGroup-sizing-s">Paterno:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtPaterno" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-4">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGr-sizing-">Materno:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtMaterno" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-4">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGroup-sng">Correo electronico:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtEmail" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-4">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGrou-sizin">Movil:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtMovil" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-4">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputoup-sizin">Teléfono fijo:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtFijo" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-4">
                                                                    <div class="input-group-prepend">
                                                                        <label class="input-group-text" for="cmbTipoPropiedad">Tipo de indentificación:</label>
                                                                    </div>
                                                                    <asp:DropDownList CssClass="custom-select font-weight-bold" runat="server" ID="cmbTipoIdentificacion" Enabled="false"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <asp:CheckBox ID="chk_Estatus" runat="server" Enabled="false" />
                                                                <asp:Label runat="server" ID="Label2" Text="Activo"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <%-- Arrendatario --%>
                                                    <div class="tab-pane fade" id="arrendatario" role="tabpanel" aria-labelledby="contact-tab">
                                                        <br />
                                                        <div class="row">
                                                            <div class="col-md-5">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <label class="input-group-text" for="cmbArrendatario">Nombre del Arrendatario:</label>
                                                                    </div>
                                                                    <asp:DropDownList CssClass="custom-select font-weight-bold" runat="server" ID="cmbArrendatario" AutoPostBack="true"  OnSelectedIndexChanged="cmbArrendatario_SelectedIndexChanged"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-2">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGroup-sing">Edad:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtEdad" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <label class="input-group-text" for="cmbEstado">Estado:</label>
                                                                    </div>
                                                                    <asp:DropDownList CssClass="custom-select font-weight-bold" runat="server" ID="cmbEstadoArrendatario" AutoPostBack="true" Enabled="false"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <label class="input-group-text" for="cmbMunicipio">Municipio:</label>
                                                                    </div>
                                                                    <asp:DropDownList CssClass="custom-select font-weight-bold" runat="server" ID="cmbMunicipioArrendatario" AutoPostBack="true" Enabled="false"></asp:DropDownList>
                                                                </div>

                                                            </div>
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <label class="input-group-text" for="cmbAsentamiento">Colonia:</label>
                                                                    </div>
                                                                    <asp:DropDownList CssClass="custom-select font-weight-bold" runat="server" ID="cmbAsentamientoArrendatario" Enabled="false"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-6">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGrp-sizing">Ultimo grado de estudios:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtUltimoGradoEstudio" aria-label="Sizing example input" Enabled="false" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inpurp-sizing">Carrera / oficio:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtCarreraOficio" aria-label="Sizing example input" Enabled="false" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGrou-sizi">Movil:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtMovilArrendatario" aria-label="Sizing example input" Enabled="false" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGroup-zin">Num personas a habitar:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtNumPersonasHabitar" aria-label="Sizing example input" Enabled="false" aria-describedby="inputGroup-zin"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inpuroup-zin">Personas dependan usted:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtNumPersonasDependen" aria-label="Sizing example input" Enabled="false" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <label class="input-group-text" for="cmbAsentamiento">Estado civil:</label>
                                                                    </div>
                                                                    <asp:DropDownList CssClass="custom-select font-weight-bold" runat="server" ID="cmbEstadoCivil" Enabled="false"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <label class="input-group-text" for="cmbTipoPropiedad">Tipo de indentificación:</label>
                                                                    </div>
                                                                    <asp:DropDownList CssClass="custom-select font-weight-bold" runat="server" ID="cmbTipoIdentificacionArrendatario" Enabled="false"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inpurosup-zin">Empresa:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtEmpresaTrabaja" aria-label="Sizing example input" Enabled="false" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inpuroesup-zin">Antigüedad:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtAntiguedadArrendatario" aria-label="Sizing example input" Enabled="false" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inpsuroesup-zin">Horario:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtHorario" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inpsurewoesp-zin">Puesto:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtPuestoEmpleo" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGroup-sizinp">Jefe inmediato:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtNombreJefe" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inptGroup-sizi">Salario mensual:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtSalarioMensual" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-5">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inpsurewoesup-zin">Dirección:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtDireccionEmpleo" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inpudGroup-sizin">Teléfono fijo:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtFijoArrendatario" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-12">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text">Motivo por el que cambia de residencia</span>
                                                                    </div>
                                                                    <textarea runat="server" id="txtMotivoCambio" class="form-control font-weight-bold" aria-label="With textarea" aria-multiline="true" readonly="readonly"  ></textarea>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-5">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGroupm-sizinp">Relación con el arrendatario:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtRelacionFiador" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGroupm-ssizinp">Nombre completo:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtNombreFiador" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-5">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGrosupm-ssizinp">Dirección:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtDireccionFiador" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGrosuapm-ssizinp">Teléfono:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtTelefonoFiador" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGrosuapma-ssizinp">Movil:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtMovilFiador" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <label class="input-group-text" for="cmbAsentamiento">Estado civil:</label>
                                                                    </div>
                                                                    <asp:DropDownList CssClass="custom-select font-weight-bold" runat="server" ID="cmbEstadoCivilFiador" Enabled="false"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGrsuapma-ssizinp">Años matrimonio:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtTiempoMatrimonio" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputGrsuapma-sszinp">Edad:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtEdadFiador" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputsuapma-sszinp">Donde trabaja:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtEmpresaTrabajaFiador" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputsuapya-sszinp">Puesto:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtPuestoEmpleoFiador" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-4">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputuapya-sszinp">Salario:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtSalarioMensualFiador" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-5">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text" id="inputpya-sszinp">Dirección:</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtDireccionEmpleoFiador" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" data-dismiss="modal" />
                                <asp:Button ID="btn_GenerarContrato" runat="server" CssClass="btn btn-info" Text="Generar contrato" ValidationGroup="Global" data-dismiss="modal" UseSubmitBehavior="false" OnClick="btn_GenerarContrato_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btn_GenerarContrato" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>

        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                        <div class="row">
                            <div class="col-sm-10">
                                <h4 class="card-title">Contratos registrados</h4>
                            </div>
                            <div class="col-sm-2">
                                <asp:Button ID="btn_Agregar" runat="server" Text="Agregar" CssClass="btn btn-default btn-info" data-toggle="modal" data-target="#divAgregar" />
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div class="table table-responsive" style="font-size: small">
                                    <asp:GridView ID="grdContratos" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
                                        DataKeyNames="IdContrato">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-BackColor="#9c9c9c">
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="ibtnEditar" ToolTip="Editar" ImageUrl="~/Images/editar.png" Width="20px" data-toggle="modal" data-target="#divAgregar" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-BackColor="#9c9c9c">
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="ibtnImagenes" ToolTip="Ver imagenes" ImageUrl="~/Images/imagenes.png" Width="25px" data-toggle="modal" data-target="#divAgregarImagenes" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-BackColor="#9c9c9c">
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="ibtnArchivos" ToolTip="Ver archivos" ImageUrl="~/Images/archivos.png" Width="15px" data-toggle="modal" data-target="#divAgregarArchivos" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IdInmueble" HeaderText="#" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre Inmueble" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" Visible="false" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                            <asp:TemplateField HeaderText="Usado / Nuevo" Visible="false" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkNuevo" runat="server" CssClass="pull-left" Checked='<%#Convert.ToBoolean(Eval("Nuevo")) %>' Enabled="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CostoTotal" HeaderText="Costo total" DataFormatString="{0:C}" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="CostoMensual" HeaderText="Costo Mensual" DataFormatString="{0:C}" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Propiedad" HeaderText="Tipo Propiedad" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Asentamiento" HeaderText="Colonia" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Municipio" HeaderText="Municipio" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Estado" HeaderText="Estado" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="FechaAlta" HeaderText="Fecha registro" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="EstatusInmueble" HeaderText="Estatus" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btn_Agregar" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
