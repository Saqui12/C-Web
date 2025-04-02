using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo
{
	public partial class Default : System.Web.UI.Page
    {       

        protected void Page_Load(object sender, EventArgs e)
		{
                    
            NegocioArticulos negocio = new NegocioArticulos();
            repeater1.DataSource = negocio.listarConSP();
            repeater1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           

        }

        protected void repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
            if (e.CommandName == "Favorito")
            {

                List<string> favoritos = Session["favoritos"] as List<string> ?? new List<string>();

                string itemId = e.CommandArgument.ToString();
                
                if (!favoritos.Contains(itemId))
                {
                    favoritos.Add(itemId);
                    Session.Add("favoritos", favoritos);
                }

            }
            if (e.CommandName == "Detalle")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("Detalles.aspx?id=" + id);
            }

        }

    }
}