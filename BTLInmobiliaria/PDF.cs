using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using IronPdf;


namespace BTLInmobiliaria
{
    public class PDF
    {
        public static string GenerarContrato(DatosContrato datosContrato)
        {
            var renderer = new IronPdf.HtmlToPdf();

            string s1, s2;

            string pathPhsy = HostingEnvironment.ApplicationPhysicalPath.ToString();
            string completePath = pathPhsy + @"\Contratos\";

            s1 = File.ReadAllText(completePath + "Contrato.html", Encoding.UTF8);


            s1 = s1.Replace("#DireccionInmueble#", datosContrato.DireccionInmueble);
            s1 = s1.Replace("#NombreArrendador#", datosContrato.NombreArrendador);
            s1 = s1.Replace("#NombreFiador#", datosContrato.NombreFiador);
            s1 = s1.Replace("#CantidadMensual#", datosContrato.CantidadMensual);
            s1 = s1.Replace("#NombreArrendatario#", datosContrato.NombreArrendatario);
            s1 = s1.Replace("#DireccionFiador#", datosContrato.DireccionFiador);
            s1 = s1.Replace("#Fecha#", datosContrato.Fecha);


            s2 = File.ReadAllText(completePath + "CartaResicion.html", Encoding.UTF8);

            s2 = s2.Replace("#NombreArrendatario#", datosContrato.NombreArrendatario);
            s2 = s2.Replace("#DireccionInmueble#", datosContrato.DireccionInmueble);
            s2 = s2.Replace("#NombreArrendatario#", datosContrato.NombreArrendatario);
            s2 = s2.Replace("#Fecha#", datosContrato.Fecha);

            var n = Guid.NewGuid().ToString().ToUpper().Replace("-", "");

            renderer.RenderHtmlAsPdf(s1).SaveAs(HostingEnvironment.ApplicationPhysicalPath + @"\Inmuebles\Tmp\" + n + "Contrato.pdf");
            
            renderer.RenderHtmlAsPdf(s2).SaveAs(HostingEnvironment.ApplicationPhysicalPath + @"\Inmuebles\Tmp\" + n + "CartaResicion.pdf");

            System.Diagnostics.Process.Start(HostingEnvironment.ApplicationPhysicalPath + @"\Inmuebles\Tmp\" + n + "Contrato.pdf");
            System.Diagnostics.Process.Start(HostingEnvironment.ApplicationPhysicalPath + @"\Inmuebles\Tmp\" + n + "CartaResicion.pdf");

            return "Contrato.pdf";

        }
    }
}
