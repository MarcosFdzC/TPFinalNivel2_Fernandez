using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;
using System.Runtime.Remoting.Channels;
using System.Net;
using System.Data.Common;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("SELECT Art.Id, Art.Codigo, Art.Nombre, Art.Descripcion, Art.IdMarca, Marca.Descripcion, Art.IdCategoria, Cat.Descripcion, Art.ImagenUrl, Art.Precio FROM ARTICULOS Art, MARCAS Marca, CATEGORIAS Cat WHERE Art.IdMarca = Marca.Id AND Art.IdCategoria = Cat.Id");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    if (!(datos.Lector["Art.Id"] is DBNull))
                        aux.Id = (int)datos.Lector["Art.Id"];

                    if (!(datos.Lector["Art.Codigo"] is DBNull))
                        aux.Codigo = (string)datos.Lector["Art.Codigo"];

                    if (!(datos.Lector["Art.Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Art.Nombre"];

                    if (!(datos.Lector["Art.Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Art.Descripcion"];

                    aux.Marca = new Marca();
                    if (!(datos.Lector["Art.IdMarca"] is DBNull))
                        aux.Marca.Id = (int)datos.Lector["Art.IdMarca"];
                    if (!(datos.Lector["Marca.Descripcion"] is DBNull))
                        aux.Marca.Descripcion = (string)datos.Lector["Marca.Descripcion"];

                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["Art.IdCategoria"] is DBNull))
                        aux.Categoria.Id = (int)datos.Lector["Art.IdCategoria"];
                    if (!(datos.Lector["Cat.Descripcion"] is DBNull))
                        aux.Categoria.Descripcion = (string)datos.Lector["Cat.Descripcion"];

                    if (!(datos.Lector["Art.ImagenUrl"] is DBNull))
                        aux.Imagen = (string)datos.Lector["Art.ImagenUrl"];

                    if (!(datos.Lector["Art.Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Art.Precio"];
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
    }
}
