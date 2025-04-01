using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace Catalogo
{
	public partial class FormularioProducto : System.Web.UI.Page
	{
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
		{
            try
            {
                if (!IsPostBack)
                {
                    NegocioMarcas negocioM = new NegocioMarcas();
                    List <Marcas> listM = negocioM.listar();

                    NegocioCategoria negocioC = new NegocioCategoria();
                    List<Categorias> listC = negocioC.listar();

                    ddlMarca.DataSource = listM;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    DataBind();

                    ddlCategoria.DataSource = listC;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    DataBind();

                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
		}

        protected void btnInactivar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulos nuevo = new Articulos();
            
            nuevo.Nombre = txtNombre.Text;
            nuevo.Codigo = txtCodigo.Text;
            nuevo.Descripcion = txtDescripcion.Text;
            nuevo.ImagenUrl = txtImagenUrl.Text;
            nuevo.Precio = decimal.Parse(txtPrecio.Text);
            
            nuevo.Categoria = new Categorias();
            nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
            nuevo.Marca = new Marcas();
            nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

            NegocioArticulos negocio = new NegocioArticulos();
            negocio.agregar(nuevo);
            Response.Redirect("Productos.aspx", false);
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}