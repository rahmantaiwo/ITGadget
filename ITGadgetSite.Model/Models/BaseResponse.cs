namespace ITGadgetSite.Model.Models
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int StatusCode { get; set; }

        // ---------------------------
        // Factory Helpers
        // ---------------------------

        public static BaseResponse<T> SuccessResponse(T data, string message = "Success", int statusCode = 200)
        {
            return new BaseResponse<T>
            {
                Success = true,
                Message = message,
                Data = data,
                StatusCode = statusCode
            };
        }

        public static BaseResponse<T> FailureResponse(string message, int statusCode = 400)
        {
            return new BaseResponse<T>
            {
                Success = false,
                Message = message,
                Data = default,
                StatusCode = statusCode
            };
        }

        public static BaseResponse<T> NotFound(string message = "Not Found")
        {
            return FailureResponse(message, 404);
        }

        public static BaseResponse<T> Unauthorized(string message = "Unauthorized")
        {
            return FailureResponse(message, 401);
        }
    }
}
