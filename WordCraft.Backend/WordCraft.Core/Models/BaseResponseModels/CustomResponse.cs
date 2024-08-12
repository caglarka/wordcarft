using System.Net;
using WordCraft.Core.Keys;

namespace WordCraft.Core.Models.BaseResponseModels
{
    public class CustomResponse<T>
    {
        public T? Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public List<string>? Errors { get; set; }

        public static CustomResponse<T> Success(HttpStatusCode statusCode, T data)
        {
            return new CustomResponse<T> { Data = data, StatusCode = statusCode };
        }

        public static CustomResponse<T> Fail(HttpStatusCode statusCode, List<string> errors)
        {
            return new CustomResponse<T> { StatusCode = statusCode, Errors = EditErrors(errors) };
        }

        public static CustomResponse<T> Fail(HttpStatusCode statusCode, string error)
        {
            return new CustomResponse<T> { StatusCode = statusCode, Errors = [EditError(error)] };
        }

        public static CustomResponse<T> Fail(HttpStatusCode statusCode, string error, T data)
        {
            return new CustomResponse<T> { StatusCode = statusCode, Errors = [EditError(error)], Data = data };
        }

        private static string EditError(string error) => $"{ErrorMessageKey.ErrorAliases}{error.Trim()}";

        private static List<string> EditErrors(List<string> errors)
        {
            return errors.Select(err => $"{ErrorMessageKey.ErrorAliases}{err.Trim()}").ToList();
        }
    }
}
