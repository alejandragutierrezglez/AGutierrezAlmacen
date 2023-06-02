using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Proveedor
    {
        public int? IdProveedor { get; set; }
        public string Codigo { get; set; }
        public string RazonSocial { get; set; }
        public string RFC { get; set; }
        public List<object> Proveedores { get; set; }
    }
}
