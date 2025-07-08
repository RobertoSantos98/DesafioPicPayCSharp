using DesafioPicPay.Domain.Types;

namespace DesafioPicPay.Domain.Models
{
    public class Carteira
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string CpfCnpj { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public decimal Saldo { get; private set; }
        public UserType Tipo { get; private set; }

        public Carteira(string nome, string sobrenome, string cpfCnpj, string email, string password, decimal saldo, UserType tipo)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            CpfCnpj = cpfCnpj;
            Email = email;
            Password = password;
            Saldo = saldo;
            Tipo = tipo;
        }

        public Carteira(string nome, string sobrenome, string cpfCnpj, string email, string password, UserType tipo)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            CpfCnpj = cpfCnpj;
            Email = email;
            Password = password;
            Saldo = 0; // Inicializa o saldo como zero
            Tipo = tipo;
        }

        public Carteira() { }

        public void Creditar(decimal valor)
        {
            if(valor <= 0)
            {
                throw new ArgumentException("Valor deve ser maior do que zero.", nameof(valor));
            }

            Saldo += valor;
        }

        public void Debitar(decimal valor)
        {
            if(valor <= 0)
            {
                throw new ArgumentException("Valor deve ser maior do que zero.", nameof(valor));
            }

            if(Saldo< valor)
            {
                throw new InvalidOperationException("Salvo insuficiente para realizar esta operação.");
            }

            Saldo -= valor;
        }

    }
}
