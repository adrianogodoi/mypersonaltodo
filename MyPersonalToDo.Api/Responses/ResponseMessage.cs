namespace MyPersonalToDo.Api.Responses
{
    public class ResponseMessage
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Error { get; set; } = string.Empty;
        public object Data { get; set; }

        public static ResponseMessage ShowMessage(string mensagem)
        {
            return new ResponseMessage { Success = true, Message = mensagem};
        }

        public static ResponseMessage ShowMessage(object data, string mensagem)
        {
            return new ResponseMessage { Success = true, Message = mensagem, Data = data };
        }

        public static ResponseMessage ShowErrors(string mensagem, string error)
        {
            return new ResponseMessage { Success = false, Message = mensagem, Error = error };
        }
    }
}
