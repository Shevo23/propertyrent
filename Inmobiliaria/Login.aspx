<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Inmobiliaria.Views.Login" MasterPageFile="~/Master/LoginMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="messagealert" id="alert_container">
                    </div>
                </div>
            </div>
            <div class="container" id="container">
                <div class="form-container sign-up-container">
                    <form action="#">
                    </form>
                </div>
                <div class="form-container sign-in-container" style="background-color: #ffffff; color: #ffffff">
                    <br />
                    <br />
                    <br />
                    <br />
                    <h1 style="color: #0c2b54">Property Rent</h1>
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Correo electrónico"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>*</span>"
                        ValidationGroup="Login"></asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                        Display="Dynamic" ErrorMessage="<span style='color: red; font-weight: bold'>*</span>"
                        ValidationGroup="Login"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <br />
                    <asp:Button runat="server" Text="Entrar" ID="btnIngresar" OnClick="btnIngresar_Click" ValidationGroup="Login" Width="150px" />

                </div>
                <div class="overlay-container" style="background-color: #0c2b54">
                    <div class="overlay">
                        <div class="overlay-panel overlay-left">
                        </div>
                        <div class="overlay-panel overlay-right">
                        </div>
                    </div>
                </div>
            </div>
            <footer>
                <p>
                    <%= DateTime.Now.Year %> <i class="fa fa-heart"></i>
                    Property Rent
                </p>
            </footer>
        </ContentTemplate>
    </asp:UpdatePanel>

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
