using System;
using System.Threading.Tasks;
using AutoMapper;
using MercuryApi.Config;
using MercuryApi.Controllers;
using MercuryApi.Models;
using MercuryApi.Services.Interfaces;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace MercuryApi.UnitTests.Controllers.BitstampControllerTests
{
    public class CalculateBitcoinStampArbitrageShould
    {
        //readonly IOptions<ApiKey> _ptions;

        //public CalculateBitcoinStampArbitrageShould(IOptions<ApiKey> ptions)
        //{
        //    _ptions = ptions;
        //}

        //IOptions<ApiKey> someOptions = Options.Create<ApiKey>(new ApiKey());

        [Fact]
        public async Task CalculateBitstampArbitrage()
        {
            //Arrange
            var bitstampService = new Mock<IBitstampService>();
            var valrService = new Mock<IValrService>();
            var exchangeRateService = new Mock<IExchangeRateService>();
            var options = new Mock<IOptions<ApiKey>>(new ApiKey());
            var mapper = new Mock<IMapper>();

            var bitstampExchange = new BitstampExchange()
            {
                Ask = "38617.62",
                Open = "40506.59",
                Last = "38361.38"
            };

            var valrExchange = new ValrExchange()
            {
                AskPrice = "38617.62",
                BidPrice = "40506.59",
                HighPrice = "38361.38"
            };

            var exchangeRate = new ExchangeRate()
            {
                Result = "Success",
                conversion_rate = 40506.59,
                base_code = "38361.38"
            };

            var jsonResponse = new JsonResponse
            {
                BitstampExchange = bitstampExchange,
                ValrExchange = valrExchange,
                ExchangeRate = exchangeRate,
            };

            bitstampService.Setup(x => x.GetBitstampValue("btcusd")).ReturnsAsync(bitstampExchange);
            valrService.Setup(x => x.GetValrValue("BTCZAR")).ReturnsAsync(valrExchange);
            var resoptions = options.Setup(x => x.Value.Key).Returns("a797108e840338c53aa8febe");
            exchangeRateService.Setup(x => x.GetExchangeRate(resoptions.ToString())).ReturnsAsync(exchangeRate);

            var controller = new BitstampController(bitstampService.Object, valrService.Object, mapper.Object,
                            exchangeRateService.Object, options.Object);

            //Act
            var okResult = await controller.CalculateBitstampArbitrage();

            // Assert
            Assert.NotNull(okResult);
        }
    }
}
