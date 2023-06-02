﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Producto
    {
        public int? IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public decimal Costo { get; set; }
        public List<object> Productos { get; set; }
        public ML.Proveedor Proveedor { get; set; }
    }
}
