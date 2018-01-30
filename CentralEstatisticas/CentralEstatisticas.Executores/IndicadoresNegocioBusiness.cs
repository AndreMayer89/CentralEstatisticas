using CentralEstatisticas.Entidades;
using CentralEstatisticas.Entidades.Dto.IndicadorNegocio;
using CentralEstatisticas.Repositorios.Indicadores;
using CentralEstatisticas.Repositorios.Sistema;
using CentralEstatisticas.Util.Enum;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace CentralEstatisticas.Business
{
    public class IndicadoresNegocioBusiness
    {
        private IndicadoresNegocioRepositorio Repositorio { get; set; }

        public IndicadoresNegocioBusiness()
        {
            Repositorio = new IndicadoresNegocioRepositorio();
        }

        public IndicadoresParaDashboardDto ObterIndicadores(int idSistema)
        {
            var listaIndicadores = Repositorio.ListarIndicadores(idSistema);
            var retorno = new IndicadoresParaDashboardDto();
            foreach (var indicador in listaIndicadores)
            {
                if (!retorno.Indicadores.Any(i => i.Nome == indicador.Nome))
                {
                    retorno.Indicadores.Add(new IndicadorDashboardDto
                    {
                        Nome = indicador.Nome,
                        Valores = new List<IndicadorDashboardDto.ValorIndicador>()
                    });
                }
                var indicadorRetorno = retorno.Indicadores.FirstOrDefault(i => i.Nome == indicador.Nome);
                indicadorRetorno.Valores.Add(new IndicadorDashboardDto.ValorIndicador
                {
                    DataInicio = indicador.DataInicio,
                    DataFim = indicador.DataFim,
                    Valor = indicador.Valor
                });
            }
            return retorno;
        }

        public IEnumerable<MedicaoIndicadorNegocioDto> ListarMedicoes(int idSistema)
        {
            return Repositorio.ListarMedicoes(idSistema).Select(m => new MedicaoIndicadorNegocioDto
            {
                DataFim = m.DataFim,
                DataInicio = m.DataInicio,
                IdMedicao = m.IdMedicao,
                IdSistema = m.IdSistema
            });
        }

        public void Salvar(int? idMedicao, int idSistema, DateTime dataInicio, DateTime dataFim, IEnumerable<IndicadorParaSalvarDto> listaIndicadores)
        {
            if (idMedicao.HasValue)
            {
                Repositorio.RemoverIndicadores(idMedicao.Value);
            }
            int idMedicaoSalva = Repositorio.SalvarMedicao(idMedicao, idSistema, dataInicio, dataFim);
            foreach (var indicador in listaIndicadores)
            {
                Repositorio.SalvarIndicador(idMedicaoSalva, indicador.Nome, indicador.Valor);
            }
        }

        public void RemoverMedicao(int idMedicao)
        {
            Repositorio.RemoverIndicadores(idMedicao);
            Repositorio.RemoverMedicao(idMedicao);
        }

        #region Consulta APIs

        public IndicadorNegocioNaDataEntidade ObterIndicadoresNoPeriodo(DateTime dataInicio, DateTime dataFim, int idSistema)
        {
            return ObterIndicadoresNoPeriodoPelaApi(dataInicio, dataFim, new SistemaRepositorio().ObterSistema(idSistema));
        }

        public IndicadorNegocioNaDataEntidade ObterIndicadoresNoPeriodoPelaApi(DateTime dataInicio, DateTime dataFim, SistemaEntidade sistema)
        {
            IndicadorNegocioNaDataEntidade registro = new IndicadorNegocioNaDataEntidade { Sistema = sistema };
            try
            {
                var resultado = new IndicadoresNegocioApiRepositorio(ObterUrlAmbiente(sistema), sistema.RotaApiIndicadores).Executar(dataInicio, dataFim);
                if (resultado.Sucesso)
                {
                    registro.ListaIndicadores = resultado.Indicadores.Select(i => new IndicadorNegocioNaDataEntidade.IndicadorEntidade
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
                var excecaoMaisInterna = e;
                while (excecaoMaisInterna.InnerException != null)
                {
                    excecaoMaisInterna = excecaoMaisInterna.InnerException;
                }
                registro.MensagemErro = excecaoMaisInterna.Message;
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

        #endregion
    }
}
