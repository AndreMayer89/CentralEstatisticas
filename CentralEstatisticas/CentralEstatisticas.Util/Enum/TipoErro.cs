using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralEstatisticas.Util.Enum
{
    public class TipoErro
    {
        public static readonly TipoErro Tratado = new TipoErro(1, "Tratado");
        public static readonly TipoErro NaoTratado = new TipoErro(2, "Não tratado");

        public int Id { get; private set; }
        public string Nome { get; private set; }

        private TipoErro(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static List<TipoErro> ListarTodos()
        {
            List<TipoErro> lista = new List<TipoErro>();
            lista.Add(Tratado);
            lista.Add(NaoTratado);
            return lista;
        }

        public TipoErro Obter(int id)
        {
            return ListarTodos().FirstOrDefault(t => t.Id == id);
        }
    }
}
