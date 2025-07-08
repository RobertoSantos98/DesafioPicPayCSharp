using DesafioPicPay.Domain.DTOs;
using DesafioPicPay.Domain.Models;

namespace DesafioPicPay.Application.Mappers
{
    public static class TransferenciaMapper
    {
        public static TransacaoDTO ToMapTransacaoDTO(this Transferencia transacao)
        {
            return new TransacaoDTO(
                    transacao.Id,
                    transacao.Pagador,
                    transacao.Recebedor,
                    transacao.Valor
                );
        }
        
    }
}
