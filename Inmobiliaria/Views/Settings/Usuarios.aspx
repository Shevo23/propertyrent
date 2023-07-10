<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" MasterPageFile="~/Master/Site.Master" Inherits="Inmobiliaria.Views.Settings.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />
        <br />
        <br />
        <div class="row">
            <div class="col-md-12">
            </div>
        </div>

        <div id="divAgregar" class="modal fade" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog" role="document">
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
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing-sm">Nombre:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing-s">Paterno:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtPaterno" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
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
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing">Correo electronico:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing">NickName:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombreUsuario" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizin">Movil:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtMovil" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizi">Contraseña:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:CheckBox ID="chk_Estatus" runat="server" />
                                    <asp:Label runat="server" ID="Label2" Text="Activo"></asp:Label>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btn_Guardar" runat="server" CssClass="btn btn-default btn-save" Text="Guardar" ValidationGroup="Global" data-dismiss="modal" UseSubmitBehavior="false" OnClick="btnGuardar_Click" />
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
                        <h5 class="card-title">Usuarios</h5>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>

                                <asp:Button ID="btn_Agregar" runat="server" Text="Agregar" CssClass="btn btn-default btn-green" data-toggle="modal" data-target="#divAgregar" OnClick="btnAgregar_Click" />

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btn_Agregar" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div class="table table-responsive">
                                    <asp:GridView ID="grdUsuarios" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                                        DataKeyNames="IdUsuario">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-CssClass="header-grid">
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="ibtnEditar" ToolTip="Editar" ImageUrl="~/Images/editar.png" Width="20px" data-toggle="modal" data-target="#divAgregar" OnClick="ibtnEditar_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" />
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                            <asp:BoundField DataField="Paterno" HeaderText="Paterno"/>
                                            <asp:BoundField DataField="Email" HeaderText="Materno" />
                                            <asp:BoundField Visible="false" DataField="NombreUsuario" HeaderText="IdUsuario" />
                                            <asp:BoundField Visible="false" DataField="Password" HeaderText="IdUsuario" />
                                            <asp:TemplateField HeaderText="Estatus" HeaderStyle-CssClass="header-grid">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkEstatus" runat="server" CssClass="pull-left" Checked='<%#Convert.ToBoolean(Eval("Activo")) %>' Enabled="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
