

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
/// <summary>
/// Builder pattern is used to separate the construction process from the respresentation where multiple different representations can be created 
/// by using some or all of building methods of the same construction process
/// Four components of the design are:
/// 1. Director - constructs using the Builder
/// 2. Builder - Abstract class or interface which defines building methods
/// 3. ConcreteBuilder - implements/inherits Builder and constructs the Product
/// 4. Product - output of the ConcreteBuilder
/// </summary>
namespace CSharpDesignPatterns.Creational_Patterns
{
    // Director class
    public class Builder
    {
        public static void BuildGetRequest()
        {
            var getRequest = new HttpRequestBuilder()
                                 .AddHttpMethod("GET", "/api/users", 2.0)
                                 .AddGeneralHeaders(ConnectionType.KeepAlive)
                                 .Build();
            Console.WriteLine(getRequest);
        }

        public static void BuildPostRequest()
        {
            var postRequest = new HttpRequestBuilder()
                                  .AddHttpMethod("POST", "/api/user/1", 1.1)
                                  .AddGeneralHeaders(ConnectionType.KeepAlive)
                                  .AddRepresentationHeaders("application/json", "------RANDOM_NUM-----")
                                  .AddRequestBody(new Dictionary<string, string>
                                  {
                                      { "name", "John Doe"},
                                      { "hometown", "New York City" }
                                  })
                                  .Build();
            Console.WriteLine(postRequest);
        }
    }

    // Product
    class HttpRequest
    {
        public string Method { get; set; } = "GET";
        public string Path { get; set; } = "/";
        public double HttpVersion { get; set; } = 1.1;
        public string Host { get; set; } = "localhost";
        public string UAString { get; set; } = string.Empty;
        public string Accept { get; set; } = "*/*";
        public string AcceptLanguage { get; set; } = "en-US";
        public string AcceptEncoding { get; set; } = "gzip, deflate";
        public string Connection { get; set; } = string.Empty;
        public string ContentType { get; set; } = "text/plain";
        public string Boundary { get; set; } = string.Empty;
        public string Json { get; set; } = "{}";
    }

    //Builder interface
    interface IHttpRequestBuilder
    {
        public IHttpRequestBuilder AddHttpMethod(string method, string path, double httpVersion);
        public IHttpRequestBuilder AddRequestHeaders(string host, string userAgentString, string accept, 
                                                     string acceptLang, string acceptEncoding);
        public IHttpRequestBuilder AddGeneralHeaders(ConnectionType connectionType);
        public IHttpRequestBuilder AddRepresentationHeaders(string dataType, string boundary);
        // To make it easy, just string key and string value. No array.
        public IHttpRequestBuilder AddRequestBody(Dictionary<string, string> body);
        public string Build();
    }

    public enum ConnectionType
    {
        KeepAlive = 1,
        Close = 0
    }

    // Concrete Builder
    class HttpRequestBuilder : IHttpRequestBuilder
    {
        private HttpRequest _httpReq;
        public HttpRequestBuilder()
        {
            _httpReq = new HttpRequest();
        }

        public IHttpRequestBuilder AddHttpMethod(string method, string path, double httpVersion)
        {
            _httpReq.Method = method;
            _httpReq.Path = path;
            _httpReq.HttpVersion = httpVersion;
            return this;
        }

        public IHttpRequestBuilder AddRequestHeaders(string host, string userAgentString, string accept, 
                                                     string acceptLang, string acceptEncoding)
        {
            _httpReq.Host = host;
            _httpReq.UAString = userAgentString;
            _httpReq.Accept = accept;
            _httpReq.AcceptLanguage = acceptLang;
            _httpReq.AcceptEncoding = acceptEncoding;
            return this;
        }
        public IHttpRequestBuilder AddGeneralHeaders(ConnectionType connectionType)
        {
            _httpReq.Connection = connectionType == ConnectionType.KeepAlive ? "keep-alive" : "close";
            return this;
        }
        public IHttpRequestBuilder AddRepresentationHeaders(string dataType, string boundary)
        {
            var boundaryStr = !string.IsNullOrWhiteSpace(boundary) ? $"; boundary={boundary}" : string.Empty;
            _httpReq.Boundary = boundary;
            _httpReq.ContentType = $"{dataType}{boundaryStr}";
            return this;
        }

        public IHttpRequestBuilder AddRequestBody(Dictionary<string, string> body)
        {
            var json = "{";
            foreach(var key in body.Keys)
            {
                json += $"{key}: {body[key]},";
            }
            json = json.TrimEnd(new char[] { ',' });
            json += "}";
            _httpReq.Json = json;
            return this;
        }


        public string Build()
        {
            var httpRequest = new StringBuilder();
            // Http Header conventional line break is CRLF (\r\n) but RFC7230 also recognizes (\n)
            httpRequest.Append($"{_httpReq.Method} {_httpReq.Path} HTTP/{_httpReq.HttpVersion}{Environment.NewLine}");
            //Request headers
            httpRequest.Append($"Host: {_httpReq.Host}{Environment.NewLine}");
            httpRequest.Append($"User-Agent: {_httpReq.UAString}{Environment.NewLine}");
            httpRequest.Append($"Accept: {_httpReq.Accept}{Environment.NewLine}");
            httpRequest.Append($"Accept-Language: {_httpReq.AcceptLanguage}{Environment.NewLine}");
            httpRequest.Append($"Accept-Encoding: {_httpReq.AcceptEncoding}{Environment.NewLine}");
            //General headers
            httpRequest.Append($"Connection: {_httpReq.Connection}{Environment.NewLine}");
            //Representation headers
            httpRequest.Append($"Content-Type: {_httpReq.ContentType}{Environment.NewLine}");
            //Body
            if(!_httpReq.Json.Equals("{}"))
            {
                httpRequest.Append($"{_httpReq.Boundary}{Environment.NewLine}");
                httpRequest.Append($"{_httpReq.Json}{Environment.NewLine}");
            }
            return httpRequest.ToString();
        }
    }
}
