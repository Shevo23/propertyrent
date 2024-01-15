﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Arrendadores.aspx.cs" MasterPageFile="~/Master/Site.Master" Inherits="Inmobiliaria.Views.Inmobiliaria.Arrendadores" %>

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
                            <div class="modal-header" style="background-color: #0c2b54; color: white">
                                <h5>Archivos del arrendador</h5>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="flpArchivosInmueble"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Archivos"></asp:RequiredFieldValidator>
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
                                                <div class="table table-hover table-responsive" style="font-size: small">
                                                    <asp:GridView ID="grdArchivos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered"
                                                        OnRowDataBound="grdArchivos_RowDataBound" DataKeyNames="IdArchivoArrendador,NombreArchivo,IdArrendador">
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-BackColor="#0c2b54">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="ibtnEliminarArchivo" ToolTip="Eliminar" ImageUrl="~/Images/borrar.png" Width="20px" OnClick="ibtnEliminarArchivo_Click" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="IdArchivoArrendador" HeaderText="#" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                                            <asp:BoundField DataField="IdArrendador" HeaderText="Id Inmueble" Visible="false" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                                            <asp:BoundField DataField="NombreArchivo" HeaderText="Nombre del archivo" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                                            <asp:TemplateField ControlStyle-CssClass="img-thumbnail" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Image ID="archivo" runat="server" Height="100px" Width="200px" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="grdArchivos" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button Text="Cargar archivos" CssClass="btn btn-success" ID="btnGuardarArchivosArrendador" runat="server" OnClick="btnGuardarArchivosArrendador_Click" />
                                <asp:Button Text="Cerrar" class="btn btn-info" runat="server" data-dismiss="modal" />
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnGuardarArchivosArrendador" />
                    </Triggers>
                </asp:UpdatePanel>
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
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombres"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Global"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing-sm">Nombre(s):</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombres" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ValidChars=" ñÑüÜ´" ID="FilteredTextBoxExtender1" runat="server" FilterType="LowercaseLetters, UppercaseLetters, Custom" TargetControlID="txtNombres" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPaterno"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Global"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing-s">Paterno:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtPaterno" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ValidChars=" ñÑüÜ´" ID="FilteredTextBoxExtender2" runat="server" FilterType="LowercaseLetters, UppercaseLetters, Custom" TargetControlID="txtPaterno" />
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
                                            <cc1:FilteredTextBoxExtender ValidChars=" ñÑüÜ´" ID="FilteredTextBoxExtender3" runat="server" FilterType="LowercaseLetters, UppercaseLetters, Custom" TargetControlID="txtMaterno" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Global"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ErrorMessage="<span style='color: red; font-weight: bold'>Formato incorrecto</span>" ControlToValidate="txtEmail" runat="server"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Global" />
                                        <div class="input-group mb-4">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizing">Email:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMovil"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Global"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGrou-sizin">Movil:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtMovil" MaxLength="10" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Numbers" TargetControlID="txtMovil" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFijo"
                                            Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            ValidationGroup="Global"></asp:RequiredFieldValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputGroup-sizin">Teléfono fijo:</span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtFijo" MaxLength="10" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Numbers" TargetControlID="txtFijo" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cmbTipoIdentificacion"
                                            ValidationGroup="Global" ErrorMessage="<span style='color: red; font-weight: bold'>* Requerido</span>"
                                            Type="Integer" ValueToCompare="0" Operator="GreaterThan" Display="Dynamic"></asp:CompareValidator>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <label class="input-group-text" for="cmbTipoPropiedad">Tipo de indentificación:</label>
                                            </div>
                                            <asp:DropDownList CssClass="custom-select" runat="server" ID="cmbTipoIdentificacion"></asp:DropDownList>
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
                <div class="card border-light mb-3">
                    <div class="card-header">
                        <div class="row">
                            <div class="col-sm-10">
                                <h4 class="card-title" style="color: #0c2b54">Arrendadores registrados</h4>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div class="table table-hover table-responsive" style="font-size: small">
                                    <asp:GridView ID="grdArrendadores" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
                                        DataKeyNames="IdArrendador" AllowPaging="true" PageSize="10" PagerSettings-Mode="Numeric"
                                        OnPageIndexChanging="grdArrendadores_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-BackColor="#0c2b54">
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="ibtnEditar" ToolTip="Editar" ImageUrl="~/Images/editar.png" Width="25px" data-toggle="modal" data-target="#divAgregar" OnClick="ibtnEditar_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-BackColor="#0c2b54">
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="ibtnArchivos" ToolTip="Ver archivos" ImageUrl="~/Images/archivos.png" Width="25px" data-toggle="modal" data-target="#divAgregarArchivos" OnClick="ibtnArchivos_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IdArrendador" HeaderText="#" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Nombres" HeaderText="Nombres" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Paterno" HeaderText="Paterno" Visible="false" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Materno" HeaderText="Materno" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" Visible="false" />
                                            <asp:BoundField DataField="Movil" HeaderText="Movil" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="Fijo" HeaderText="Fijo" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                            <asp:BoundField DataField="IdTipoIdentificacion" HeaderText="IdTipoIdentificacion" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" Visible="false" />
                                            <asp:BoundField DataField="FechaAlta" HeaderText="Fecha registro" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" />
                                            <asp:TemplateField HeaderText="Usado / Nuevo" Visible="false" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkActivo" runat="server" CssClass="pull-left" Checked='<%#Convert.ToBoolean(Eval("Activo")) %>' Enabled="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
