﻿using CentralEstatisticas.Entidades;
using CentralEstatisticas.Entidades.Dto.IndicadorTecnico;
using CentralEstatisticas.Repositorios.Indicadores;
using CentralEstatisticas.Repositorios.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CentralEstatisticas.Business
{
    public class IndicadoresTecnicosBusiness
    {
        private IndicadoresTecnicosRepositorio Repositorio { get; set; }

        public IndicadoresTecnicosBusiness()
        {
            Repositorio = new IndicadoresTecnicosRepositorio();
        }

        public IndicadoresParaDashboardDto ObterIndicadores(int idSistema)
        {
            return ObterIndicadores(new SistemaRepositorio().ObterSistema(idSistema));
        }

        private IndicadoresParaDashboardDto ObterIndicadores(SistemaEntidade sistema)
        {
            var listaIndicadores = Repositorio.ListarIndicadores(sistema.Id, null);
            var retorno = new IndicadoresParaDashboardDto();
            foreach (var indicador in listaIndicadores)
            {
                if (!retorno.Indicadores.Any(i => i.IdTipo == indicador.IdTipo))
                {
                    retorno.Indicadores.Add(new IndicadorDashboardDto
                    {
                        Tipo = indicador.Tipo,
                        IdTipo = indicador.IdTipo,
                        Valores = new List<IndicadorDashboardDto.ValorIndicador>()
                    });
                }
                var indicadorRetorno = retorno.Indicadores.FirstOrDefault(i => i.IdTipo == indicador.IdTipo);
                indicadorRetorno.Valores.Add(new IndicadorDashboardDto.ValorIndicador { Data = indicador.Data, Valor = indicador.Valor });
            }
            return retorno;
        }

        public IEnumerable<MedicaoIndicadorTecnicoDto> ListarMedicoes(int idSistema)
        {
            return Repositorio.ListarMedicoes(idSistema).Select(m => new MedicaoIndicadorTecnicoDto
            {
                Data = m.Data,
                IdMedicao = m.IdMedicao,
                IdSistema = m.IdSistema
            });
        }

        public MedicaoIndicadorTecnicoDto ObterMedicao(int idMedicao)
        {
            var medicaoEntidade = Repositorio.ObterMedicao(idMedicao);
            MedicaoIndicadorTecnicoDto medicao = new MedicaoIndicadorTecnicoDto
            {
                Data = medicaoEntidade.Data,
                IdMedicao = medicaoEntidade.IdMedicao,
                IdSistema = medicaoEntidade.IdSistema,
                Indicadores = Repositorio.ListarIndicadores(medicaoEntidade.IdSistema, idMedicao).Select(m => new MedicaoIndicadorTecnicoDto.IndicadorMedicaoDto
                {
                    IdTipo = m.IdTipo,
                    Valor = m.Valor
                })
            };
            return medicao;
        }

        public void SalvarMedicao(int? idMedicao, int idSistema, DateTime data, IEnumerable<IndicadorParaSalvarDto> listaIndicadores)
        {
            if (idMedicao.HasValue)
            {
                Repositorio.RemoverIndicadores(idMedicao.Value);
            }
            int idMedicaoSalva = Repositorio.SalvarMedicao(idMedicao, idSistema, data);
            foreach (var indicador in listaIndicadores)
            {
                Repositorio.SalvarIndicador(idMedicaoSalva, indicador.IdTipo, indicador.Valor);
            }
        }

        public void RemoverMedicao(int idMedicao)
        {
            Repositorio.RemoverIndicadores(idMedicao);
            Repositorio.RemoverMedicao(idMedicao);
        }
    }
}
