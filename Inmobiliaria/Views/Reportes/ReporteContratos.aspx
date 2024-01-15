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
                <div class="card border-light mb-3">
                    <div class="card-header">
                        <div class="row">
                            <div class="col-sm-10">
                                <h4 class="card-title" style="color: #0c2b54">Reporte de contratos</h4>
                            </div>

                        </div>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div class="table table-hover table-responsive" style="font-size: small">
                                    <asp:GridView ID="grdContratos" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
                                        AllowPaging="true" PageSize="10" PagerSettings-Mode="Numeric"
                                        OnPageIndexChanging="grdContratos_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="IdInmueble" HeaderText="IdInmueble" Visible="false" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="NombreInmueble" HeaderText="Inmueble" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="IdContrato" HeaderText="#" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" Visible="false" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="NumContrato" HeaderText="NumContrato" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="IdArrendatario" HeaderText="IdArrendatario" Visible="false" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="NombreArrendatario" HeaderText="Inquilino" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="CostoTotal" HeaderText="Costo total" DataFormatString="{0:C}" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="RentaMensual" HeaderText="Renta mensual" DataFormatString="{0:C}" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="CostoMto" HeaderText="Costo mantenimiento" DataFormatString="{0:C}" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="Descripcion" HeaderText="Tipo pago" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" DataFormatString="{0:C}" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="FechaPago" HeaderText="Fecha pago" HeaderStyle-BackColor="#0c2b54" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                        </Columns>
                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="card-footer">
                        <div class="col-lg-12">
                            <asp:Button ID="btnExportar" runat="server" Text="Exportar Excel" CssClass="btn float-right btn-info" OnClick="btnExportar_Click" />
                        </div>
                    </div>
            </div>
        </div>
    </div>
</asp:Content>
