using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo
{
	public partial class Registrarse : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
			
			try
			{
                Usuario nuevoUser = new Usuario();
                NegocioUsuario negocio = new NegocioUsuario();
                nuevoUser.Email = txtEmail.Text;
				nuevoUser.Pass = txtPassword.Text;
				nuevoUser.Id= negocio.insertarUsuario(nuevoUser);
				Session.Add("usuario", nuevoUser);

                Response.Redirect("Default.aspx", false);

            }
			catch (Exception ex)
			{

                Session.Add("error", ex.ToString());
            }
        }
    }
}