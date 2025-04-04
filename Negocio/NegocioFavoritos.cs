using Datos;
using dominio;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioFavoritos
    {
        public List<FavoritosUser> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<FavoritosUser> lista = new List<FavoritosUser>();

            try
            {
                datos.setearConsulta("select IdUser, IdArticulo from FAVORITOS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    FavoritosUser aux = new FavoritosUser();
                    aux.IdUser = (int)datos.Lector["IdUser"];
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                    lista.Add(aux);
                }
                return lista;

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
        public void agregar(FavoritosUser nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into FAVORITOS values (@IdUser, @IdArticulo)");
                datos.setearParametro("@IdUser", nuevo.IdUser);
                datos.setearParametro("@IdArticulo", nuevo.IdArticulo);

                datos.ejecutarAccion();
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
        public void eliminar(int idArticulo, int idUser)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
               
                datos.setearConsulta("delete from FAVORITOS where IdArticulo =@IdArticulo AND IdUser=@IdUser");
                datos.setearParametro("@IdArticulo", idArticulo);
                datos.setearParametro("@IdUser", idUser);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object listarConId(string id)
        {
            AccesoDatos datos = new AccesoDatos();
            // List<Articulos> lista = new List<Articulos>();
            FavoritosUser aux = new FavoritosUser();
            try
            {
                datos.setearConsulta("select IdUser, IdArticulo FROM FAVORITOS WHERE IdArticulo = " + id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    aux.IdUser = (int)datos.Lector["IdUser"];
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                }
                return aux;

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
    }

}
