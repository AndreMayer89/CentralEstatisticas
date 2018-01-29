using System.Collections.Generic;

namespace CentralEstatisticas.Models
{
    public class HomeModel
    {
        public List<Empresa> Empresas { get; set; }

        public class Empresa
        {
            public List<AreaEmpresa> Areas { get; set; }
            public string Nome { get; set; }

            public Empresa()
            {
                Areas = new List<AreaEmpresa>();
            }
        }

        public class AreaEmpresa
        {
            public List<Sistema> Sistemas { get; set; }
            public string Nome { get; set; }

            public AreaEmpresa()
            {
                Sistemas = new List<Sistema>();
            }
        }

        public class Sistema
        {
            public int Id { get; set; }
            public string Nome { get; set; }
        }

        public HomeModel()
        {
            Empresas = new List<Empresa>();
        }
    }
}