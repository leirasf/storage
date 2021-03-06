﻿using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Storage.Net.Microsoft.Azure.DataLakeGen2.Store.Gen2.Interfaces;

namespace Storage.Net.Microsoft.Azure.DataLake.Store.Gen2.Wrappers
{
   class HttpClientWrapper : IHttpClientWrapper
   {
      private readonly HttpClient _httpClient;

      public HttpClientWrapper(HttpClient httpClient)
      {
         _httpClient = httpClient;
      }

      public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
      {
         return _httpClient.SendAsync(request, cancellationToken);
      }
   }
}