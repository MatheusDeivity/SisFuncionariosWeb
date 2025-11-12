document.addEventListener("DOMContentLoaded", function () {

    function ApenasNumeros(e) {
        e.target.value = e.target.value.replace(/\D/g, '');
    }

    function ApenasLetras(e) {
        e.target.value = e.target.value.replace(/[^a-zA-Z\u00C0-\u017F\s\.]/g, '');
    }

    const campoMascara = document.getElementById("salarioMascara");
    const campoReal = document.getElementById("salarioReal");

    if (campoMascara && campoReal) {
        campoMascara.addEventListener("input", function (e) {
            let valor = e.target.value;
            let valorLimpo = valor.replace(/\D/g, "");

            if (valorLimpo.length === 0) {
                campoReal.value = "";
                e.target.value = "";
                return;
            }

            let valorDecimal = (parseInt(valorLimpo) / 100).toFixed(2);
            campoReal.value = valorDecimal.replace(".", ",");

            let valorFormatado = valorDecimal
                .replace(".", ",")
                .replace(/\B(?=(\d{3})+(?!\d))/g, ".");

            e.target.value = "R$ " + valorFormatado;
        });

        if (campoReal.value) {
            let valorCsharp = campoReal.value;
            let valorSoDigitos = valorCsharp.replace(/\D/g, "");
            campoMascara.value = valorSoDigitos;
            campoMascara.dispatchEvent(new Event('input'));
        }
    }

    const campoNome = document.getElementById("nomeInput");
    if (campoNome) {
        campoNome.addEventListener("input", ApenasLetras);
    }

    const campoTelefone = document.getElementById("telefoneInput");
    if (campoTelefone) {
        campoTelefone.addEventListener("input", ApenasNumeros);
    }

    const campoRG = document.getElementById("rgInput");
    if (campoRG) {
        campoRG.addEventListener("input", ApenasNumeros);
    }

    const campoCEP = document.getElementById("cepInput");
    if (campoCEP) {
        campoCEP.addEventListener("input", ApenasNumeros);
    }

});
