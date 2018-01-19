namespace CentralEstatisticas.Entidades
{
    public class SistemaEntidade
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string Area { get; set; }
        public string Nome { get; set; }
        public string UrlBase { get; set; }
        public string RotaApiIndicadores { get; set; }
        public string UrlBaseHom { get; set; }
        public string UrlBaseDev { get; set; }
        public bool Ativo { get; set; }
    }
}
