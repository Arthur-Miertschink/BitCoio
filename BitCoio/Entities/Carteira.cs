namespace BitCoio.Entities
{
    public class Carteira
    {
        public Guid Id { get; set; }

        public string NomeCarteira { get; set; }

        public decimal Valor { get; set; }

        public Carteira(string nomeCarteira)
        {
            Id = Guid.NewGuid();
            NomeCarteira = nomeCarteira;
            Valor = 0;
        }

    }
}