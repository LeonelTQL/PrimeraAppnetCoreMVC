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
        eliminar: true
    };
    pintar(objTipoMedicamento);
}

async function eliminarMed() {
    let id = document.getElementById("idEli").value;
    fetchGet("TipoMedicamento/eliminarMed?id=" + id, "none", function (res) { });
    alert(id);
}

async function filtrarMedicamento() {
    let id = document.getElementById("idMed").value;
    let nombre = document.getElementById("nombre").value;
    let idLab = document.getElementById("idLab").value;
    let idTip = document.getElementById("idTip").value;

    pintar({
        url: "TipoMedicamento/filtrarMedicamento?idMed=" + id + "&nombre=" + nombre + "&idLab=" + idLab + "&idTip=" + idTip,
        cabeceras: ["ID Medicamento", "Nombre", "ID Laboratorio", "ID Tipo Medicamento"],
        propiedades: ["idMedicamento", "nombre", "idLaboratorio", "idTipoMedicamento"]
    });
}

function filtarTipoMedicamento() {
    let descripcion = get("txtDescripcion");
    if (descripcion == "") {
        listarTipoMedicamento();
    } else {
        objTipoMedicamento.url = "TipoMedicamento/FiltrarTipoMedicamento?descripcion=" + descripcion;
        pintar(objTipoMedicamento);
    }
}
function guardarTipoMedicamento() {
    let frmGuardar = document.getElementById("frmGuardarTipoMedicamento");

    let frm = new FormData(frmGuardar);
    fetchpost("TipoMedicamento/guardarTipoMedicamento", "text", frm, function (res) {
        if (res == "1") {
            listarTipoMedicamento();
            LimpiarDatos("frmGuardarTipoMedicamento");
        } else {
            alert("Ocurrio un error al guardar el tipo de medicamento");
        }
    });
}
