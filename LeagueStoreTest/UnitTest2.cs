using Xunit;
using Summoner;
namespace LeagueStoreTest
{
    public class UnitTest2
    {
        [Fact]
         
        public void Summoner_Should_set_ValidData()
        {
            //Arrange
            SummonerInfo Test1 = new SummonerInfo();
            string TestName = "Nevark";
            

            //Act
            Test1.Name = TestName;

            //Assert

            Assert.NotNull(Test1.Name);
            Assert.Equal(TestName , Test1.Name);
        }

        [Theory]
        [InlineData("Ab")]
        [InlineData("-123")]
        [InlineData("a")]
        [InlineData("aaaa")]
        [InlineData("-a")]
        [InlineData("---")]
        [InlineData("@@@")]
        public void Summoner_Should_Fail_Set_InvalidData(string p_found)
        {
            SummonerInfo Test1 = new SummonerInfo();

            Assert.Throws<System.ComponentModel.DataAnnotations.ValidationException>(() =>
                {
                    Test1.Name = p_found;
                }
            );
        }
    }
}
