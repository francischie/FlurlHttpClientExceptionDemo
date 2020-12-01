using System;
using System.Threading.Tasks;
using Flurl.Http;

namespace FlurlHttpClientExceptionDemo.Clients
{
    public interface ISampleClient
    {
        Task DeleteAsync(Guid userId);
    }

    public class SampleClient : ISampleClient
    {
        public Task DeleteAsync(Guid userId)
        {
            var client = new FlurlClient();
            return client.Request("http://somedomain.com/api/v1/user")
                .DeleteAsync();
        }
    }
}