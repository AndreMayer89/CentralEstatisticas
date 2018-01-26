using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentralEstatisticas.Models
{
    public class HomeModel
    {
        public IEnumerable<Empresa> Empresas { get; set; }

        public class Empresa
        {
            public IEnumerable<AreaEmpresa> Areas { get; set; }
            public string Nome { get; set; }
        }

        public class AreaEmpresa
        {
            public IEnumerable<Sistema> Sistemas { get; set; }
            public string Nome { get; set; }
        }

        public class Sistema
        {
            public int Id { get; set; }
            public string Nome { get; set; }
        }
    }
}