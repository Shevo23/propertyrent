using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inmobiliaria.Views
{
    public partial class Login : System.Web.UI.Page
    {
        #region Variables

        BTLInmobiliaria.Catalogos catalogos = new BTLInmobiliaria.Catalogos(ConfigurationManager.ConnectionStrings["BDInmuebles"].ToString());
        public enum MessageType { Exito, Error, Importante, Advertencia };

        #endregion

        #region Methods

        public static string ConvertirSha256(string texto)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            DataSet dsUsuario = new DataSet();

            try
            {
                var password = ConvertirSha256(txtPassword.Text.Trim());

                dsUsuario = catalogos.GetValidaUsuario(txtEmail.Text.Trim(), password);

                if (dsUsuario.Tables[0].Rows.Count > 0)
                {
                    FormsAuthentication.SetAuthCookie(txtEmail.Text.Trim(), true);

                    Response.Redirect("~/Views/Default.aspx");
                }
                else
                {
                    ShowMessage("Nombre de usuario o password incorrecto.", MessageType.Advertencia);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}