function carregarAbaIndicadoresTecnicos(indicadoresTecnicos) {
    $('#tab-tecnico').empty();
    for (var i = 0; i < indicadoresTecnicos.Indicadores.length; i++) {
        var indicadorIteracao = indicadoresTecnicos.Indicadores[i];
        var listaDatas = [];
        var listaValores = [];
        for (var j = 0; j < indicadorIteracao.Valores.length; j++) {
            var valorIteracao = indicadorIteracao.Valores[j];
            listaDatas.push(valorIteracao.DataString);
            listaValores.push(valorIteracao.Valor);
        }
        var componenteIndicador = $('.template-indicador .indicador').clone();
        componenteIndicador.find('[data-nome-indicador]').text(indicadorIteracao.Tipo);
        var idCanvas = 'grafico-indicador-' + indicadorIteracao.IdTipo;
        componenteIndicador.find('[data-canvas-grafico]').attr('id', idCanvas);
        $('#tab-tecnico').append(componenteIndicador);
        montarGrafico(idCanvas, listaDatas, listaValores);
    }
}