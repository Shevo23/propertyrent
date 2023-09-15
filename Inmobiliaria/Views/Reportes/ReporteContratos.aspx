<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteContratos.aspx.cs" MasterPageFile="~/Master/Site.Master" Inherits="Inmobiliaria.Views.ReporteContratos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />
        <br />
        <br />
        <br />
        <br />
        <div class="row">
            <div class="col-md-12">
                <div class="card border-warning">
                    <div class="card-header">
                        <div class="row">
                            <div class="col-sm-10">
                                <h4 class="card-title">Reporte de contratos</h4>
                            </div>
                            <div class="col-sm-2">
                                <asp:Button ID="btnExportar" runat="server" Text="Exportar Excel" CssClass="btn btn-default btn-info" OnClick="btnExportar_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div class="table table-responsive" style="font-size: small">
                                    <asp:GridView ID="grdContratos" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
                                        <Columns>
                                            <asp:BoundField DataField="IdInmueble" HeaderText="IdInmueble" Visible="false" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="NombreInmueble" HeaderText="Inmueble" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="IdContrato" HeaderText="#" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" Visible="false" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="NumContrato" HeaderText="NumContrato" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="IdArrendatario" HeaderText="IdArrendatario" Visible="false" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="NombreArrendatario" HeaderText="Inquilino" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="CostoTotal" HeaderText="Costo total" DataFormatString="{0:C}" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="RentaMensual" HeaderText="Renta mensual" DataFormatString="{0:C}" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="CostoMto" HeaderText="Costo mantenimiento" DataFormatString="{0:C}" HeaderStyle-BackColor="#9c9c9c" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="card-footer">

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
