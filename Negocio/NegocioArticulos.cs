using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Datos;
using dominio;

namespace Negocio
{
    public class NegocioArticulos
    {
        public List<Articulos> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulos> lista = new List<Articulos>();
            
            try
            {
                datos.setearConsulta("select ARTICULOS.Id, Codigo, Nombre ,ARTICULOS.Descripcion,M.Descripcion Marca,C.Descripcion Categoria, IdMarca, IdCategoria, ImagenUrl , Precio from ARTICULOS, MARCAS M , CATEGORIAS C WHERE M.Id =ARTICULOS.IdMarca AND ARTICULOS.IdCategoria=C.Id");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    aux.Marca = new Marcas();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];

                    aux.Categoria = new Categorias();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];

                    aux.Precio = (decimal)datos.Lector["Precio"];

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
        public  List<Articulos> listarConSP()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulos> lista = new List<Articulos>();

            try
            {
                datos.setearProcedimiento("storedListar");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    aux.Marca = new Marcas();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];

                    aux.Categoria = new Categorias();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];

                    aux.Precio = (decimal)datos.Lector["Precio"];

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

        public void agregar(Articulos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("storedAltaArticulo");
                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@imagenUrl", nuevo.ImagenUrl);
                datos.setearParametro("@precio", nuevo.Precio);
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
        /*
        public void modificar(Disco modificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update DISCOS set Titulo = @titulo, CantidadCanciones = @canciones, UrlImagenTapa = @img, IdEstilo = @idEstilo, IdTipoEdicion = @idTipoEdicion Where Id = @id");
                datos.setearParametro("@titulo", modificado.Titulo);
                datos.setearParametro("@canciones", modificado.CantidadCanciones);
                datos.setearParametro("@img", modificado.UrlImagenTapa);
                datos.setearParametro("@IdEstilo", modificado.Estilo.Id);
                datos.setearParametro("@IdTipoEdicion", modificado.Edicion.Id);
                datos.setearParametro("@id", modificado.Id);

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

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from discos where Id = @Id");
                datos.setearParametro("Id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }*/
    }
}
