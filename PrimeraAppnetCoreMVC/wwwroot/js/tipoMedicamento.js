window.onload = function () {
    listarTipoMedicamento();
};

let objTipoMedicamento;
async function listarTipoMedicamento() {
    objTipoMedicamento = {
        url: "TipoMedicamento/listarTipoMedicamento",
        cabeceras: ["ID Tipo de Medicamento", "Nombre", "Descripción"],
        propiedades: ["idMedicamento", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        propiedadId: "idMedicamento"
    };
    pintar(objTipoMedicamento);
}

async function eliminarMed() {
    let id = document.getElementById("idEli").value;
    fetchGet("TipoMedicamento/eliminarMed?id=" + id, "none", function (res) { });
    alert(id);
}


function filtrarTipoMedicamento() {
    let forma = document.getElementById("frmBusquedaTipoMedicamento");
    let frm = new FormData(forma);
    fetchpost("TipoMedicamento/FiltrarTipoMedicamento", "json", frm, function (data) {
        document.getElementById("divContenedorTabla").innerHTML = generarTabla(data);
    });

}
function guardarTipoMedicamento() {
    let frmGuardar = document.getElementById("frmGuardarTipoMedicamento");
    let frm = new FormData(frmGuardar);
    let idMedicamento = document.getElementById("txtidMedicamento").value;

    let url = idMedicamento ? "TipoMedicamento/editarTipoMedicamento" : "TipoMedicamento/guardarTipoMedicamento";

    fetchpost(url, "text", frm, function (res) {
        if (res == "1") {
            listarTipoMedicamento();
            LimpiarTipoMedicamento();
        }
    });
}

function LimpiarTipoMedicamento(){
    LimpiarDatos("frmGuardarTipoMedicamento");
    listarTipoMedicamento();
}
function LimpiarTipoMedicamentoB() {
    LimpiarDatos("frmBusquedaTipoMedicamento");
    listarTipoMedicamento();
}

function Editar(id) {
    recuperar("TipoMedicamento/recuperarTipoMedicamento?idTipoMedicamento=" + id, "frmGuardarTipoMedicamento");
}