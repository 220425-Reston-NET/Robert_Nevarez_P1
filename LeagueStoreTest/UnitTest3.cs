// using Xunit;
// using Summoner;
// namespace LeagueStoreTest
// {
//     public class UnitTest3
//     {
//         [Fact]
         
//         public void Summoner_Should_set_ValidData()
//         {
//             //Arrange
//             ChampionInfoInventory Test3 = new ChampionInfoInventory();
//             byte Test3check = 10;
            

//             //Act
//             Test3.ChampionInventory = Test3check;

//             //Assert

//             Assert.NotNull(Test3.ChampionInventory);
//             Assert.Equal(Test3check , Test3.ChampionInventory);
//         }

//         [Theory]
//         [InlineData(0)]
//         [InlineData(-233)]
//         [InlineData(-1)]
//         [InlineData(-3)]
//         [InlineData(1234567890)]
//         [InlineData(-123456789)]
//         public void Summoner_Should_Fail_Set_InvalidData(byte p_found)
//         {
//             ChampionInfoInventory Test3 = new ChampionInfoInventory();

//             Assert.Throws<System.ArgumentException>(() =>
//                 {
//                     Test3.ChampionInventory = p_found;
//                 }
//             );
//         }
//     }
// }