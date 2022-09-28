namespace Finansist.Domain.Commands.Result
{
    public class GenericCommandResult
    {

        public GenericCommandResult(bool sucess, string message)
        {
            this.Sucess = sucess;
            this.Message = message;

        }

        public GenericCommandResult(bool sucess, string message, object data)
        {
            this.Sucess = sucess;
            this.Message = message;
            this.Data = data;
        }
        public bool Sucess { get; set; }

        public String Message { get; set; } = null!;

        public object? Data { get; set; }

    }
}