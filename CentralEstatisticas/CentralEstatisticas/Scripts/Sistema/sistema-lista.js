$(function () {
    $(document).on('click', 'button[data-novo]', function () {
        window.location.href = urlCadastro;
    });

    $(document).on('click', 'button[data-filtrar]', function () {
        sistema.filtrar();
    });
});

var sistema = sistema || {
    filtrar: function () {
        alert('filtrar');
    }
};