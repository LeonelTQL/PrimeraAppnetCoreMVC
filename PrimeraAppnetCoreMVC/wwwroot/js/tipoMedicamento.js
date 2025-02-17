window.onload = function () {
    listarTipoMedicamento();
};

let objTipoMedicamento;
async function listarTipoMedicamento() {
    objTipoMedicamento = {
        url: "TipoMedicamento/listarTipoMedicamento",
        cabeceras: ["ID Tipo de Medicamento", "Nombre", "Descripción"],
        propiedades: ["idMedicamento", "nombre", "descripcion"]
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

//function filtrarTipoMedicamento() {
//    let descripcion = document.getElementById("txtDescripcion").value;
//    objTipoMedicamento.url = "TipoMedicamento/FiltrarTipoMedicamento?descripcion=" + descripcion;
//    pintar(objTipoMedicamento);
//}

//function LimpiarControl() {
//    listarTipoMedicamento();
//    set("txtDescripcion", "");
//}

function filtarTipoMedicamento() {
    let descripcion = get("txtDescripcion");
    if (descripcion == "") {
        listarTipoMedicamento();
    } else {
        objTipoMedicamento.url = "TipoMedicamento/FiltrarTipoMedicamento?descripcion=" + descripcion;
        pintar(objTipoMedicamento);
    }
}


    //fetchGet("TipoMedicamento/listarTipoMedicamento", "json", function (res) {
    //    let nroRegistros = res.length;
    //    alert(nroRegistros);
        /*
            [
              {
                "idMedicamento": 1,
                "nombre": "Analgésico",
                "descripcion": "Desc 1"
              },
              {
                "idMedicamento": 2,
                "nombre": "Cannabis",
                "descripcion": "Desc 1"
              },
              {
                "idMedicamento": 3,
                "nombre": "Vitamina",
                "descripcion": "Desc 1"
              }
            ]
        */
    //    let contenido = "";
    //    contenido += "<table class ='table'>";
    //    contenido += "<thead>";

    //    //primera fila con los headers
    //    contenido += "<tr>";
    //    contenido += "<td>Id Tipo Medicamento</td>";
    //    contenido += "<td>Nombre Medicamento</td>";
    //    contenido += "<td>Descripcion Medicamento</td>";
    //    contenido += "</tr >";

    //    contenido += "</thead>";

    //    contenido += "<tbody>"
        
    //    for (let i = 0; i < nroRegistros; i++) {
    //        obj = res[i]
    //        contenido += "<tr>";
    //        contenido += "<td>" + obj.idMedicamento + "</td>";
    //        contenido += "<td>" + obj.nombre + "</td>";
    //        contenido += "<td>" + obj.descripcion + "</td>";
    //        contenido += "</tr>";
    //    }

    //    contenido += "</tbody >"
    //    contenido += "</table>";

    //    document.getElementById("divtabla").innerHTML = contenido;
    //});
    //try {
    //    let raiz = document.getElementById("hdfOculto").value;

    //    //http://localhost....
    //    let urlCompleta = window.location.protocol + "//" + window.location.host + "/" + raiz + "TipoMedicamento/listarTipoMedicamento";
    //    let res = await fetch(urlCompleta);
    //    res = await res.json();

    //    //Json

    //    alert(res);
    //    alert(JSON.stringify(res));
    //} catch(e) {
    //    alert("algo salio mal");
    //}