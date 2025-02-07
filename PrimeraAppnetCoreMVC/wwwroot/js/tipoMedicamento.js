window.onload = function () {
    listarTipoMedicamento();
};

async function listarTipoMedicamento() {
    pintar({
        url: "TipoMedicamento/listarTipoMedicamento",
        cabeceras: ["Id Tipo Medicamento", "Nombre Medicamento", "Descripción"],
        propiedades: ["idMedicamento", "nombre", "descripcion"]
    });
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