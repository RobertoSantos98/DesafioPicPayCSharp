using DesafioPicPay.Application.Mappers;
using DesafioPicPay.Application.Request;
using DesafioPicPay.Domain.DTOs;
using DesafioPicPay.Domain.Models;
using DesafioPicPay.Domain.Types;
using DesafioPicPay.Infrastructure.Repositories.CarteiraRepository;
using DesafioPicPay.Infrastructure.Repositories.Transacao;

namespace DesafioPicPay.Application.Services.TransacaoService
{
    public class TransacaoService : ITrasacaoService
    {
        private readonly ITrasacaoRepository _transacaoRepository;
        private readonly ICarteiraRepository _carteiraRepository;

        public TransacaoService(ITrasacaoRepository transacaoRepository, ICarteiraRepository carteiraRepository )
        {
            _transacaoRepository = transacaoRepository;
            _carteiraRepository = carteiraRepository;
        }

        public async Task<Result<TransacaoDTO>> Execute(TransacaoRequest request)
        {
            var pagador = await _carteiraRepository.GetById(request.IdPagador);
            var recebedor = await _carteiraRepository.GetById(request.IdRecebedor);

            if(pagador == null || recebedor == null)
            {
                return Result<TransacaoDTO>.Failure("Carteira não encontrada.");
            }

            if(pagador.Saldo < request.Valor)
            {
                return Result<TransacaoDTO>.Failure("Saldo insuficiente para realizar a transação.");
            }

            if(pagador.Tipo == UserType.Logista)
            {
                return Result<TransacaoDTO>.Failure("Logistas não podem realizar transações.");
            }

            pagador.Debitar(request.Valor);
            recebedor.Creditar(request.Valor);

            var transferencia = new Transferencia(request.IdPagador, request.IdRecebedor, request.Valor, true);

            using (var transacao = await _transacaoRepository.ComecarTransacao())
            {
                try
                {
                    var listaDeTarefas = new List<Task>
                    {
                        _carteiraRepository.Update(pagador),
                        _carteiraRepository.Update(recebedor),
                        _transacaoRepository.AddTransacao(transferencia),
                    };

                    await Task.WhenAll(listaDeTarefas);

                    await _carteiraRepository.CommitAsync();
                    await _transacaoRepository.CommitChanges();

                    await transacao.CommitAsync();


                }
                catch (Exception ex)
                {
                    await transacao.RollbackAsync();
                    return Result<TransacaoDTO>.Failure("Erro ao processar Transação: " + ex.Message);
                }

            }  
            
            return Result<TransacaoDTO>.Success(transferencia.ToMapTransacaoDTO());


        }
    }
}
