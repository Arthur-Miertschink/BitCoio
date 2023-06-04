namespace BitCoio.Handlers.ListarTransacoesCarteira
{
    public class ListarTransacoesCarteiraResponse
    {
        public Guid CarteiraEnvioId { get; set; }

        public Guid CarteiraRecebimentoId { get; set; }

        public string Valor { get; set; }

        public DateTime Data { get; set; }

        public string Descricao { get; set; }



    }
}
