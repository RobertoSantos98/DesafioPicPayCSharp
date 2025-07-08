namespace DesafioPicPay.Domain.Models
{
    public class Result<T>
    {
        public Result(bool success, string errorMessage, T dados)
        {
            IsSuccess = success;
            ErrorMessage = errorMessage;
            Dados = dados;
        }

        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public T Dados { get; set; }

        private Result(bool suc)
        {
            IsSuccess = suc;
        }

        public static Result<T> Success(T dados) =>
            new Result<T>(true, null!, dados);

        public static Result<T> Failure(string errorMessage) =>
            new Result<T>(false, errorMessage, default!);
    }
}
