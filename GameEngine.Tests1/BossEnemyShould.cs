using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests1
{
    public class BossEnemyShould
    {
        private readonly ITestOutputHelper _output;

        public BossEnemyShould(ITestOutputHelper output) 
        {
            _output = output;
        }

        [Fact]
        [Trait("Category", "Boss")]
        public void HaveCorrectPower() 
        {
            //System.Console.WriteLine("Creating Boss Enemy");
            // instead use the output interface
            _output.WriteLine("Creating Boss Enemy");
            BossEnemy sut = new BossEnemy();

            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);
        }
    }
}
