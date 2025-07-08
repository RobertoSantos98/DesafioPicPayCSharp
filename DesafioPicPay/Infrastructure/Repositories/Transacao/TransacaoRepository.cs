
using DesafioPicPay.Domain.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace DesafioPicPay.Infrastructure.Repositories.Transacao
{
    public class TransacaoRepository : ITrasacaoRepository
    {
        private readonly DbConnection _context;

        public TransacaoRepository(DbConnection context)
        {
            _context = context;
        }

        public async Task AddTransacao(Transferencia transferencia)
        {
            await _context.Transferencia.AddAsync(transferencia);
        }

        public async Task<IDbContextTransaction> ComecarTransacao()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
