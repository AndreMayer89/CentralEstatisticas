$(function () {
    $(document).on('click', 'button[data-novo]', function () {
        indicadoresNegocio.criar();
    });

    $(document).on('click', 'button[data-filtrar]', function () {
        indicadoresNegocio.filtrar();
    });

    $(document).on('click', '[data-coluna-editar] button', function () {
        indicadoresNegocio.editar($(this).parents('[data-id-indicador-negocio]').attr('data-id-indicador-negocio'));
    });

    $(document).on('click', '[data-coluna-remover] button', function () {
        indicadoresNegocio.remover($(this).parents('[data-id-indicador-negocio]').attr('data-id-indicador-negocio'));
    });
});

var indicadoresNegocio = indicadoresNegocio || {
    filtrar: function () {
        alert('filtrar');
    },
    criar: function () {
        window.location.href = urlCadastro;
    },
    editar: function (id) {
        window.location.href = urlCadastro + '?idMedicao=' + id;
    },
    remover: function (id) {
        alert('remover');
    }
};