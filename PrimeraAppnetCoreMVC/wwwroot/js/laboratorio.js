window.onload = function () {
    listarLaboratorio();
};

async function listarLaboratorio() {
    pintar({
        url: "Laboratorio/listarLaboratorio",
        cabeceras: ["ID Laboratorio","Nombre Laboratorio", "Direccion", "Persona de contacto"],
        propiedades: ["idLaboratorio","nombre", "direccion", "personacontacto"]
    });
}
async function filtrarLaboratorio() {
    let idLaboratorio = document.getElementById("idLaboratorio").value;
    let nombre = document.getElementById("nombre").value;
    let direccion = document.getElementById("direccion").value;
    let personacontacto = document.getElementById("personacontacto").value;

    pintar({
        url: "Laboratorio/filtrarLaboratorio?idLaboratorio=" + encodeURIComponent(idLaboratorio) +
            "&nombre=" + encodeURIComponent(nombre) +
            "&direccion=" + encodeURIComponent(direccion) +
            "&personacontacto=" + encodeURIComponent(personacontacto),
        cabeceras: ["ID Laboratorio", "Nombre Laboratorio", "Direccion", "Persona de contacto"],
        propiedades: ["idLaboratorio", "nombre", "direccion", "personacontacto"]
    });
}