using System.Collections.Generic;
using System.Linq;

namespace CentralEstatisticas.Util.Enum
{
    public class TipoIndicadorTecnico
    {
        public static readonly TipoIndicadorTecnico LinhasDeCodigo = new TipoIndicadorTecnico(1, "Lines of code");
        public static readonly TipoIndicadorTecnico QtdTestesUnitarios = new TipoIndicadorTecnico(2, "Unit tests");
        public static readonly TipoIndicadorTecnico QtdBugs = new TipoIndicadorTecnico(3, "Bugs");
        public static readonly TipoIndicadorTecnico QtdVulnerabilidades = new TipoIndicadorTecnico(4, "Vulnerabilities");
        public static readonly TipoIndicadorTecnico QtdCodeSmells = new TipoIndicadorTecnico(5, "Code Smells");
        public static readonly TipoIndicadorTecnico CoberturaDeCodigo = new TipoIndicadorTecnico(6, "% Code Coverage");
        public static readonly TipoIndicadorTecnico CodigoDuplicado = new TipoIndicadorTecnico(7, "% Duplications");

        public int Id { get; private set; }
        public string Nome { get; private set; }

        private TipoIndicadorTecnico(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static List<TipoIndicadorTecnico> ListarTodos()
        {
            List<TipoIndicadorTecnico> lista = new List<TipoIndicadorTecnico>();
            lista.Add(LinhasDeCodigo);
            lista.Add(QtdTestesUnitarios);
            lista.Add(QtdBugs);
            lista.Add(QtdVulnerabilidades);
            lista.Add(QtdCodeSmells);
            lista.Add(CoberturaDeCodigo);
            lista.Add(CodigoDuplicado);
            return lista;
        }

        public TipoIndicadorTecnico Obter(int id)
        {
            return ListarTodos().FirstOrDefault(t => t.Id == id);
        }
    }
}
