function carregarAbaIndicadoresNegocio(indicadoresNegocio) {
    $('#tab-negocio').empty();
    for (var i = 0; i < indicadoresNegocio.Indicadores.length; i++) {
        var indicadorIteracao = indicadoresNegocio.Indicadores[i];
        var listaDatas = [];
        var listaValores = [];
        for (var j = 0; j < indicadorIteracao.Valores.length; j++) {
            var valorIteracao = indicadorIteracao.Valores[j];
            listaDatas.push(valorIteracao.DataString);
            listaValores.push(valorIteracao.Valor);
        }
        var componenteIndicador = $('.template-indicador .indicador').clone();
        componenteIndicador.find('[data-nome-indicador]').text(indicadorIteracao.Tipo);
        var idCanvas = 'grafico-indicador-negocio-' + i;
        componenteIndicador.find('[data-canvas-grafico]').attr('id', idCanvas);
        $('#tab-negocio').append(componenteIndicador);
        montarGrafico(idCanvas, listaDatas, listaValores);
    }
}