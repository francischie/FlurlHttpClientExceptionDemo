using System;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using FlurlHttpClientExceptionDemo.Clients;
using FlurlHttpClientExceptionDemo.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace FlurlHttpClientExceptionDemo.Tests.Services
{
    public class SampleServiceTests
    {
        private readonly Mock<ISampleClient> _client;
        private readonly SampleService _sut;

        public SampleServiceTests()
        {
            _client = new Mock<ISampleClient>();

            var services = new ServiceCollection()
                .AddTransient(a => _client.Object)
                .BuildServiceProvider();

            _sut = ActivatorUtilities.CreateInstance<SampleService>(services);
        }



        [Theory, AutoData]
        public async Task DeleteAsync_Test(Guid userId, string message)
        {
            _client.Setup(a => a.DeleteAsync(It.IsAny<Guid>()))
                .ThrowsAsync(UnitTestHelper.CreateFlurlHttpException(JsonConvert.SerializeObject(message)));

            var result = await _sut.DeleteAsync(userId);

            result.Should().Be(-1);
        }
    }
}