using DronesDelivery.Tests.Fixtures;
using Xunit;

namespace DronesDelivery.Tests
{
    public class TextFileDronesConfigReaderTests
    {
        [Fact]
        public void ReadConfig()
        {
            //Arrange
            var configReader = new TextFileDronesConfigReader();

            //Act
            var config = configReader.ReadConfig();

            //Assert
            Assert.Contains("01", config.Keys);
            Assert.Contains("02", config.Keys);
            Assert.Equal(3, config["01"].Count);
            Assert.Equal(2, config["02"].Count);
        }
    }
}