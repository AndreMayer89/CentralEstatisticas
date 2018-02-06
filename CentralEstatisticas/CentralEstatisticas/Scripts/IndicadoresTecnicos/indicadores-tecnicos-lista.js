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
        chamadaAjaxPost(urlListarMedicoes, {
            idSistema: $('select[data-filtro-sistema]').val()
        }, function (retorno) {
            alert('filtrar');
        }, null, true, true);
    },
    criar: function () {
        window.location.href = urlCadastro;
    },
    editar: function (idMedicao) {
        window.location.href = urlCadastro + '?idMedicao=' + idMedicao;
    },
    remover: function (idMedicao) {
        chamadaAjaxPost(urlRemoverMedicao, {
            idMedicao: idMedicao
        }, function (retorno) {
            $('tr[data-id-indicador-tecnico=' + idMedicao + ']').remove();
        }, null, true, true);
    }
};