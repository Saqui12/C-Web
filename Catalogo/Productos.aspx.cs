using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Catalogo
{
	public partial class Productos : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			NegocioArticulos negocio = new NegocioArticulos();
			dgvProductos.DataSource = negocio.listarConSP();
			dgvProductos.DataBind();
		
		}
	}
}