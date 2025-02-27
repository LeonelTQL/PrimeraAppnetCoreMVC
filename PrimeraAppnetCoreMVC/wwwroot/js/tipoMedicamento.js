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

    fetchGet("TipoMedicamento/recuperarTipoMedicamento?idTipoMedicamento=" + id, "json", function (medicamento) {
        if (medicamento) {

            document.getElementById("txtidMedicamentoModal").value = medicamento.idMedicamento;
            document.getElementById("txtnombreModal").value = medicamento.nombre;
            document.getElementById("txtdescripcionModal").value = medicamento.descripcion;


            var myModal = new bootstrap.Modal(document.getElementById('exampleModal'), {
                keyboard: false
            });
            myModal.show();
        } else {
            console.error('No se encontraron datos para el medicamento');
        }
    });
}

function guardarEdicion() {
    let frmEditar = document.getElementById("frmEditarTipoMedicamento");
    let frm = new FormData(frmEditar);


    Confirmacion("Confirmar", "¿Desea guardar los cambios?", function () {
        fetchpost("TipoMedicamento/editarTipoMedicamento", "text", frm, function (res) {
            if (res == "1") {
                Exito();
                listarTipoMedicamento();
                var modal = bootstrap.Modal.getInstance(document.getElementById('exampleModal'));
                modal.hide();
            } else {
                Error();
            }
        });
    });
}