    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyComercio.Data;
using MyComercio.Models;

namespace MyComercio.Controllers
{
    public class VentasVMController : Controller
    {

        private readonly MyComercioContext _context;

        public VentasVMController(MyComercioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewVenta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewVenta(VentasViewModel model)
        {

            if (ModelState.IsValid)
            {
                _context.Venta.Add(model.VentaCabecera);
                _context.SaveChanges();
            }


            return View();
        }

        private static List<VentaDetalle> ventaDetalles = new List<VentaDetalle>();

        public JsonResult addProducto(int IdProducto, int cantidad)
        {
            var newProducto = new VentaDetalle();
            newProducto.IdProducto = IdProducto;
            newProducto.Cantidad = cantidad;

            ventaDetalles.Add(newProducto);

            return Json(ventaDetalles);
        }

        
    }
}
