using Xunit;
using Summoner;
namespace LeagueStoreTest
{
    public class UnitTest1
    {
        [Fact]
         
        public void Summoner_Should_set_ValidData()
        {
            //Arrange
            SummonerInfo Test2 = new SummonerInfo();
            double testphone = 1000000001;
            

            //Act
            Test2.Phonenumber = testphone;

            //Assert

            Assert.NotNull(Test2.Phonenumber);
            Assert.Equal(testphone , Test2.Phonenumber);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(-200092)]
        [InlineData(12345678900)]
        [InlineData(-1234567890)]
        [InlineData(0)]
        public void Summoner_Should_Fail_Set_InvalidData(double p_found)
        {
            SummonerInfo Test1 = new SummonerInfo();

            Assert.Throws<System.ComponentModel.DataAnnotations.ValidationException>(() =>
                {
                    Test1.Phonenumber = p_found;
                }
            );
        }
    }
}
