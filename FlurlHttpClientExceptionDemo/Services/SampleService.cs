using System;
using System.Threading.Tasks;
using Flurl.Http;
using FlurlHttpClientExceptionDemo.Clients;

namespace FlurlHttpClientExceptionDemo.Services
{
    public class SampleService
    {
        private readonly ISampleClient _client;

        public SampleService(ISampleClient client)
        {
            _client = client;
        }

        public async Task<int> DeleteAsync(Guid userId)
        {
            try
            {
                await _client.DeleteAsync(userId);
                //-- and some more code here....
                return 1;
            }
            catch (FlurlHttpException e)
            {
                //-- do something useful like logging the exception for swallowing it to oblivion
                return -1;
            }
        }
    }
}