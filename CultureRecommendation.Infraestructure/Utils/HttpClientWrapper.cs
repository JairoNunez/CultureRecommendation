using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CultureRecommendation.Infraestructure.Utils
{

    public class HttpClientWrapper : IHttpClientWrapper
    {

        private readonly IHttpClientFactory _clientFactory;

        public HttpClientWrapper(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> GetAsyncWithApiKey<T>(string uri, string requestUri, IEnumerable<KeyValuePair<string, string>> values = null, string apiKey = "",bool paginate = true)
        {
            try
            {

                UriBuilder builder = new UriBuilder(uri);
                builder.Path = requestUri;
               
                using (var content = new FormUrlEncodedContent(values))
                {
                   
                    builder.Query = await content.ReadAsStringAsync().ConfigureAwait(false);
                    builder.Query += "&" + "api_key=" + apiKey;

                    var client = _clientFactory.CreateClient(builder.ToString());

                    var response = await client.GetAsync(builder.Uri);

                    var json = await response.Content.ReadAsStringAsync();

                    var res = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);

                    return res;

                }
            }

            catch (Exception e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }
                  
    }

}
