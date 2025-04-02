using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Catalogo
{
	public partial class Mimaster : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			

			if( (!(Page is Login)) && (!(Page is Registrarse)) && (!(Page is Default)) && (!(Page is Productos)) && (!(Page is Administrar))&& (!(Page is FormularioProducto)) && (!(Page is Detalles)))
			{
				if (!Seguridad.sessionActiva(Session["user"]))
				{
					Response.Redirect("Login.aspx", false);
				}
			}
		}

        protected void btnlogout_Click(object sender, EventArgs e)
        {
			Session["user"] = null;
			Response.Redirect("Home.aspx", false);
        }
    }
}