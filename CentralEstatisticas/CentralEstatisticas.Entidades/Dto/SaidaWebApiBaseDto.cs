namespace CentralEstatisticas.Entidades.Dto
{
    public class SaidaWebApiBaseDto
    {
        public bool Sucesso { get; set; }
        public string MensagemErro { get; set; }

        public SaidaWebApiBaseDto()
        {
            Sucesso = true;
        }
    }
}
