using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezAlmacenEntities context = new DL.AGutierrezAlmacenEntities())
                {
                    var query = context.ProductoGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var itemProducto in query)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.IdProducto = itemProducto.IdProducto;
                            producto.Codigo = itemProducto.Codigo;
                            producto.Descripcion = itemProducto.Descripcion;
                            producto.Unidad = itemProducto.Unidad;
                            producto.Costo = itemProducto.Costo.Value;

                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = itemProducto.IdProveedor.Value;
                            producto.Proveedor.RazonSocial = itemProducto.RazonSocial;

                            result.Objects.Add(producto);

                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMesssage = Ex.Message;
                result.Ex = Ex;
            }

            return result;
        }
        public static ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezAlmacenEntities context = new DL.AGutierrezAlmacenEntities())
                {
                    var query = context.ProductoGetById(IdProducto).FirstOrDefault();
                    if (query != null)
                    {
                        ML.Producto producto = new ML.Producto();
                        producto.IdProducto = query.IdProducto;
                        producto.Codigo = query.Codigo;
                        producto.Descripcion = query.Descripcion;
                        producto.Unidad = query.Unidad;
                        producto.Costo = query.Costo.Value;
                        producto.Proveedor = new ML.Proveedor();
                        producto.Proveedor.IdProveedor = query.IdProveedor.Value;
                        producto.Proveedor.RazonSocial = query.RazonSocial;

                        result.Object = producto;

                    }
                    result.Correct = true;

                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMesssage = Ex.Message;
                result.Ex = Ex;
            }

            return result;
        }

        public static ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezAlmacenEntities context = new DL.AGutierrezAlmacenEntities())
                {
                    var query = context.ProductoAdd(producto.Proveedor.IdProveedor, producto.Codigo, producto.Descripcion, producto.Unidad, producto.Costo);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }
            catch (Exception Ex)
            {
                result.ErrorMesssage = Ex.Message;
                result.Ex = Ex;
                result.Correct = false;
            }
            return result;
        }
        public static ML.Result Update(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezAlmacenEntities context = new DL.AGutierrezAlmacenEntities())
                {
                    var query = context.ProductoUpdate(producto.IdProducto, producto.Proveedor.IdProveedor, producto.Codigo, producto.Descripcion, producto.Unidad, producto.Costo);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.ErrorMesssage = Ex.Message;
                result.Ex = Ex;
                result.Correct = false;
            }
            return result;  
        
        }
        public static ML.Result Delete(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezAlmacenEntities context = new DL.AGutierrezAlmacenEntities())
                {
                    var query = context.ProductoDelete(IdProducto);
                    if (query > 0)
                    {
                        result.Correct = true;

                    }
                    else { 
                        result.Correct= false;
                    }
                }
            }
            catch (Exception Ex)
            {
              
                result.Ex = Ex;
                result.Correct = false;
                result.Message= Ex.Message;
            }
            return result;
        }

    }
}
