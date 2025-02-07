window.onload = function () {
    listarMedicamento();
}


async function listarMedicamento() {
    fetchGet("Medicamentos/saludos","text", function (res) {
        alert(res);
    })
    fetchGet("Medicamentos/numeroEntero", "text", function (res) {
        alert(res);
    })
}