using DesafioPicPay.Application.Utils;
using DesafioPicPay.Domain.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioPicPay.Application.Request
{
    public class CarteiraRequest
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O CPF ou CNPJ é obrigatório.")]
        [CpfCnpjValidation(ErrorMessage = "O CPF informado não é valido.")]
        public string CPFCNPJ { get; set; }

        [Required(ErrorMessage = "O Email é origatório.")]
        [EmailAddress(ErrorMessage = "O Email informado é inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O tipo de usuário é obrigatório.")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserType Tipo { get; set; }
    }
}
