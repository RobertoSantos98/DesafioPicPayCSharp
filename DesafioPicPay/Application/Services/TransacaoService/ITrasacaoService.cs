using DesafioPicPay.Application.Request;
using DesafioPicPay.Domain.DTOs;
using DesafioPicPay.Domain.Models;

namespace DesafioPicPay.Application.Services.TransacaoService
{
    public interface ITrasacaoService
    {
        Task<Result<TransacaoDTO>> Execute(TransacaoRequest request);
    }
}
