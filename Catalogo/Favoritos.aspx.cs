using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo
{
	public partial class Favoritos : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            

            if (Session["favoritos"] != null)
            {
                NegocioArticulos negocio = new NegocioArticulos();
                List<Articulos> listaFav = new List<Articulos>();
                List<string> lista = (List<string>)(Session["favoritos"]);                

                foreach (var item in lista)
                {
                    listaFav.Add((Articulos)negocio.listarConId(item));
                }

                repeater1.DataSource = listaFav;
                repeater1.DataBind();

            }
        }


        protected void repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "Remover")
            {
                List<string> lista = (List<string>)(Session["favoritos"]);
                lista.Remove(e.CommandArgument.ToString());
                Session.Add("favoritos", lista);
                Response.Redirect("Favoritos.aspx", false);
            }
            if (e.CommandName == "Detalle")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("Detalles.aspx?id=" + id);
            }
        }
    }
}