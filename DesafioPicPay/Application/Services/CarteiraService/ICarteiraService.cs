using DesafioPicPay.Application.Request;
using DesafioPicPay.Domain.Models;

namespace DesafioPicPay.Application.Services.CarteiraService
{
    public interface ICarteiraService
    {
        Task<Result<bool>> ExecuteAsync(CarteiraRequest request);
    }
}
