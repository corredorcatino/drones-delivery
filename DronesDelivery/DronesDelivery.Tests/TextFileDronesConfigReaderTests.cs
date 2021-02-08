using DronesDelivery.Tests.Fixtures;
using Xunit;

namespace DronesDelivery.Tests
{
    public class TextFileDronesConfigReaderTests : IClassFixture<FirstDroneFixture>
    {
        private readonly FirstDroneFixture _firstDroneFixture;

        public TextFileDronesConfigReaderTests(FirstDroneFixture firstDroneFixture)
        {
            _firstDroneFixture = firstDroneFixture;
        }

        [Fact]
        public void ReadConfig()
        {
            //Arrange
            var configReader = new TextFileDronesConfigReader();

            //Act
            var config = configReader.ReadConfig();

            //Assert
            var expected = _firstDroneFixture.Config;

            Assert.Equal(expected, config);
        }
    }
}