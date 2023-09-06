<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contratos.aspx.cs" MasterPageFile="~/Master/Site.Master" Inherits="Inmobiliaria.Views.Contrataciones.Contratos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />
        <br />
        <br />
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="messagealert" id="alert_container">
                </div>
            </div>
        </div>
        <br />
        <div id="divAgregar" class="modal fade" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog modal-xl" role="document">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal‐title">
                                    <asp:Label runat="server" ID="lbl_Titulo"></asp:Label></h4>
                            </div>
                            <div class="modal-body">

                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing-sm">Numero de contrato:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control font-weight-bold text-success" ID="txtNumContrato" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaInicioContrato"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Global"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGup-siz-sm">Fecha inicio contrato:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtFechaInicioContrato" aria-label="Sizing example input" TextMode="Date" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechaFinContrato"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Global"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inptGup-siz-sm">Fecha fin contrato:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtFechaFinContrato" aria-label="Sizing example input" TextMode="Date" aria-describedby="inputGroup-sizing-sm" AutoPostBack="True" OnTextChanged="txtFechaFinContrato_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizg-sm">Meses de contrato:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtMesesContrato" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGup-sizg-sm">Años de contrato:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtAnioContrato" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="container">
                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <ul class="nav nav-tabs nav-pills" id="myTab" role="tablist">
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
                                                    <%--inmuebles--%>
                                                    <div class="tab-pane fade show active" id="inmuebles" role="tabpanel" aria-labelledby="home-tab">
                                                        <br />
                                                        <div class="row">
                                                            <div class="col-sm-6">
                                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cmbInmueble"
                                                                    ValidationGroup="Global" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                                                    Type="Integer" ValueToCompare="0" Operator="GreaterThan" Display="Dynamic"></asp:CompareValidator>
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
                                                    <%--arrendador--%>
                                                    <div class="tab-pane fade" id="arrendador" role="tabpanel" aria-labelledby="profile-tab">
                                                        <br />
                                                        <div class="row">
                                                            <div class="col-md-5">
                                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="cmbArrendador"
                                                                    ValidationGroup="Global" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                                                    Type="Integer" ValueToCompare="0" Operator="GreaterThan" Display="Dynamic"></asp:CompareValidator>
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
                                                    <%--arrendatario--%>
                                                    <div class="tab-pane fade" id="arrendatario" role="tabpanel" aria-labelledby="contact-tab">
                                                        <br />
                                                        <div class="row">
                                                            <div class="col-md-5">
                                                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="cmbArrendatario"
                                                                    ValidationGroup="Global" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                                                    Type="Integer" ValueToCompare="0" Operator="GreaterThan" Display="Dynamic"></asp:CompareValidator>
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <label class="input-group-text" for="cmbArrendatario">Nombre del Arrendatario:</label>
                                                                    </div>
                                                                    <asp:DropDownList CssClass="custom-select font-weight-bold" runat="server" ID="cmbArrendatario" AutoPostBack="true" OnSelectedIndexChanged="cmbArrendatario_SelectedIndexChanged"></asp:DropDownList>
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
                                                                    <textarea runat="server" id="txtMotivoCambio" class="form-control font-weight-bold" aria-label="With textarea" aria-multiline="true" readonly="readonly"></textarea>
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
                                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" data-dismiss="modal" OnClick="btnCancelar_Click" />
                                <asp:Button ID="btnGuardar" Text="Guardar" runat="server" CssClass="btn btn-success" data-dismiss="modal" UseSubmitBehavior="false" OnClick="btnGuardar_Click" ValidationGroup="Global" />

                            </div>
                        </div>
                    </ContentTemplate>
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
                                <asp:Button ID="btn_Agregar" runat="server" Text="Agregar" CssClass="btn btn-default btn-info" data-toggle="modal" data-target="#divAgregar" OnClick="btn_Agregar_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div class="table table-responsive" style="font-size: small">
                                    <asp:GridView ID="grdContratos" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
                                        DataKeyNames="IdContrato, UbicacionContrato, IdArchivoContrato, UbicacionCarta">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-BackColor="#9c9c9c">
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="ibtnEliminar" ToolTip="Eliminar contrato" ImageUrl="~/Images/borrar.png" Width="15px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-BackColor="#9c9c9c" HeaderText="Contrato" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="ibtnContratos" ToolTip="Ver contrato" ImageUrl="~/Images/archivos.png" Width="15px" data-toggle="modal" data-target="#divAgregarImagenes" OnClick="ibtnContratos_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-BackColor="#9c9c9c" HeaderText="Recision" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="ibtnCartaRecision" ToolTip="Ver carta" ImageUrl="~/Images/archivos.png" Width="15px" data-toggle="modal" data-target="#divAgregarImagenes" OnClick="ibtnCartaRecision_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IdContrato" HeaderText="#" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" Visible="false" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="NumContrato" HeaderText="NumContrato" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="FechaVigenciaInicio" HeaderText="Inicio vigencia" Visible="false" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="FechaVigenciaFin" HeaderText="Fin vigencia" Visible="false" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="IdArrendador" HeaderText="IdArrendador" Visible="false" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="NombreArrendador" HeaderText="NombreArrendador" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="IdArrendatario" HeaderText="IdArrendatario" Visible="false" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="NombreArrendatario" HeaderText="NombreArrendatario" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="IdInmueble" HeaderText="IdInmueble" Visible="false" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="NombreInmueble" HeaderText="NombreInmueble" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="FechaAlta" HeaderText="Fecha registro" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="IdArchivoContrato" HeaderText="IdArchivoContrato" Visible="false" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="UbicacionContrato" HeaderText="UbicacionContrato" Visible="false" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="IdArchivoCarta" HeaderText="IdArchivoCarta" Visible="false" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="UbicacionCarta" HeaderText="UbicacionCarta" Visible="false" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:TemplateField HeaderText="Estatus" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEstatus" Style="color: white" Text='<%# Eval("Activo").ToString() == "1" ? "Activo" : "Inactivo" %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
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

    <script type="text/javascript">
        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Exito':
                    cssclass = 'alert alert-success'
                    break;
                case 'Error':
                    cssclass = 'alert alert-danger'
                    break;
                case 'Advertencia':
                    cssclass = 'alert alert-warning'
                    break;
                default:
                    cssclass = 'alert alert-info'
            }
            $('#alert_container').append('<div class="' + cssclass + '" role="alert"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <p>' + message + '</p></div>');
            $('#alert_container').fadeTo(2000, 500).slideUp(500, function () {
                $("#success-alert").slideUp(500);
            });
        }
    </script>

</asp:Content>

