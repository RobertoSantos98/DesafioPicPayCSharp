using DesafioPicPay.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioPicPay.Infrastructure.Repositories.CarteiraRepository
{
    public class CarteiraRepository : ICarteiraRepository
    {
        private readonly DbConnection _context;

        public CarteiraRepository(DbConnection context)
        {
            _context = context;
        }

        public async Task Add(Carteira carteira)
        {
            await _context.AddAsync(carteira);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Carteira> GetById(int id)
        {
            return await _context.Carteira.FindAsync(id);
        }

        public async Task<Carteira> GetCpfCnpj(string document, string email)
        {
            return await _context.Carteira.FirstOrDefaultAsync(c => c.CpfCnpj == document || c.Email == email);
        }

        public async Task Update(Carteira carteira)
        {
            _context.Update(carteira);
        }
    }
}
