<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" MasterPageFile="~/Master/Site.Master" Inherits="Inmobiliaria.Views.Settings.Usuarios" %>

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
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header" style="background-color: #0c2b54; color: white">
                                <h4 class="modal‐title">
                                    <asp:Label runat="server" ID="lbl_Titulo"></asp:Label></h4>
                                <button type="button" class="close" style="color: white" data-dismiss="modal">&times;</button>

                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Usuarios"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing-sm">Nombre:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ValidChars=" " ID="FilteredTextBoxExtender1" runat="server" FilterType="LowercaseLetters, UppercaseLetters, Custom" TargetControlID="txtNombre" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPaterno"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Usuarios"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing-s">Paterno:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtPaterno" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ValidChars=" " ID="FilteredTextBoxExtender2" runat="server" FilterType="LowercaseLetters, UppercaseLetters, Custom" TargetControlID="txtPaterno" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing-">Materno:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtMaterno" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ValidChars=" " ID="FilteredTextBoxExtender3" runat="server" FilterType="LowercaseLetters, UppercaseLetters, Custom" TargetControlID="txtMaterno" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Usuarios"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-4">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing">Correo electronico:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <asp:RegularExpressionValidator ErrorMessage="<span style='color: red; font-weight: bold'>Formato incorrecto</span>" ControlToValidate="txtEmail" runat="server"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Usuarios" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizin">NickName:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombreUsuario" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ValidChars=" " ID="FilteredTextBoxExtender5" runat="server" FilterType="LowercaseLetters, UppercaseLetters, Custom" TargetControlID="txtNombreUsuario" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMovil"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Usuarios"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGrou-sizin">Movil:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtMovil" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ValidChars=" " ID="FilteredTextBoxExtender6" runat="server" FilterType="Numbers" TargetControlID="txtMovil" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassword"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Usuarios"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizi">Contraseña:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" aria-label="Sizing example input" TextMode="Password" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <asp:RegularExpressionValidator ErrorMessage="<span style='color: red; font-weight: bold'>Deben ser minimo 8 caracteres, una mayuscula, una minuscula, un numero y simbolo especial</span>" ControlToValidate="txtPassword" runat="server"
                                                ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:CheckBox ID="chk_Estatus" runat="server" />
                                    <asp:Label runat="server" ID="Label2" Text="Activo"></asp:Label>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-default btn-danger" Text="Cancelar" data-dismiss="modal" OnClick="btnCancelar_Click" />
                                <asp:Button ID="btn_Guardar" runat="server" CssClass="btn btn-default btn-success" Text="Guardar" ValidationGroup="Usuarios" UseSubmitBehavior="false" data-dismiss="modal" OnClick="btnGuardar_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btn_Guardar" />
                    </Triggers>
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
                                <h4 class="card-title" style="color: #0c2b54">Usuarios</h4>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div class="table table-hover table-responsive">
                                    <asp:GridView ID="grdUsuarios" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
                                        DataKeyNames="IdUsuario" OnPageIndexChanging="grdUsuarios_PageIndexChanging" AllowPaging="true" PageSize="10"
                                        PagerSettings-Mode="Numeric">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-BackColor="#0c2b54">
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="ibtnEditar" ToolTip="Editar" ImageUrl="~/Images/editar.png" Width="25px" data-toggle="modal" data-target="#divAgregar" OnClick="ibtnEditar_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IdUsuario" HeaderText="#" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Paterno" HeaderText="Paterno" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Email" HeaderText="Materno" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField Visible="false" DataField="NombreUsuario" HeaderText="IdUsuario" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField Visible="false" DataField="Password" HeaderText="IdUsuario" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                            <asp:TemplateField HeaderText="Estatus" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkEstatus" runat="server" CssClass="pull-left" Checked='<%#Convert.ToBoolean(Eval("Activo")) %>' Enabled="false" />
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
                    <div class="card-footer">
                        <div class="col-lg-12">
                            <asp:Button ID="btn_Agregar" runat="server" Text="Agregar" CssClass="btn float-right" BackColor="#0c2b54" ForeColor="White" data-toggle="modal" data-target="#divAgregar" OnClick="btnAgregar_Click" />
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
