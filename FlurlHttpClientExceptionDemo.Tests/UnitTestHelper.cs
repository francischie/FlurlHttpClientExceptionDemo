using System.Net;
using System.Net.Http;
using AutoFixture;
using Flurl.Http;

namespace FlurlHttpClientExceptionDemo.Tests
{
    public static class UnitTestHelper
    {
        public static FlurlHttpException CreateFlurlHttpException(string httpContent = null, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            var response = new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(httpContent ?? string.Empty)
            };
            return new FlurlHttpException
            (new Fixture().Build<FlurlCall>()
                .OmitAutoProperties()
                .With(a => a.Request, new FlurlRequest {Url = "http://dummy"})
                .With(a => a.HttpRequestMessage, new HttpRequestMessage())
                .With(a => a.HttpResponseMessage, response)
                .With(a => a.Response, new FlurlResponse(response))
                .Create());
        }
    }
}