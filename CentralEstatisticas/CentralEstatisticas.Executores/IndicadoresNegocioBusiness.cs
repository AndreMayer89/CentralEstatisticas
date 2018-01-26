using CentralEstatisticas.Entidades;
using CentralEstatisticas.Repositorios.Indicadores;
using CentralEstatisticas.Repositorios.Sistema;
using CentralEstatisticas.Util.Enum;
using System;
using System.Configuration;
using System.Linq;

namespace CentralEstatisticas.Business
{
    public class IndicadoresNegocioBusiness
    {
        public IndicadoresSistemaEntidade ObterIndicadoresNoPeriodo(DateTime dataInicio, DateTime dataFim, int idSistema)
        {
            return ObterIndicadoresNoPeriodo(dataInicio, dataFim, new SistemaRepositorio().ObterSistema(idSistema));
        }

        public IndicadoresSistemaEntidade ObterIndicadoresNoPeriodo(DateTime dataInicio, DateTime dataFim, SistemaEntidade sistema)
        {
            IndicadoresSistemaEntidade registro = new IndicadoresSistemaEntidade { Sistema = sistema };
            try
            {
                var resultado = new IndicadoresNegocioRepositorio(ObterUrlAmbiente(sistema), sistema.RotaApiIndicadores).Executar(dataInicio, dataFim);
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
                registro.TipoErro = TipoErro.NaoTratado;
                registro.MensagemErro = e.Message;
            }
            return registro;
        }

        private string ObterUrlAmbiente(SistemaEntidade sistema)
        {
            //TODO [André] - Refactoring
            string ambiente = ConfigurationManager.AppSettings["Ambiente"];
            if (ambiente == "DESENVOLVIMENTO")
            {
                return sistema.UrlBaseDev;
            }
            if (ambiente == "HOMOLOGACAO")
            {
                return sistema.UrlBaseHom;
            }
            return sistema.UrlBase;
        }
    }
}
