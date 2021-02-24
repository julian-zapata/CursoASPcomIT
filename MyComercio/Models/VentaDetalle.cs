using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Models
{
    public class VentaDetalle
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }

        [NotMapped] //propiedad para no agregar a la base de datos
        public string  DescripcionProducto { get { return GetProducto().Descripcion; } }


        public Producto GetProducto()
        {
            Producto producto;
            using (var _context = new Data.MyComercioContext())
            {
                producto = _context.Producto.Where(x => x.Id == IdProducto).FirstOrDefault();
            }

            return producto;
        }

    }
}
