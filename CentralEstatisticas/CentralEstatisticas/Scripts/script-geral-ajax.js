$.ajaxSetup({
    cache: false
});

function chamadaAjaxGet(url, parametros, callbackSucesso, callbackErro, async, exibirCarregando) {
    chamadaAjax('GET', url, parametros, callbackSucesso, callbackErro, async, exibirCarregando);
}

function chamadaAjaxPost(url, parametros, callbackSucesso, callbackErro, async, exibirCarregando) {
    chamadaAjax('POST', url, parametros, callbackSucesso, callbackErro, async, exibirCarregando);
}

function chamadaAjax(tipo, url, parametros, callbackSucesso, callbackErro, async, exibirCarregando) {
    $.ajax({
        type: tipo,
        url: url,
        data: parametros,
        cache: false,
        async: async == null || async,
        beforeSend: function () {
            if (exibirCarregando) {
                bloquearPagina();
            }
        },
        complete: function () {
            if (exibirCarregando) {
                desbloquearPagina();
            }
        },
        success: function (args) {
            processarSucessoChamadaAjax(args, callbackSucesso, callbackErro);
        },
        error: function () {
            if (exibirCarregando) {
                desbloquearPagina();
            }
            notificacaoErro('Ocorreu um erro interno.');
        }
    });
}

function chamadaAjaxPostParaValorDecimal(url, parametros, callbackSucesso, callbackErro, async, exibirCarregando) {
    $.ajax({
        type: 'POST',
        url: url,
        data: parametros,
        cache: false,
        contentType: "application/json; charset=utf-8",
        async: async == null || async,
        beforeSend: function () {
            if (exibirCarregando) {
                bloquearPagina();
            }
        },
        complete: function () {
            if (exibirCarregando) {
                desbloquearPagina();
            }
        },
        success: function (args) {
            processarSucessoChamadaAjax(args, callbackSucesso, callbackErro);
        },
        error: function () {
            if (exibirCarregando) {
                desbloquearPagina();
            }
            notificacaoErro('Ocorreu um erro interno.');
        }
    });
}

function processarSucessoChamadaAjax(args, callbackSucesso, callbackErro) {
    if (args.sucesso != undefined && args.sucesso != null && !args.sucesso) {
        if (args.mensagem != undefined && args.mensagem != null) {
            notificacaoErro(args.mensagem);
            if (callbackErro != null) {
                callbackErro();
            }
        }
        else {
            notificacaoErro('Ocorreu um erro interno.');
        }
    }
    else {
        callbackSucesso(args);
    }
}