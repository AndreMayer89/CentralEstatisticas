$(function () {
    $(document).on('click', 'button[data-voltar]', function () {
        window.location.href = urlLista;
    });

    $(document).on('click', 'button[data-salvar]', function () {
        sistema.salvar();
    });
});

var sistema = sistema || {
    salvar: function () {
        alert('salvar');
    }
};