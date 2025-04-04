using dominio;
using Dominio;
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


            /*  if (Session["favoritos"] != null)
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

              }*//*
            NegocioArticulos negocio = new NegocioArticulos();
            NegocioFavoritos nego = new NegocioFavoritos();
            List<Articulos> listaFav = new List<Articulos>();
            List<FavoritosUser> ListObj = nego.listar();
            List<string> lista = new List<string>();
            
            foreach (var item in ListObj)
            {
                lista.Add(item.IdArticulo.ToString());

            }

            foreach (var item in lista)
            {
                listaFav.Add((Articulos)negocio.listarConId(item));
            }

            repeater1.DataSource = listaFav;
            repeater1.DataBind();*/
            if (Session["user"] != null)
            {
                NegocioArticulos negocio = new NegocioArticulos();
                Usuario user = (Usuario)Session["user"];
                repeater1.DataSource = negocio.listarFavoritos(user.Id.ToString());
                repeater1.DataBind();

            }



        }


        protected void repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "Remover")
            {
                
                NegocioFavoritos favoritos = new NegocioFavoritos();
                Usuario user = (Usuario)Session["User"];
                int idArt = Convert.ToInt32(e.CommandArgument);

                favoritos.eliminar(idArt,user.Id );
                Response.Redirect("Favoritos.aspx", false);

                /*List<string> lista = (List<string>)(Session["favoritos"]);
                lista.Remove(e.CommandArgument.ToString());
                Session.Add("favoritos", lista);
                ;*/
            }
            if (e.CommandName == "Detalle")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("Detalles.aspx?id=" + id);
            }
        }
    }
}