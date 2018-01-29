using CentralEstatisticas.Entidades;
using CentralEstatisticas.Entidades.Dto.Sistema;
using CentralEstatisticas.Repositorios.Sistema;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CentralEstatisticas.Business
{
    public class SistemaBusiness
    {
        public IEnumerable<EmpresaDto> ListarSistemasAgrupadosPorEmpresaEArea()
        {
            IEnumerable<SistemaEntidade> listaSistemas = new SistemaRepositorio().ListarTodos();
            List<EmpresaDto> listaRetorno = new List<EmpresaDto>();
            foreach (var sistema in listaSistemas)
            {
                if (!listaRetorno.Any(e => e.Nome == sistema.Empresa))
                {
                    listaRetorno.Add(new EmpresaDto { Nome = sistema.Empresa, ListaAreas = new List<AreaDto>() });
                }
                var empresa = listaRetorno.First(e => e.Nome == sistema.Empresa);
                if (!empresa.ListaAreas.Any(a => a.Nome == sistema.Area))
                {
                    empresa.ListaAreas.Add(new AreaDto { Nome = sistema.Area, ListaSistemas = new List<SistemaDto>() });
                }
                var area = empresa.ListaAreas.First(a => a.Nome == sistema.Area);
                area.ListaSistemas.Add(new SistemaDto { Id = sistema.Id, Nome = sistema.Nome });
            }
            return listaRetorno;
        }

        public SistemaEntidade ObterSistema(int idSistema)
        {
            return new SistemaRepositorio().ObterSistema(idSistema);
        }
    }
}
