using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult GetAll()
        {
            ML.Producto producto = new ML.Producto();
            ML.Result result = BL.Producto.GetAll();
            if (result.Correct)
            {
                producto.Productos = result.Objects;
                return View(producto);
            }
            else
            {
                return View(producto);
            }
        }
        [HttpGet]
        public ActionResult Form(int? IdProducto)

        {

            ML.Result resultProveedores = BL.Proveedores.GetAll();

            ML.Producto producto = new ML.Producto();
            producto.Proveedor = new ML.Proveedor();


            if (resultProveedores.Correct)
            {

                producto.Proveedor.Proveedores = resultProveedores.Objects;
            }
            if (IdProducto == null)
            {
                //add //formulario vacio
                return View(producto);
            }
            else
            {
                //getById
                ML.Result result = BL.Producto.GetById(IdProducto.Value); //2


                if (result.Correct)
                {

                    producto = (ML.Producto)result.Object;//unboxing
                    producto.Proveedor.Proveedores = resultProveedores.Objects;
                    //update
                    return View(producto);
                }
                else
                {
                    result.ErrorMesssage = "Ocurrio un error al consultar la informacion";
                    return View(producto);
                }
            }
        }

        [HttpPost] //Hacer el registro
        public ActionResult Form(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            if (producto.IdProducto != null)
            {
                //UPDATE
                result = BL.Producto.Update(producto);
                ViewBag.Message = "Se ha modificado el registro";
            }
            else
            {
                //Add
                result = BL.Producto.Add(producto);
                ViewBag.Message = "Se ha agregado el registro";


            }
            if (result.Correct)
            {
                return PartialView("Modal");
            }
            else
            {
                return PartialView("Modal");
            }
        }

        public ActionResult Delete(int IdProducto)
        {
            ML.Result result = BL.Producto.Delete(IdProducto);
            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado el registro";
                return PartialView("Modal");
            }
            else 
            {
                ViewBag.Message = "No se ha eliminado el registro por: "+result.ErrorMesssage;
                return PartialView("Modal");
            }

        }
    }
}