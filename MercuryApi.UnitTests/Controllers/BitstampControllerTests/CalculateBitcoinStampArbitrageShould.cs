using System.Threading.Tasks;
using AutoMapper;
using MercuryAp.Models.Dtos;
using MercuryApi.Config;
using MercuryApi.Controllers;
using MercuryApi.Models;
using MercuryApi.Models.Dtos;
using MercuryApi.Services.Interfaces;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace MercuryApi.UnitTests.Controllers.BitstampControllerTests
{
    public class CalculateBitcoinStampArbitrageShould
    {
        ApiKey key = new ApiKey()
        {
            Key = "a797108e840338c53aa8febe"
        };

        [Fact]
        public async Task CalculateBitstampArbitrage()
        {
            //Arrange
            var bitstampService = new Mock<IBitstampService>();
            var valrService = new Mock<IValrService>();
            var exchangeRateService = new Mock<IExchangeRateService>();
            var options = new Mock<IOptions<ApiKey>>();
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
                ConversionRate = 40506.59,
                BaseCode = "38361.38"
            };

            var jsonResponse = new JsonResponse
            {
                BitstampExchange = bitstampExchange,
                ValrExchange = valrExchange,
                ExchangeRate = exchangeRate,
            };

            var bitstampExchangeDto = new BitstampExchangeDto()
            {
                Ask = "38617.62",
                Open = "40506.59",
                Last = "38361.38"
            };

            var valrExchangeDto = new ValrExchangeDto()
            {
                AskPrice = "38617.62",
                BidPrice = "40506.59",
                HighPrice = "38361.38"
            };

            var exchangeRateDto = new ExchangeRateDto()
            {
                Result = "Success",
                ConversionRate = 40506.59,
                BaseCode = "38361.38"
            };

            var jsonResponseDto = new JsonResponseDto()
            {
                BitstampExchange = bitstampExchangeDto,
                ValrExchange = valrExchangeDto,
                ExchangeRate = exchangeRateDto,
            };


            var controller = new BitstampController(bitstampService.Object, valrService.Object, mapper.Object,
                            exchangeRateService.Object, options.Object);

            options.Setup(x => x.Value).Returns(key);
            bitstampService.Setup(x => x.GetBitstampValue("btcusd")).ReturnsAsync(bitstampExchange);
            valrService.Setup(x => x.GetValrValue("BTCZAR")).ReturnsAsync(valrExchange);
            //mapper.Setup(x => x.Map<JsonResponse>(It.IsAny<JsonResponse>(jsonResponseDto))).Returns(jsonResponseDto);
            exchangeRateService.Setup(x => x.GetExchangeRate(key.ToString())).ReturnsAsync(exchangeRate);

            //Act
            var okResult = await controller.CalculateBitstampArbitrage();

            // Assert
            Assert.NotNull(okResult);
        }
    }
}
