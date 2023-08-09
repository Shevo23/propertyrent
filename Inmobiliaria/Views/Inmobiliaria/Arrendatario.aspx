<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Arrendatario.aspx.cs" MasterPageFile="~/Master/Site.Master" Inherits="Inmobiliaria.Views.Inmobiliaria.Arrendatario" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />
        <br />
        <br />
        <div id="divAgregarArchivos" class="modal fade" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog modal-xl" role="document">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <h5>Archivos del arrendatario</h5>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroupFile">Cargar</span>
                                            </div>
                                            <div class="custom-file">
                                                <asp:FileUpload runat="server" type="file" class="custom-file-input" ID="flpArchivosInmueble" aria-describedby="inputGroupFile"
                                                    AllowMultiple="true" accept=".png,.jpg,.jpeg" />
                                                <label class="custom-file-label" for="flpFotosInmueble">Seleccione archivos</label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="grdArchivos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered"
                                                    OnRowDataBound="grdArchivos_RowDataBound" DataKeyNames="IdArchivoArrendatario,NombreArchivo,IdArrendatario">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-BackColor="#9c9c9c">
                                                            <ItemTemplate>
                                                                <asp:ImageButton runat="server" ID="ibtnEliminarArchivo" ToolTip="Eliminar" ImageUrl="~/Images/borrar.png" Width="20px" OnClick="ibtnEliminarArchivo_Click" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IdArchivoArrendatario" HeaderText="#" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                                        <asp:BoundField DataField="IdArrendatario" HeaderText="Id Inmueble" Visible="false" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                                        <asp:BoundField DataField="NombreArchivo" HeaderText="Nombre del archivo" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                                        <asp:TemplateField ControlStyle-CssClass="img-thumbnail" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Image ID="archivo" runat="server" Height="100px" Width="200px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="grdArchivos" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button Text="Cargar archivos" CssClass="btn btn-success" ID="btnGuardarArchivosArrendatario" runat="server" OnClick="btnGuardarArchivosArrendatario_Click" />
                                <asp:Button Text="Cerrar" class="btn btn-info" runat="server" data-dismiss="modal" />
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnGuardarArchivosArrendatario" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <div id="divAgregar" class="modal fade" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog modal-xl" role="document">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal‐title">
                                    <asp:Label runat="server" ID="lbl_Titulo"></asp:Label></h4>
                                <button type="button" class="close" data-dismiss="modal">&times;</button>

                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <h5>Datos personales</h5>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing-sm">Nombre(s):</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombres" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing-s">Paterno:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtPaterno" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing-">Materno:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtMaterno" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-2">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing">Edad:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtEdad" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <label class="input-group-text" for="cmbEstado">Estado:</label>
                                            </div>
                                            <asp:DropDownList CssClass="custom-select" runat="server" ID="cmbEstado" AutoPostBack="true" OnSelectedIndexChanged="cmbEstado_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <label class="input-group-text" for="cmbMunicipio">Municipio:</label>
                                            </div>
                                            <asp:DropDownList CssClass="custom-select" runat="server" ID="cmbMunicipio" AutoPostBack="true" OnSelectedIndexChanged="cmbMunicipio_SelectedIndexChanged"></asp:DropDownList>
                                        </div>

                                    </div>
                                    <div class="col-sm-3">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <label class="input-group-text" for="cmbAsentamiento">Colonia:</label>
                                            </div>
                                            <asp:DropDownList CssClass="custom-select" runat="server" ID="cmbAsentamiento"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGrp-sizing">Ultimo grado de estudios:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtUltimoGradoEstudio" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inpurp-sizing">Carrera / oficio:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtCarreraOficio" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGrou-sizin">Movil:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtMovil" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-zin">Num personas a habitar:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNumPersonasHabitar" aria-label="Sizing example input" aria-describedby="inputGroup-zin"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inpuroup-zin">Personas dependan usted:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNumPersonasDependen" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <label class="input-group-text" for="cmbAsentamiento">Estado civil:</label>
                                            </div>
                                            <asp:DropDownList CssClass="custom-select" runat="server" ID="cmbEstadoCivil"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <label class="input-group-text" for="cmbTipoPropiedad">Tipo de indentificación:</label>
                                            </div>
                                            <asp:DropDownList CssClass="custom-select" runat="server" ID="cmbTipoIdentificacion"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:CheckBox ID="chk_Estatus" runat="server" />
                                        <asp:Label runat="server" ID="Label2" Text="Activo"></asp:Label>
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-sm-12">
                                        <h5>Empleo actual</h5>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inpurosup-zin">Empresa:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmpresaTrabaja" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inpuroesup-zin">Antigüedad:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtAntiguedad" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inpsuroesup-zin">Horario:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtHorario" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inpsurewoesp-zin">Puesto:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtPuestoEmpleo" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizinp">Jefe inmediato:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombreJefe" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizi">Salario mensual:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtSalarioMensual" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-5">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inpsurewoesup-zin">Dirección:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtDireccionEmpleo" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizin">Teléfono fijo:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtFijo" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-sm-12">
                                        <h5>Familiares a habitar</h5>
                                    </div>
                                </div>
                                <div class="row">
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-sm-12">
                                        <h5>Datos generales</h5>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Motivo por el que cambia de residencia</span>
                                            </div>
                                            <textarea runat="server" id="txtMotivoCambio" class="form-control" aria-label="With textarea" aria-multiline="true"></textarea>
                                        </div>
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-sm-12">
                                        <h5>Datos del fiador</h5>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-5">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroupm-sizinp">Relación con el arrendatario:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtRelacionFiador" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroupm-ssizinp">Nombre completo:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombreFiador" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-5">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGrosupm-ssizinp">Dirección:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtDireccionFiador" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGrosuapm-ssizinp">Teléfono:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtTelefonoFiador" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGrosuapma-ssizinp">Movil:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtMovilFiador" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <label class="input-group-text" for="cmbAsentamiento">Estado civil:</label>
                                            </div>
                                            <asp:DropDownList CssClass="custom-select" runat="server" ID="cmbEstadoCivilFiador"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGrsuapma-ssizinp">Años matrimonio:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtTiempoMatrimonio" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGrsuapma-sszinp">Edad:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtEdadFiador" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputsuapma-sszinp">Donde trabaja:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmpresaTrabajaFiador" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputsuapya-sszinp">Puesto:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtPuestoEmpleoFiador" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputuapya-sszinp">Salario:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtSalarioMensualFiador" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-5">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputpya-sszinp">Dirección:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtDireccionEmpleoFiador" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-default btn-danger" Text="Cancelar" data-dismiss="modal" OnClick="btnCancelar_Click" />
                                <asp:Button ID="btn_Guardar" runat="server" CssClass="btn btn-default btn-success" Text="Guardar" ValidationGroup="Global" data-dismiss="modal" UseSubmitBehavior="false" OnClick="btn_Guardar_Click" />
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
                                <h4 class="card-title">Arrendatarios registrados</h4>
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
                                    <asp:GridView ID="grdArrendatario" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
                                        DataKeyNames="IdArrendatario">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-BackColor="#9c9c9c">
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="ibtnEditar" ToolTip="Editar" ImageUrl="~/Images/editar.png" Width="20px" data-toggle="modal" data-target="#divAgregar" OnClick="ibtnEditar_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-BackColor="#9c9c9c">
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="ibtnArchivos" ToolTip="Ver archivos" ImageUrl="~/Images/archivos.png" Width="15px" data-toggle="modal" data-target="#divAgregarArchivos" OnClick="ibtnArchivos_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IdArrendatario" HeaderText="#" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Nombres" HeaderText="Nombres" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Paterno" HeaderText="Paterno" Visible="false" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Materno" HeaderText="Materno" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" Visible="false" />
                                            <asp:BoundField DataField="Movil" HeaderText="Movil" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Fijo" HeaderText="Fijo" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="IdTipoIdentificacion" HeaderText="IdTipoIdentificacion" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" Visible="false" />
                                            <asp:BoundField DataField="FechaAlta" HeaderText="Fecha registro" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                            <asp:TemplateField HeaderText="Usado / Nuevo" Visible="false" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkActivo" runat="server" CssClass="pull-left" Checked='<%#Convert.ToBoolean(Eval("Activo")) %>' Enabled="false" />
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
</asp:Content>
