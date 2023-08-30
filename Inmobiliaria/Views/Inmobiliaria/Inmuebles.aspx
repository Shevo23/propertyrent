<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inmuebles.aspx.cs" MasterPageFile="~/Master/Site.Master" Inherits="Inmobiliaria.Views.Inmuebles" %>

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
                                        <h5>Archivos del inmueble</h5>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="flpArchivosInmueble"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Archivos"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroupFile">Cargar</span>
                                            </div>
                                            <div class="custom-file">
                                                <asp:FileUpload runat="server" type="file" class="custom-file-input" ID="flpArchivosInmueble" aria-describedby="inputGroupFile"
                                                    AllowMultiple="true" accept=".png,.jpg,.jpeg" />
                                                <label class="custom-file-label" for="flpArchivosInmueble">Seleccione archivos</label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="grdArchivos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered"
                                                    OnRowDataBound="grdArchivos_RowDataBound" DataKeyNames="IdArchivoInmueble,NombreArchivo,IdInmueble">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-BackColor="#9c9c9c">
                                                            <ItemTemplate>
                                                                <asp:ImageButton runat="server" ID="ibtnEliminarArchivo" ToolTip="Eliminar" ImageUrl="~/Images/borrar.png" Width="20px" OnClick="ibtnEliminarArchivo_Click" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IdArchivoInmueble" HeaderText="#" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White"/>
                                                        <asp:BoundField DataField="IdInmueble" HeaderText="Id Inmueble" Visible="false" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White"/>
                                                        <asp:BoundField DataField="NombreArchivo" HeaderText="Nombre del archivo" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                                        <asp:TemplateField ControlStyle-CssClass="img-thumbnail" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White">
                                                            <ItemTemplate>
                                                                <asp:Image ID="archivo" runat="server" Height="100px" Width="100px" />
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
                                <asp:Button Text="Cargar archivos" CssClass="btn btn-success" ID="btnGuardarArchivosInmueble" ValidationGroup="Archivos" runat="server" OnClick="btnGuardarArchivosInmueble_Click" />
                                <asp:Button Text="Cerrar" class="btn btn-info" runat="server" data-dismiss="modal" />
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnGuardarArchivosInmueble" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <div id="divAgregarImagenes" class="modal fade" role="dialog" data-backdrop="static" data-keyboard="false">
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
                                        <h5>Imagenes del inmueble</h5>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="flpFotosInmueble"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Imagenes"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroupFileAddon01">Cargar</span>
                                            </div>
                                            <div class="custom-file">
                                                <asp:FileUpload runat="server" type="file" class="custom-file-input" ID="flpFotosInmueble" aria-describedby="inputGroupFileAddon01"
                                                    AllowMultiple="true" accept=".png,.jpg,.jpeg" />
                                                <label class="custom-file-label" for="flpFotosInmueble">Seleccione imagenes</label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="grdImagenes" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
                                                    OnRowDataBound="grdImagenes_RowDataBound" DataKeyNames="IdImagenInmueble,NombreImagen,IdInmueble">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-BackColor="#9c9c9c">
                                                            <ItemTemplate>
                                                                <asp:ImageButton runat="server" ID="ibtnEliminarImagen" ToolTip="Eliminar" ImageUrl="~/Images/borrar.png" Width="20px" OnClick="ibtnEliminarImagen_Click" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IdImagenInmueble" HeaderText="#" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                                        <asp:BoundField DataField="IdInmueble" HeaderText="Id Inmueble" Visible="false" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                                        <asp:BoundField DataField="NombreImagen" HeaderText="Nombre de la imagen" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                                        <asp:TemplateField ControlStyle-CssClass="img-thumbnail" HeaderText="Imagen" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White">
                                                            <ItemTemplate>
                                                                <asp:Image ID="img" runat="server" Height="100px" Width="100px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="grdImagenes"/>
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button Text="Cargar imagenes" CssClass="btn btn-success" ValidationGroup="Imagenes" ID="btnGuardarImagenInmueble" runat="server" OnClick="btnGuardarImagenInmueble_Click" />
                                <asp:Button Text="Cerrar" class="btn btn-info" runat="server" data-dismiss="modal" />
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnGuardarImagenInmueble" />
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
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal‐title">
                                    <asp:Label runat="server" ID="lbl_Titulo"></asp:Label></h4>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <h5>Caracteristicas generales</h5>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-5">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombreInmueble"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Global"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing-sm">Nombre del inmueble</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombreInmueble" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ValidChars=" " ID="FilteredTextBoxExtender1" runat="server" FilterType="LowercaseLetters, UppercaseLetters, Custom, Numbers" TargetControlID="txtNombreInmueble" />
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescripcion"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Global"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing-">Descripcion:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtDescripcion" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ValidChars=" " ID="FilteredTextBoxExtender2" runat="server" FilterType="LowercaseLetters, UppercaseLetters, Custom, Numbers" TargetControlID="txtNombreInmueble" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCostoTotal"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Global"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing">Costo total:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtCostoTotal" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers" TargetControlID="txtCostoTotal" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCostoMensual"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Global"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup">Renta mensual:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtCostoMensual" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Numbers" TargetControlID="txtCostoMensual" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCostoMantenimiento"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Global"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizin">Costo mantenimiento:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtCostoMantenimiento" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Numbers" TargetControlID="txtCostoMantenimiento" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">

                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizi">Antigüedad:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtAntiguedad" MaxLength="2" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterType="Numbers" TargetControlID="txtAntiguedad" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3">
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cmbTipoPropiedad"
                                                ValidationGroup="Global" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                                Type="Integer" ValueToCompare="0" Operator="GreaterThan" Display="Dynamic">
                                            </asp:CompareValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <label class="input-group-text" for="cmbTipoPropiedad">Tipo propiedad</label>
                                            </div>
                                            <asp:DropDownList CssClass="custom-select" runat="server" ID="cmbTipoPropiedad"></asp:DropDownList>
                                            
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="cmbEstado"
                                                ValidationGroup="Global" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                                Type="Integer" ValueToCompare="0" Operator="GreaterThan" Display="Dynamic">
                                            </asp:CompareValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <label class="input-group-text" for="cmbEstado">Estado:</label>
                                            </div>
                                            <asp:DropDownList CssClass="custom-select" runat="server" ID="cmbEstado" AutoPostBack="true" OnSelectedIndexChanged="cmbEstado_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="cmbMunicipio"
                                                ValidationGroup="Global" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                                Type="Integer" ValueToCompare="0" Operator="GreaterThan" Display="Dynamic">
                                            </asp:CompareValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <label class="input-group-text" for="cmbMunicipio">Municipio:</label>
                                            </div>
                                            <asp:DropDownList CssClass="custom-select" runat="server" ID="cmbMunicipio" AutoPostBack="true" OnSelectedIndexChanged="cmbMunicipio_SelectedIndexChanged"></asp:DropDownList>
                                        </div>

                                    </div>
                                    <div class="col-sm-3">
                                        <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="cmbAsentamiento"
                                                ValidationGroup="Global" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                                Type="Integer" ValueToCompare="0" Operator="GreaterThan" Display="Dynamic">
                                            </asp:CompareValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <label class="input-group-text" for="cmbAsentamiento">Colonia:</label>
                                            </div>
                                            <asp:DropDownList CssClass="custom-select" runat="server" ID="cmbAsentamiento"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3">
                                        <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="cmbEstatusInmueble"
                                                ValidationGroup="Global" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                                Type="Integer" ValueToCompare="0" Operator="GreaterThan" Display="Dynamic">
                                            </asp:CompareValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <label class="input-group-text" for="cmbEstatusInmueble">Estatus:</label>
                                            </div>
                                            <asp:DropDownList CssClass="custom-select" runat="server" ID="cmbEstatusInmueble"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <asp:CheckBox ID="chkNuevo" Text=" El inmueble es nuevo?" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-sm-12">
                                        <h5>Detalle del inmueble</h5>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNumRecamaras"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Global"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"># recamaras:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNumRecamaras" MaxLength="1" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterType="Numbers" TargetControlID="txtNumRecamaras" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtNumBanos"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Global"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"># baños:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNumBanos" MaxLength="1" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" FilterType="Numbers" TargetControlID="txtNumBanos" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtNumServicios"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Global"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"># servicios:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNumServicios" MaxLength="1" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" FilterType="Numbers" TargetControlID="txtNumServicios" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtNumEstacionamiento"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Global"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"># estacionamientos:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNumEstacionamiento" MaxLength="1" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" FilterType="Numbers" TargetControlID="txtNumEstacionamiento" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3">
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtNumM2"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Global"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">total m2:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNumM2" MaxLength="3" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" FilterType="Numbers" TargetControlID="txtNumM2" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtNumTotal"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Global"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">total construccion:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNumTotal" MaxLength="3" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" FilterType="Numbers" TargetControlID="txtNumTotal" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <asp:CheckBox ID="chkAlberca" Text=" Cuenta con alberca?" runat="server" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" data-dismiss="modal" OnClick="btnCancelar_Click" />
                                <asp:Button ID="btn_Guardar" runat="server" CssClass="btn btn-success" Text="Guardar" ValidationGroup="Global" data-dismiss="modal" UseSubmitBehavior="false" OnClick="btn_Guardar_Click" />
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
                                <h4 class="card-title">Inmuebles registrados</h4>
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
                                    <asp:GridView ID="grdInmuebles" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
                                        DataKeyNames="IdInmueble,IdDetalleInmueble,IdUsuarioInmueble">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-BackColor="#9c9c9c">
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="ibtnEditar" ToolTip="Editar" ImageUrl="~/Images/editar.png" Width="20px" data-toggle="modal" data-target="#divAgregar" OnClick="ibtnEditar_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-BackColor="#9c9c9c">
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="ibtnImagenes" ToolTip="Ver imagenes" ImageUrl="~/Images/imagenes.png" Width="25px" data-toggle="modal" data-target="#divAgregarImagenes" OnClick="ibtnImagenes_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-BackColor="#9c9c9c">
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="ibtnArchivos" ToolTip="Ver archivos" ImageUrl="~/Images/archivos.png" Width="15px" data-toggle="modal" data-target="#divAgregarArchivos" OnClick="ibtnArchivos_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IdInmueble" HeaderText="#" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="NombreInmueble" HeaderText="Nombre Inmueble" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" />
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
                                            <asp:BoundField DataField="IdDetalleInmueble" HeaderText="#" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" Visible="false"/>
                                            <asp:BoundField DataField="IdUsuarioInmueble" HeaderText="#" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" Visible="false"/>
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
