$(document).ready(function () {
    $('label.tree-toggler').click(function () {
        $(this).parent().children('ul.tree').toggle(300);
    });

    $(document).on('click', '', function () {

    });
});

function carregarIndicadoresTecnicos(idSistema) {
    chamadaAjaxPost(urlObterIndicadoresTecnicos, {
        idSistema: idSistema
    }, function (retorno) {
        $('#tab-tecnico').empty();
        for (var i = 0; i < retorno.IndicadoresTecnicos.Indicadores.length; i++) {
            var indicadorIteracao = retorno.IndicadoresTecnicos.Indicadores[i];
            var listaDatas = [];
            var listaValores = [];
            for (var j = 0; j < indicadorIteracao.Valores.length; j++) {
                var valorIteracao = indicadorIteracao.Valores[j];
                listaDatas.push(valorIteracao.Data);
                listaValores.push(valorIteracao.Valor);
            }
            var componenteIndicador = $('.template-indicador .indicador').clone();
            componenteIndicador.find('[data-nome-indicador]').text(indicadorIteracao.Tipo.Nome);
            var idCanvas = 'grafico-indicador-' + indicadorIteracao.Tipo.Id;
            componenteIndicador.find('[data-canvas-grafico]').attr('id', idCanvas);
            $('#tab-tecnico').append(componenteIndicador);
            montarGrafico(idCanvas, listaDatas, listaValores);
        }
    }, null, true, false);
}

function montarGrafico(idCanvas, arrayLabels, arrayValores) {
    var ctx = document.getElementById(idCanvas).getContext('2d');
    return new Chart(ctx, {
        type: 'line',
        data: {
            labels: arrayLabels,
            datasets: [{
                label: '',
                data: arrayValores,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)'
                ],
                borderColor: [
                    'rgba(255,99,132,1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}