using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tesodev.Case.Shared.Dtos
{
    public class Response<T> where T : new()
    {
        public Response()
        {
            Data = new T();
        }
        [JsonPropertyName("data")]
        public T Data { get; set; }

        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }

        [JsonPropertyName("errors")]
        public List<string> Errors { get; set; }

        public Response<T> Success(T data)
        {
            Data = data;
            StatusCode = 200;
            IsSuccessful = true;
            return this;   
        }

        public  Response<T> AddError(string error, int statusCode = 400)
        {
            this.IsSuccessful = false;
            this.StatusCode = statusCode;
            Errors = Errors ?? new List<string>();
            Errors.Add(error);
            return this;
        }
    }
}