using System.ComponentModel.DataAnnotations;

namespace DesafioPicPay.Application.Request
{
    public class TransacaoRequest
    {
        [Required(ErrorMessage = "O Valor é obrigatório.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O id do Pagador é obrigatório.")]
        public int IdPagador { get; set; }

        [Required(ErrorMessage = "O id do Recebedor é obrigatório.")]
        public int IdRecebedor { get; set; }
    }
}
