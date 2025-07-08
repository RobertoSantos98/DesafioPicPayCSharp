using DesafioPicPay.Domain.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace DesafioPicPay.Infrastructure.Repositories.Transacao
{
    public interface ITrasacaoRepository
    {
        Task AddTransacao(Transferencia transferencia);
        Task<IDbContextTransaction> ComecarTransacao();
        Task CommitChanges();
    }
}
