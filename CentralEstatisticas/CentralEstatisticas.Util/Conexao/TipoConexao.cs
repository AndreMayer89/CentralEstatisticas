namespace CentralEstatisticas.Util.Conexao
{
    public class TipoConexao
    {
        public static readonly TipoConexao DbCentral = new TipoConexao(1, "DbCentral");

        public int Id { get; private set; }
        public string Nome { get; private set; }

        private TipoConexao(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
