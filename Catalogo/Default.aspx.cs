﻿using Negocio;
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
	}
}