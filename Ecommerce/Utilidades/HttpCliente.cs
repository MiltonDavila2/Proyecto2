using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;

namespace Ecommerce.Utilidades
{
    public static class HttpCliente
    {

        public static HttpClient CreateHttpClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7290/")
            };
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
    }
}
