<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Inmobiliaria.Views.Login" MasterPageFile="~/Master/LoginMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="row">
        <div class="messagealert" id="alert_container">
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="container" id="container">
                <div class="form-container sign-up-container">
                    <form action="#">
                    </form>
                </div>
                <div class="form-container sign-in-container" style="background-color: #990f26; color: #ffffff">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <h1>Inmobiliaria Serv.</h1>
                    <br />
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Correo electrónico"></asp:TextBox>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button runat="server" Text="Entrar" ID="btnIngresar" OnClick="btnIngresar_Click" />

                </div>
                <div class="overlay-container" style="background-color: #f6f5f7">
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
                    Inmobiliaria Serv.
                </p>
            </footer>
            <%--<img class="mb-4" src="../images/logo.jpg" alt="" width="200" height="45">
            <br />
            <br />
            <br />
            <h1 class="h4 mb-3 font-weight-normal">Inmobiliaria Serv.</h1>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Correo electronico"></asp:TextBox>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
            <asp:Button runat="server" Text="Entrar" CssClass="btn btn-lg btn-primary btn-block" ID="btnIngresar" OnClick="btnIngresar_Click"  />
            <p class="mt-5 mb-3 text-muted">Ingram Micro <%= DateTime.Now.Year %> Version 2.1.13</p>--%>
        </ContentTemplate>
    </asp:UpdatePanel>



    <script type="text/javascript">
        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Exito':
                    cssclass = 'alert-success'
                    break;
                case 'Error':
                    cssclass = 'alert-danger'
                    break;
                case 'Advertencia':
                    cssclass = 'alert-warning'
                    break;
                default:
                    cssclass = 'alert-info'
            }
            $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
        }
    </script>

</asp:Content>
