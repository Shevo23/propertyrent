<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagosInmueble.aspx.cs" MasterPageFile="~/Master/Site.Master" Inherits="Inmobiliaria.Views.Pagos.PagosInmueble" %>

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
            <div class="modal-dialog modal-md" role="document">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header" style="background-color: #0c2b54; color: white">
                                <h4 class="modal‐title">Registro de pagos</h4>
                                <button type="button" class="close" style="color: white" data-dismiss="modal">&times;</button>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="cmbTipoPago"
                                            ValidationGroup="Global" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            Type="Integer" ValueToCompare="0" Operator="GreaterThan" Display="Dynamic"></asp:CompareValidator>
                                        <div class="input-group mb-4">
                                            <div class="input-group-prepend">
                                                <label class="input-group-text" for="cmbInmueble">Tipo de pago:</label>
                                            </div>
                                            <asp:DropDownList CssClass="custom-select font-weight-bold" runat="server" ID="cmbTipoPago" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaPago"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Global"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGup-siz-sm">Fecha pago:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtFechaPago" aria-label="Sizing example input" TextMode="Date" aria-describedby="inputGroup-sizing-sm" ValidationGroup="Global"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizin">Cantidad:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control font-weight-bold" ID="txtCantidad" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" ValidationGroup="Global"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" data-dismiss="modal" UseSubmitBehavior="false" OnClick="btnCancelar_Click" />
                                <asp:Button ID="btnGuardar" Text="Guardar" runat="server" CssClass="btn btn-info" data-dismiss="modal" UseSubmitBehavior="false" ValidationGroup="Global" OnClick="btnGuardar_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <div class="card border-light mb-3">
                    <div class="card-header">
                        <div class="row">
                            <div class="col-sm-10">
                                <h4 class="card-title" style="color: #0c2b54">Pagos realizados</h4>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
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
                                <br />
                                <div class="table table-hover table-responsive" style="font-size: small">
                                    <asp:GridView ID="grdPagosInmueble" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
                                        DataKeyNames="IdPagoInmueble" AllowPaging="true" PagerSettings-Mode="Numeric" PageSize="10"
                                        OnPageIndexChanging="grdPagosInmueble_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-BackColor="#0c2b54">
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="ibtnEditar" ToolTip="Editar" ImageUrl="~/Images/editar.png" Width="25px" data-toggle="modal" data-target="#divAgregar" OnClick="ibtnEditar_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IdPagoInmueble" HeaderText="#" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="IdTipoPago" HeaderText="IdTipoPago" Visible="false" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="Descripcion" HeaderText="Tipo de pago" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" HeaderStyle-BackColor="#0c2b54" DataFormatString="{0:C}" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="FechaPago" HeaderText="Fecha de pago" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="IdInmueble" HeaderText="IdInmueble" Visible="false" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div align="center">No cuenta con pagos registrados</div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btn_Agregar" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div class="card-footer">
                        <div class="col-lg-12">
                            <asp:Button ID="btn_Agregar" runat="server" Text="Agregar pago" CssClass="btn float-right" BackColor="#0c2b54" ForeColor="White" data-toggle="modal" data-target="#divAgregar" OnClick="btn_Agregar_Click" />
                        </div>
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
