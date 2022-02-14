using System.Collections.Generic;
using System.Net;

namespace PomeloCase.Core.Model.Base
{
    public class BaseResponse<TData>
    {
        public string Status { get; set; } = "Success";
        public TData Data { get; set; }
        public HttpStatusCode StatusCode;
        public List<ErrorDto> Errors { get; set; }


        public BaseResponse<TData> AddError(ErrorDto er)
        {
            StatusCode = HttpStatusCode.BadRequest;
            this.Status = "Fail";
            if (Errors == null) Errors = new List<ErrorDto>();
            Errors.Add(er);
            return this;
        }
    }

}