using System.Collections.Generic;
using System.Threading.Tasks;

namespace CultureRecommendation.Infraestructure.Utils
{

    public interface  IHttpClientWrapper
    {
        Task<T> GetAsyncWithApiKey<T> (string uri, string requestUri, IEnumerable<KeyValuePair<string, string>> values = null, string apiKey="", bool paginate = true);
    }

}
