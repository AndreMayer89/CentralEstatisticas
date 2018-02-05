$(function () {
    $(document).on('click', 'button[data-novo]', function () {
        indicadoresTecnicos.criar();
    });

    $(document).on('click', 'button[data-filtrar]', function () {
        indicadoresTecnicos.filtrar();
    });

    $(document).on('click', '[data-coluna-editar] button', function () {
        indicadoresTecnicos.editar($(this).parents('[data-id-indicador-tecnico]').attr('data-id-indicador-tecnico'));
    });

    $(document).on('click', '[data-coluna-remover] button', function () {
        indicadoresTecnicos.remover($(this).parents('[data-id-indicador-tecnico]').attr('data-id-indicador-tecnico'));
    });
});

var indicadoresTecnicos = indicadoresTecnicos || {
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