//Declaro URL necesarias

var urlClients = "/Clientes/GetCliente";
var urlProductos = "/Producto/GetProductos";


//Busqueda de Clientes
//Cuando ClienteBusqueda cambie vamos a ir controller a buscar a los clientes que contengan lo que se escribio

$("#ClienteBusqueda").keyup(function (value) {

    var filtroCliente = $("#ClienteBusqueda").val();

    $.getJSON(urlClients, { nombre: filtroCliente },

        function (data) {

            // console.log(data);

            var items = "";
            $("#Resultados").empty();
            $.each(data, function (i, cliente) {


                //items += '<div class="listaResultados" onclick="completarDatos(' + "'" + cliente.id + "'," + "'" + cliente.nombre + "'" + ');" >' + cliente.nombre + '  ' + cliente.apellido + ' </div>';
                items += '<div class="listaResultados" onclick="completarDatosCliente(' + "'" + cliente.id + "'," + "'" + cliente.nombre + "'," + "'" + cliente.apellido + "'" + ');" >' + cliente.nombre + '  ' + cliente.apellido + ' </div>';

            });
            $("#Resultados").html(items);
        });
});

function completarDatosCliente(id, nombre, apellido) {

    //console.log(id + ' ' + nombre);
    $("#IdCliente").val(id);
    $("#ClienteBusqueda").val(id + " " + nombre + " " + apellido);
    //$("#ClienteBusqueda").val(id);
    $("#Resultados").empty();
}

$("#Resultados").hover(function () {
    $(this).css("background-color", "yellow");
}, function () {
    $(this).css("background-color", "pink");
});

    




//Busqueda de Productos

$("#BuscaProducto").keyup(function (value) {

    $("#ProductoID").val(null);

    var filtroProducto = $("#BuscaProducto").val()

    $.getJSON(urlProductos, { productoDescript: filtroProducto },

        function (data) {

            item = "";
            $("#ResultadoProductos").empty();

            $.each(data, function (i, producto) {

                item += item += '<div class="listaResultados" onclick="completarDatosProducto(' + "'" + producto.id + "'," + "'" + producto.descripcion + "'" + ');" >' + producto.id + '  ' + producto.descripcion + ' </div>';

            });

            $("#ResultadoProductos").html(item);

        });
});

function completarDatosProducto(id, descripcion) {

    $("#BuscaProducto").val(id + "-" + descripcion);
    $("#ProductoID").val(id);
    $("#ResultadoProductos").empty();
}

function addProducto() {
    var url = "/VentasVM/AddProducto";
    var productoId = $("#ProductoID").val();
    var cantidad = $("#CantidadID").val();

    $.getJSON(url, { IdProducto: productoId, Cantidad: cantidad },

        function (data) {

            var item = "";
            $.each(data, function (i, producto) {

                item += '<div class="col-md-4">' + producto.idProducto + '</div><div class="col-md-4">' + producto.cantidad + '</div>';
            });

            $("#ListadoProductos").html(item);

        }
    );
}



//Lista de Venta Detalle

function MostrarDetalleId(){

    //Creamos una funcion ajax que envie los datos al metodo Buscar del Controler Persona
    $.ajax({
        //Direccion donde nos queremos comunicar Controller/Metodo
        url: "/VentaDetalles/MostrarDetalles",
        //parametros que le pasamos a el Metodo del Controller ( si se fijan en el Controller el metodo Busqueda, recibe como parametro "filtro")
        data: { 'idVenta': Id },
        //El tipo es post ya que enviamos datos
        type: "post",
        cache: false,
        success: function (retorno) {
            //Si el metodo busqueda del controller devuelve algo, lo guardamos en retorno - lo que devuelve es la pagina (View) buscar, osea es un pedazo de codigo HTML que podemos insertar en el DivDinamico
            $("#DivDetalleVenta").html(retorno);
        },
        error: function (retorno) {
            //Si el metodo ajax falla entra por aca y nos advierte de un error
            alert("Se ha producido un error");
        }
    });
    return true;
};



    


