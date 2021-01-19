using Xunit;

namespace GameEngine.Tests1
{
    public class BossEnemyShould
    {
        [Fact]
        public void HaveCorrectPower() 
        {
            BossEnemy sut = new BossEnemy();

            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);
        }
    }
}
