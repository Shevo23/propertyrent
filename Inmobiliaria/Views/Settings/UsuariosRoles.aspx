<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuariosRoles.aspx.cs" MasterPageFile="~/Master/Site.Master" Inherits="Inmobiliaria.Views.Settings.UsuariosRoles" %>

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
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header" style="background-color: #0c2b54; color: white">
                                <h4 class="modal‐title">
                                    <asp:Label runat="server" ID="lbl_Titulo"></asp:Label></h4>
                                <button type="button" style="color: white" class="close" data-dismiss="modal">&times;</button>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cmbUsuarios"
                                            ValidationGroup="Roles" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            Type="Integer" ValueToCompare="0" Operator="GreaterThan" Display="Dynamic">
                                        </asp:CompareValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <label class="input-group-text" for="cmbUsuarios">Usuarios:</label>
                                            </div>
                                            <asp:DropDownList runat="server" CssClass="custom-select" ID="cmbUsuarios"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="cmbRoles"
                                            ValidationGroup="Roles" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            Type="Integer" ValueToCompare="0" Operator="GreaterThan" Display="Dynamic">
                                        </asp:CompareValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <label class="input-group-text" for="cmbRoles">Roles:</label>
                                            </div>
                                            <asp:DropDownList runat="server" CssClass="custom-select" ID="cmbRoles"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-default btn-danger" Text="Cancelar" data-dismiss="modal" OnClick="btnCancelar_Click" />
                                <asp:Button ID="btn_Guardar" runat="server" CssClass="btn btn-default btn-save" Text="Guardar" ValidationGroup="Roles" data-dismiss="modal" UseSubmitBehavior="false" OnClick="btn_Guardar_Click" />
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
                                <h4 class="card-title" style="color: #0c2b54">Roles por usuario</h4>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div class="table table-hover table-responsive" style="font-size: small">
                                    <asp:GridView ID="grdUsuariosRoles" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
                                        DataKeyNames="IdUsuarioRol" PageSize="10" OnPageIndexChanging="grdUsuariosRoles_PageIndexChanging" AllowPaging="true"
                                        PagerSettings-Mode="Numeric">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-BackColor="#0c2b54">
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="ibtnEditar" ToolTip="Editar" ImageUrl="~/Images/editar.png" Width="25px" data-toggle="modal" data-target="#divAgregar" OnClick="ibtnEditar_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IdUsuarioRol" HeaderText="Id" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" Visible="false" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="IdRol" HeaderText="IdRol" Visible="false" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                        </Columns>
                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
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
                                <asp:Button ID="btn_Agregar" runat="server" Text="Agregar" CssClass="btn float-right" BackColor="#0c2b54" ForeColor="White" data-toggle="modal" data-target="#divAgregar" OnClick="btn_Agregar_Click" />
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
