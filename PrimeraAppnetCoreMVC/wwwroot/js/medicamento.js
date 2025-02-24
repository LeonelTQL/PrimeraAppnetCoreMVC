window.onload = function () {
    listarMedicamento();
    //cargarLaboratorios();
}

let objMedicamento;
async function listarMedicamento() {

    objMedicamento =
    {
        url: "Medicamentos/listarMedicamento",
        cabeceras: ["ID Medicamento", "Nombre", "Laboratorio", "Tipo de Medicamento"],
        propiedades: ["iidmedicamento", "nombremedicamento", "nombrelaboratorio", "nombretipo"],
        divContenedorTabla: "divContenedorTabla",
        editar: true,
        eliminar: true
    }
    pintar(objMedicamento);

    setTimeout(function () {
        let deleteButtons = document.querySelectorAll(".btn-danger");
        deleteButtons.forEach(button => {
            button.onclick = function () {
                let row = this.closest('tr');
                let cells = row.getElementsByTagName('td');
                let id = cells[0].innerText;
                eliminarMedicamento(id);
            }
        });
    }, 100);
}

function filtrarMedicamento() {
    let forma = document.getElementById("frmBusquedaMedicamento");
    let frm = new FormData(forma);
    fetchpost("Medicamentos/FiltrarMedicamento", "json", frm, function (data) {
        document.getElementById("divContenedorTabla").innerHTML = generarTabla(data);
    });
}

function LimpiarMedicamento() {
    LimpiarDatos("frmBusquedaMedicamento");
    listarMedicamento();
}

//async function cargarLaboratorios() {
//    let res = await fetch("Laboratorio/listarLaboratorio");
//    let data = await res.json();
//    let ddl = document.getElementById("ddlLaboratorio");

//    data.forEach(lab => {
//        let option = document.createElement("option");
//        option.value = lab.iidlaboratorio;
//        option.textContent = lab.nombre;
//        ddl.appendChild(option);
//    });
//}

//<select class="form-control" id="ddlLaboratorio" name="IIDLABORATORIO">
//    <option value="0">Seleccione un laboratorio</option>
//</select>


function guardarMedicamento() {
    let forma = document.getElementById("frmGuardarMedicamento");
    let frm = new FormData(forma);
    fetchpost("Medicamentos/GuardarMedicamento", "text", frm, function (res) {
        if (res === "1") {
            listarMedicamento();

        }
    });
}

function LimpiarMedicamentoG() {
    LimpiarDatos("frmGuardarMedicamento");
    listarMedicamento();
}

function eliminarMedicamento(id) {
    if (confirm("¿Está seguro de eliminar el medicamento?")) {
        fetchGet(`Medicamentos/EliminarMedicamento?id=${id}`, "text", function (data) {
            if (data === "1") {
                listarMedicamento();
            }
        });
    }
}