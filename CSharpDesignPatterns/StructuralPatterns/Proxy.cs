using System;
using System.Collections.Generic;

///<summary>
/// Four main components in Proxy design pattern:
/// 1. Interface (for service)
/// 2. Proxy class - implements the service interface
/// 3. Real service class - implements the service interface
/// 4. Client class - calls proxy instance via interface
///</summary>
namespace CSharpDesignPatterns.StructuralPatterns
{
    public class Proxy
    {
        public static void TestDesign()
        {

        }
    }

    // Service interface for both proxy and real services
    interface IRestfulService
    {
        public byte[] GetData(string url);

        public byte[] PostData(string url, byte[] data);
    }

    // Proxy service
    class ForwardProxyServer : IRestfulService
    {
        public List<string> RestrictedUrls { get; set; } = new List<string>();// security policies
        public Dictionary<string, string> Cache { get; set; } = new Dictionary<string, string>(); // real world cache uses time limit.

        private IRestfulService googleDNS { get; set; } = new GoogleDNS();
        public byte[] GetData(string url)
        {
            if (!RestrictedUrls.Contains(url))
                throw new Exception("Blocked for security reasons.");
            return googleDNS.GetData(url);
        }

        public byte[] PostData(string url, byte[] data)
        {
            if (!RestrictedUrls.Contains(url))
                throw new Exception("Blocked for security reasons.");
            return googleDNS.PostData(url, data);
        }
    }

    // Real service
    class GoogleDNS : IRestfulService
    {
        public byte[] GetData(string url)
        {
            return new byte[] { };
        }

        public byte[] PostData(string url, byte[] data)
        {
            return new byte[] { };
        }
    }

    // Client
    class Browser
    {
        private IRestfulService _proxy;
        public Browser()
        {
            _proxy = new ForwardProxyServer();
        }
        public void ViewPage(string url)
        {
            var data = _proxy.GetData(url);
            Render(data);
        }

        public void UploadData(string url, byte[] data)
        {
            var response = _proxy.PostData(url, data);
            Render(response);
        }

        public void Render(byte[] data)
        {

        }
    }
}