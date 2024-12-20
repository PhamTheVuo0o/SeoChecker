using ASW.SM.Infrastructure.Enums;

namespace ASW.SM.Infrastructure.Models
{
    public class BaseResponse<T>
    {
        public BaseResponse(T data, bool isSuccess = false, string errorMessage = "", string? detail = "", ErrorTypeEnum errorType = ErrorTypeEnum.NONE)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            Detail = detail;
            ErrorType = errorType;
            Data = data;
        }        
        public bool IsSuccess {  get; set; }
        public string ErrorMessage { get; set; }
        public ErrorTypeEnum ErrorType { get; set; }
        public string? Detail { get; set; }
        public T? Data { get; set; }
    }
}