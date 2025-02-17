

function get(valor) {
   return document.getElementById(valor).value;
}

function set(idControl, valor) {
    document.getElementById(idControl).value = valor;
}

async function fetchGet(url, tiporespuesta, callback) {
    try {
        let raiz = document.getElementById("hdfOculto").value;
        let urlCompleta = window.location.protocol + "//" + window.location.host + "/" + raiz + url;
        let res = await fetch(urlCompleta);

        let data;
        if (tiporespuesta === "json") {
            data = await res.json();
        } else if (tiporespuesta === "text") {
            data = await res.text();
        } else {
            data = res;
        }

        callback(data);
    } catch (e) {
        alert("Algo salió mal: " + e.message);
    }
}

let objconfigurationGlobal;


function fetchpost(url, tiporespuesta, frm, callback) {
    try {
        let raiz = document.getElementById("hdfOculto").value;
        let urlCompleta = window.location.protocol + "//" + window.location.host + "/" + raiz + url;

        let res = await fetch(urlCompleta, {
            method: "POST",
            body: frm,

        });

        if (tiporespuesta === "json") {
            data = await res.json();
        } else if (tiporespuesta === "text") {
            data = await res.text();
        } else {
            data = res;
        }

        callback(res);

    } catch(e) {
        alert("Ocurrio un problema en post: " + e.message);
    }
}
function pintar(objConfiguration) {
    objconfigurationGlobal = objConfiguration;
    fetchGet(objConfiguration.url, "json", function (res) {
        let contenido = "";
        contenido += "<div id='divContenedosTabla'>";
        contenido += generarTabla(res);
        contenido += "</div>";
        document.getElementById("divtabla").innerHTML = contenido;
    });
}

function generarTabla(res) {
    let contenido = "";
    let gCabeceras = objconfigurationGlobal.cabeceras;
    let gPropiedades = objconfigurationGlobal.propiedades;
    let nroRegistros = res.length;

    contenido += "<table class='table'>";
    contenido += "<thead><tr>";

    for (let i = 0; i < gCabeceras.length; i++) {
        contenido += "<th>" + gCabeceras[i] + "</th>";
    }

    contenido += "</tr></thead><tbody>";

    for (let i = 0; i < nroRegistros; i++) {
        let obj = res[i];
        contenido += "<tr>";

        for (let j = 0; j < gPropiedades.length; j++) {
            let propiedadActual = gPropiedades[j];
            contenido += "<td>" + obj[propiedadActual] + "</td>";
        }

        contenido += "</tr>";
    }

    contenido += "</tbody></table>";
    return contenido;
}

