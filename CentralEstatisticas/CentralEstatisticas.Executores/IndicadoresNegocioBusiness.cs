using CentralEstatisticas.Entidades;
using CentralEstatisticas.Repositorios;
using CentralEstatisticas.Repositorios.Indicadores;
using CentralEstatisticas.Util.Enum;
using System;
using System.Collections.Generic;
using System.Configuration;
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
                lista.Add(ObterIndicador(dataInicio, dataFim, sistema));
            }
            return lista;
        }

        public IndicadoresSistemaEntidade ObterIndicador(DateTime dataInicio, DateTime dataFim, int idSistema)
        {
            return ObterIndicador(dataInicio, dataFim, new SistemaRepositorio().ObterSistema(idSistema));
        }

        public IndicadoresSistemaEntidade ObterIndicador(DateTime dataInicio, DateTime dataFim, SistemaEntidade sistema)
        {
            IndicadoresSistemaEntidade registro = new IndicadoresSistemaEntidade { Sistema = sistema };
            try
            {
                var resultado = new ApiIndicadoresRepositorio(ObterUrlAmbiente(sistema), sistema.RotaApiIndicadores).Executar(dataInicio, dataFim);
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
