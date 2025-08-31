using Common.Enums;

namespace Common.DTOs
{
    public class ApiResponse
    {
        public bool Success => Code == ResponseCode.OK;
        public ResponseCode Code { get; set; }
        public string? Message { get; set; }
        public dynamic? Data { get; set; }

        public static ApiResponse OK(dynamic? Data)
        {
            return new ApiResponse { Code = ResponseCode.OK, Data = Data };
        }
        public static ApiResponse BadRequest(string? message)
        {
            return new ApiResponse { Code = ResponseCode.BadRequest, Message = message };
        }
        public static ApiResponse Unauthorized(string? message)
        {
            return new ApiResponse { Code = ResponseCode.Unauthorized, Message = message };
        }
    }
    public class ApiPagingResponse : ApiResponse
    {
        public bool HasMoreData { get; set; }

        public static ApiPagingResponse OK(dynamic? Data, bool hasMoreData)
        {
            return new ApiPagingResponse { Code = ResponseCode.OK, Data = Data, HasMoreData = hasMoreData };
        }
    }
}