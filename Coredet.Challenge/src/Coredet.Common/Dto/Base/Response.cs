using System.Collections.Generic;

namespace Coredet.Shared.Dto.Base
{
    public class Response<T>
    {
        public string Status { get; set; } = "Success";
        public int StatusCode { get; set; } = 200;
        public T Data { get; set; }
        public List<string> Error { get; set; }

        public Response<T> AddError(string errortext,int statuscode = 400)
        {
            Error ??= new List<string>();
            Status = "Fail";
            StatusCode = statuscode;
            Error.Add(errortext);
            return this;
        }
    }
}