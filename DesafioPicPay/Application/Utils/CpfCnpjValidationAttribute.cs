using System.ComponentModel.DataAnnotations;

namespace DesafioPicPay.Application.Utils
{
    public class CpfCnpjValidationAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var cpfCnpj = value as string;

            if (string.IsNullOrEmpty(cpfCnpj))
            {
                return new ValidationResult(ErrorMessage ?? "O CPF ou CNPJ é obrigatório.");
            }

            return ValidationResult.Success;

        }

    }
}
