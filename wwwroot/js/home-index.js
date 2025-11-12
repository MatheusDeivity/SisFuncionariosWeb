document.addEventListener("DOMContentLoaded", function () {

    const selectProfissional = document.getElementById("profissionalSelect");
    const campoSalario = document.getElementById("salarioAtual");

    if (!selectProfissional || !campoSalario) {
        return;
    }

    selectProfissional.addEventListener("change", function () {
        var id = this.value;

        if (id === "") {
            campoSalario.value = "";
            return;
        }

        fetch("/Home/GetSalario?id=" + id)
            .then(response => response.json())
            .then(data => {
                campoSalario.value = data.salario.toLocaleString('pt-BR', {
                    style: 'currency',
                    currency: 'BRL'
                });
            })
            .catch(error => {
                console.error("Erro ao buscar salário:", error);
                campoSalario.value = "Erro ao carregar";
            });
    });
});
