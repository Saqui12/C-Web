using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NegocioUsuario
    {

        public int insertarUsuario(Usuario nuevo)
        {
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setearProcedimiento("insertarNuevo");
				datos.setearParametro("@email", nuevo.Email);
				datos.setearParametro("@pass", nuevo.Pass);
				return datos.ejecutarAccionScalar();
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
        }

		public bool Login(Usuario user)
		{
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setearConsulta("Select id, email, pass, admin, urlimagenPerfil, nombre, apellido from USERS Where email = @email And pass = @pass");
				datos.setearParametro("@email",user.Email);
				datos.setearParametro("@pass",user.Pass);
				datos.ejecutarLectura();
				if (datos.Lector.Read())
				{
					user.Id = (int)datos.Lector["id"];
					user.Admin = (bool)datos.Lector["admin"];
					return true;
				}

				return false;
			}
			catch (Exception ex)
			{

				throw ex ;
			}
			finally
			{
				datos.cerrarConexion();
			}
		}


    }
}
