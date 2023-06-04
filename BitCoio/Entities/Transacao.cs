namespace BitCoio.Entities
{
    public class Transacao
    {
        public Guid Id { get; set; }

        public Guid CarteiraEnvioId { get; set; }

        public Carteira CarteiraEnvio { get; set; }

        public Guid CarteiraRecebimentoId { get; set; }

        public Carteira CarteiraRecebimento { get; set; }

        public DateTime Data { get; set; }

        public decimal Valor { get; set; }

        public string Descricao { get; set; }


        public Transacao(Guid carteiraEnvioId, Guid carteiraRecebimentoId, decimal valor, string descricao)
        {
            Id = Guid.NewGuid();
            CarteiraEnvioId = carteiraEnvioId;
            CarteiraRecebimentoId = carteiraRecebimentoId;
            Data = DateTime.Now;
            Valor = valor;
            Descricao = descricao;
        }

    }
}
