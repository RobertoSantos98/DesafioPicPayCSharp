using DesafioPicPay.Domain.Models;

namespace DesafioPicPay.Infrastructure.Repositories.CarteiraRepository
{
    public interface ICarteiraRepository
    {
        Task Add(Carteira carteira);
        Task Update(Carteira carteira);
        Task<Carteira> GetCpfCnpj(string document, string email);
        Task<Carteira> GetById(int id);
        Task CommitAsync();

    }
}
