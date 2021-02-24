using Microsoft.AspNetCore.Mvc.Rendering;
using MyComercio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Helper
{
    public static class MyHelper
    {

        //private readonly MyComercioContext _context;
        ////readonly = unicamente lectura

        //public MyHelper(MyComercioContext context)
        //{
        //    _context = context;
        //}

        //public MyHelper()
        //{

        //}            
        //Si es estatic no hace falta constructores

        private static MyComercioContext _context = new MyComercioContext();

        public static SelectList GetPaisesSelectList()
        {

            var lstPaises = _context.Pais.ToList();
            var SelectListPaises = new SelectList(lstPaises, "Id", "Description");

            return SelectListPaises;

        }

        public static SelectList GetCiudadesSelectList()
        {

            var lstCiudades = _context.Ciudad.ToList();
            var SelectListCiudades = new SelectList(lstCiudades, "Id", "Descripcion");

            return SelectListCiudades;

        }

        public static SelectList GetCategoriaList()
        {

            var lstCategorias = _context.CategoriaProducto.ToList();
            var SelectListCategorias = new SelectList(lstCategorias, "Id", "Descripcion");

            return SelectListCategorias;

        }
         public static SelectList GetVentasList()
        {

            var lstVentas = _context.Venta.ToList();
            var SelectListVentas = new SelectList(lstVentas, "Id");

            return SelectListVentas;

        }

        public static SelectList GetProductoList()
        {

            var lstProducto = _context.Producto.ToList();
            var SelectListProducto = new SelectList(lstProducto, "Id", "Descripcion");

            return SelectListProducto;

        }
    }
}
