using CentralEstatisticas.Entidades;
using CentralEstatisticas.Repositorios;
using CentralEstatisticas.Repositorios.Indicadores;
using CentralEstatisticas.Util.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CentralEstatisticas.Business
{
    public class IndicadoresNegocioBusiness
    {
        public List<IndicadoresSistemaEntidade> ListarIndicadores(DateTime dataInicio, DateTime dataFim)
        {
            var lista = new List<IndicadoresSistemaEntidade>();
            var listaSistemas = new SistemaRepositorio().ListarTodos();
            foreach (var sistema in listaSistemas)
            {
                IndicadoresSistemaEntidade registro = new IndicadoresSistemaEntidade { Sistema = sistema };
                try
                {
                    var resultado = new ApiIndicadoresRepositorio(sistema.UrlBase, sistema.RotaApiIndicadores).Executar(dataInicio, dataFim);
                    if (resultado.Sucesso)
                    {
                        registro.ListaIndicadores = resultado.Indicadores.Select(i => new IndicadorEntidade
                        {
                            Nome = i.Nome,
                            Valor = i.Valor
                        }).ToList();
                    }
                    else
                    {
                        registro.TipoErro = TipoErro.Tratado;
                        registro.MensagemErro = resultado.MensagemErro;
                    }
                }
                catch (Exception e)
                {
                    registro.TipoErro = TipoErro.Tratado;
                    registro.MensagemErro = e.Message;
                }
                lista.Add(registro);
            }
            return lista;
        }
    }
}
