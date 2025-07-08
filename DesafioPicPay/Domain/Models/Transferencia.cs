namespace DesafioPicPay.Domain.Models
{
    public class Transferencia
    {
        public int Id { get; private set; }
        public int IdPagador { get; private set; }
        public Carteira Pagador { get; set; }
        public int IdRecebedor { get; private set; }
        public Carteira Recebedor { get; set; }
        public decimal Valor { get; private set; }
        public DateTime DataTransferencia { get; private set; } = DateTime.Now;
        public bool Aprovada { get; private set; }

        public Transferencia( int idPagador, int idRecebedor, decimal valor, bool aprovada)
        {
            IdPagador = idPagador;
            IdRecebedor = idRecebedor;
            Valor = valor;
            DataTransferencia = DateTime.Now;
            Aprovada = aprovada;
        }

        public Transferencia() { }
    }
}
