$(document).ready(function () {
    $('label.tree-toggler').click(function () {
        $(this).parent().children('ul.tree').toggle(300);
    });

    $(document).on('click', '.item-menu-sistema', function () {
        $('.item-menu-sistema').removeClass('active');
        $(this).addClass('active');
        carregarInformacoesSistema($(this).attr('data-id-sistema'));
    });
});

function carregarInformacoesSistema(idSistema) {
    chamadaAjaxPost(urlObterIndicadores, {
        idSistema: idSistema
    }, function (retorno) {
        $('[data-nome-sistema]').text(retorno.Sistema.Nome);
        carregarAbaIndicadoresTecnicos(retorno.IndicadoresTecnicos);
        carregarAbaIndicadoresNegocio(retorno.IndicadoresNegocio);
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