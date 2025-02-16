window.onload = function () {
    listarSucursales();
};
let objSucursal;
async function listarSucursales() {

    objSucursal =
    {
        url: "Sucursal/listarSucursales",
        cabeceras: ["ID Sucursal", "Nombre ", "Direccion"],
        propiedades: ["idsucursal", "nombre", "direccion"]
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

function filtrarSucurcales() {
    let nombresucursal = get("txtSucursalNombre");
    objSucursal.url = "Sucursal/FiltrarSucursal?nombre=" + nombresucursal;
    pintar(objSucursal);
}

function LimpiarControl() {
    listarSucursales();
    document.getElementById("txtSucursalNombre").value = "";
}



