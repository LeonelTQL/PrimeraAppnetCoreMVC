﻿window.onload = function () {
    listarLaboratorio();
};

let objLaboratorio;
async function listarLaboratorio() {
    objLaboratorio = {
        url: "Laboratorio/listarLaboratorio",
        cabeceras: ["ID Laboratorio", "Nombre Laboratorio", "Direccion", "Persona de contacto"],
        propiedades: ["idLaboratorio", "nombre", "direccion", "personacontacto"],
        divContenedorTabla: "divContenedorTabla"
    };
    pintar(objLaboratorio);
}

//function filtarLaboratorio() {
//    let nombreLaboratorio = get("txtnombre");
//    let direccion = get("txtdireccion");
//    let personacontacto = get("txtpersonacontacto");

//    if (nombreLaboratorio === "" && direccion === "" && personacontacto === "") {
//        listarLaboratorio();
//    } else {
//        objLaboratorio.url = "Laboratorio/filtrarLaboratorio?nombre=" + nombreLaboratorio + "&direccion=" + direccion + "&personacontacto=" + personacontacto;
//        pintar(objLaboratorio);
//    }
//}

function buscarLaboratorio() {
    let forma = document.getElementById("frmBusquedaLabotarorio");
    let frm = new FormData(forma);
    fetchpost("Laboratorio/filtrarLaboratorio", "json", frm, function (data) {
        document.getElementById("divContenedorTabla").innerHTML = generarTabla(data);
    });
}

function LimpiarLaboratorio() {
    LimpiarDatos("frmBusquedaLabotarorio");
    //setN("txtnombre", "");
    //setN("txtdireccion", "");
    //setN("txtpersonacontacto", "");
    listarLaboratorio();
}