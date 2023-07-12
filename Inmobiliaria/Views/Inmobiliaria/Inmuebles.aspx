<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inmuebles.aspx.cs" MasterPageFile="~/Master/Site.Master" Inherits="Inmobiliaria.Views.Inmuebles" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />
        <br />
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
                                                <asp:GridView ID="grdImagenes" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered"
                                                    OnRowDataBound="grdImagenes_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField DataField="IdImagenInmueble" HeaderText="#" ItemStyle-Width="30" />
                                                        <asp:BoundField DataField="IdInmueble" HeaderText="Id Inmueble" Visible="false" />
                                                        <asp:BoundField DataField="NombreImagen" HeaderText="Nombre de la imagen" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                                        <asp:TemplateField ControlStyle-CssClass="img-thumbnail" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Image ID="img" runat="server" Height="100px" Width="100px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button Text="Cargar imagenes" CssClass="btn btn-default btn-save" ID="btnGuardarImagenInmueble" runat="server" OnClick="btnGuardarImagenInmueble_Click" />
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
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing-sm">Nombre del inmueble</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombreInmueble" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing-">Descripcion:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtDescripcion" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing">Costo total:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtCostoTotal" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup">Costo mensual:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtCostoMensual" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizin">Costo mantenimiento:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtCostoMantenimiento" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizi">Antigüedad:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtAntiguedad" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <label class="input-group-text" for="cmbTipoPropiedad">Tipo propiedad</label>
                                            </div>
                                            <asp:DropDownList CssClass="custom-select" runat="server" ID="cmbTipoPropiedad"></asp:DropDownList>
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
                                    <div class="col-sm-3">
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
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"># recamaras:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNumRecamaras" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"># baños:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNumBanos" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"># servicios:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNumServicios" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"># estacionamientos:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNumEstacionamiento" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">total m2:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNumM2" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">total construccion:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNumTotal" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <asp:CheckBox ID="chkAlberca" Text=" Cuenta con alberca?" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <hr />

                                <hr />
                                <div class="row">
                                    <div class="col-sm-12">
                                        <h5>Archivos del inmueble</h5>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroupFileAddon02">Cargar</span>
                                            </div>
                                            <div class="custom-file">
                                                <asp:FileUpload runat="server" type="file" class="custom-file-input" ID="FileUpload1" aria-describedby="inputGroupFileAddon02"
                                                    AllowMultiple="true" />
                                                <label class="custom-file-label" for="flpFotosInmueble">Seleccione imagenes</label>
                                            </div>

                                            <asp:Label ID="listImages" runat="server" />
                                        </div>
                                        <asp:Button Text="Guardar imagen" CssClass="btn btn-default btn-save" ID="btnGuardarArchivosInmueble" runat="server" OnClick="btnGuardarArchivosInmueble_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btn_Guardar" runat="server" CssClass="btn btn-default btn-save" Text="Guardar" ValidationGroup="Global" data-dismiss="modal" UseSubmitBehavior="false" OnClick="btn_Guardar_Click" />
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
                        <h5 class="card-title">Inmuebles registrados</h5>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>

                                <asp:Button ID="btn_Agregar" runat="server" Text="Agregar" CssClass="btn btn-default btn-green" data-toggle="modal" data-target="#divAgregar" OnClick="btn_Agregar_Click" />

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btn_Agregar" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div class="table table-responsive" style="font-size: small">
                                    <asp:GridView ID="grdInmuebles" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                                        DataKeyNames="IdInmueble">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="ibtnEditar" ToolTip="Editar" ImageUrl="~/Images/Editar.png" Width="20px" data-toggle="modal" data-target="#divAgregar" OnClick="ibtnEditar_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="ibtnImagenes" ToolTip="Editar" ImageUrl="~/Images/Cargar.png" Width="20px" data-toggle="modal" data-target="#divAgregarImagenes" OnClick="ibtnImagenes_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IdInmueble" HeaderText="Id Inmueble" />
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre Inmueble" />
                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" Visible="false" />
                                            <asp:TemplateField HeaderText="Usado / Nuevo" Visible="false">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkNuevo" runat="server" CssClass="pull-left" Checked='<%#Convert.ToBoolean(Eval("Nuevo")) %>' Enabled="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CostoTotal" HeaderText="Costo total" DataFormatString="{0:C}" />
                                            <asp:BoundField DataField="CostoMensual" HeaderText="Costo Mensual" DataFormatString="{0:C}" />
                                            <asp:BoundField DataField="Propiedad" HeaderText="Tipo Propiedad" />
                                            <asp:BoundField DataField="Asentamiento" HeaderText="Colonia" />
                                            <asp:BoundField DataField="Municipio" HeaderText="Municipio" />
                                            <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                            <asp:BoundField DataField="FechaAlta" HeaderText="Fecha registro" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField DataField="EstatusInmueble" HeaderText="Estatus" />



                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
