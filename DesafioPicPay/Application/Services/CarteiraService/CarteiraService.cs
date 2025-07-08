using DesafioPicPay.Application.Request;
using DesafioPicPay.Domain.Models;
using DesafioPicPay.Infrastructure.Repositories.CarteiraRepository;

namespace DesafioPicPay.Application.Services.CarteiraService
{
    public class CarteiraService : ICarteiraService
    {
        private readonly ICarteiraRepository _carteiraRepository;
        public CarteiraService(ICarteiraRepository carteiraRepository)
        {
             _carteiraRepository = carteiraRepository;
        }

        public async Task<Result<bool>> ExecuteAsync(CarteiraRequest request)
        {
            var CarteiraExistente = await _carteiraRepository.GetCpfCnpj(request.CPFCNPJ, request.Email);

            if (CarteiraExistente is not null)
            {
                return Result<bool>.Failure("Carteira já Existe");
            }

            var carteira = new Carteira(
                request.Nome,
                request.Sobrenome,
                request.CPFCNPJ,
                request.Email,
                request.Password,
                request.Tipo
            );

            await _carteiraRepository.Add(carteira);
            await _carteiraRepository.CommitAsync();

            return Result<bool>.Success(true);


        }
    }
}
