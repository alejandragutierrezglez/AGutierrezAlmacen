using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Proveedores
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezAlmacenEntities context = new DL.AGutierrezAlmacenEntities())
                {
                    var query = context.ProveedoresGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Proveedor proveedor = new ML.Proveedor();
                            proveedor.IdProveedor = item.IdProveedor;
                            proveedor.Codigo = item.Codigo;
                            proveedor.RazonSocial= item.RazonSocial;
                            proveedor.RFC = item.RFC;

                            result.Objects.Add(proveedor);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = true;
                result.ErrorMesssage = Ex.Message;
                result.Ex = Ex;
            }
            return result;
        }
    }
}
