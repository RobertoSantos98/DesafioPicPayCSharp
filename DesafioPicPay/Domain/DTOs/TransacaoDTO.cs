using DesafioPicPay.Domain.Models;

namespace DesafioPicPay.Domain.DTOs
{
    public record TransacaoDTO(int idTransacao, Carteira Pagador, Carteira Recebedor, decimal ValorTransferido);
}
