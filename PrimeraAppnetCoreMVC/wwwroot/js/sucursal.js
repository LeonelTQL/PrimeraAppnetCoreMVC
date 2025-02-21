window.onload = function () {
    listarSucursales();
};
let objSucursal;
async function listarSucursales() {

    objSucursal =
    {
        url: "Sucursal/listarSucursales",
        cabeceras: ["ID Sucursal", "Nombre ", "Direccion"],
        propiedades: ["idsucursal", "nombre", "direccion"],
        editar: true,
        eliminar: true
    }
    pintar(objSucursal);
}


async function recuperarSucursales() {
    let id = document.getElementById("txtSucursalId").value.trim();

    if (id === "" || isNaN(id)) {
        alert("Ingrese un ID válido de sucursal.");
        return;
    }

    fetchGet(`Sucursal/RecuperarSucursal?id=${id}`, "json", function (res) {
        if (res && res.length > 0) {
            pintar({
                url: `Sucursal/RecuperarSucursal?id=${id}`,
                cabeceras: ["ID Sucursal", "Nombre", "Dirección"],
                propiedades: ["idsucursal", "nombre", "direccion"]
            });
        } else {
            document.getElementById("divtabla").innerHTML = "<p>No se encontró la sucursal.</p>";
        }
    });
}

function filtrarSucursal() {
    let forma = document.getElementById("frmBusquedaSucursal");
    let frm = new FormData(forma);
    fetchpost("Sucursal/FiltrarSucursal", "json", frm, function (data) {
        document.getElementById("divContenedorTabla").innerHTML = generarTabla(data);
    });
}



function LimpiarSucursal() {
    LimpiarDatos("frmBusquedaSucursal");
    listarSucursales();
}


function guardarSucursal() {
    let forma = document.getElementById("frmGuardarSucursal");
    let frm = new FormData(forma);
    fetchpost("Sucursal/GuardarSucursal", "text", frm, function (res) {
        if (res === "1") {
            listarSucursales();
            
        }
    });
}

function LimpiarSucursalG() {
    LimpiarDatos("frmGuardarSucursal");
    listarSucursales();
}