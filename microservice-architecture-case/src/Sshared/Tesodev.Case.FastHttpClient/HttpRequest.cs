using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using RestSharp;
using Tesodev.Case.FastHttpClient.Enums;

namespace Tesodev.Case.FastHttpClient
{
    public class HttpRequest
    {
        private IRestRequest request;
        private Lazy<RestClient> client;

        public HttpRequest(string url)
        {
            request = new RestRequest(url, DataFormat.Json);
            client = new Lazy<RestClient>();
        }

        public HttpRequest AddHeader(string key, string value)
        {
            request.AddHeader(key, value);
            return this;
        }

        public HttpRequest SetDataFormat(HttpDataFormatTypes format)
        {
            switch (format)
            {
                case HttpDataFormatTypes.Json:
                    request.RequestFormat = DataFormat.Json;
                    request.AddHeader("Content-Type", "application/json");
                    break;
                case HttpDataFormatTypes.Xml:
                    request.RequestFormat = DataFormat.Xml;
                    break;
                default:
                    request.RequestFormat = DataFormat.Json;
                    break;
            }

            return this;
        }

        public HttpRequest AddBody(object body)
        {
            request.AddJsonBody(body);
            return this;
        }

        public HttpRequest SetHttpMethod(HttpMethodTypes method)
        {
            switch (method)
            {
                case HttpMethodTypes.GET:
                    request.Method = Method.GET;
                    break;
                case HttpMethodTypes.POST:
                    request.Method = Method.POST;
                    break;
                default:
                    request.Method = Method.GET;
                    break;
            }

            return this;
        }

        public TEntity Execute<TEntity>() where TEntity : class, new()
        {
            var response = client.Value.Execute(request);
            TEntity body = new TEntity();
            switch (request.RequestFormat)
            {
                case DataFormat.Json:
                    body = JsonSerializer.Deserialize<TEntity>(response.Content);
                    break;
                case DataFormat.Xml:
                    XmlSerializer serializer = new XmlSerializer(typeof(TEntity));
                    StringReader SR = new StringReader(response.Content);
                    XmlReader XR = new XmlTextReader(SR);
                    if (serializer.CanDeserialize(XR))
                        body = serializer.Deserialize(XR) as TEntity;
                    break;
                default:
                    break;
            }

            return body;
        }

        public virtual async Task<TEntity> ExecuteAsync<TEntity>() where TEntity : class, new()
        {
            var response = await client.Value.ExecuteAsync(request);
            if (!string.IsNullOrEmpty(response.Content))
            {
                TEntity body = new TEntity();
                switch (request.RequestFormat)
                {
                    case DataFormat.Json:
                        body = JsonSerializer.Deserialize<TEntity>(response.Content);
                        break;
                    case DataFormat.Xml:

                        XmlSerializer serializer = new XmlSerializer(typeof(TEntity));
                        StringReader SR = new StringReader(response.Content);
                        XmlReader XR = new XmlTextReader(SR);
                        if (serializer.CanDeserialize(XR))
                            body = (TEntity)serializer.Deserialize(XR);
                        break;
                    default:
                        break;
                }
                return body;
            }

            return null;

        }
    }
}