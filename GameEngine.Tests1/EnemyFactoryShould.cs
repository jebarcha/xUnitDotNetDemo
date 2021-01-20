using System;
using Xunit;

namespace GameEngine.Tests1
{
    public class EnemyFactoryShould
    {
        [Fact]
        public void CreateNormalEnemyByDefault()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
        }
        [Fact]
        public void CreateNormalEnemyByDefault_NotTypeExample() 
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie");

            Assert.IsNotType<DateTime>(enemy);
        }
        [Fact]
        public void CreateBossEnemy() 
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            Assert.IsType<BossEnemy>(enemy);
        }
        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample() 
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            // Assert and get cast result
            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

            // Additional asserts on typed object
            Assert.Equal("Zombie King", boss.Name);
        }
        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes() 
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            //Assert.IsType<Enemy>(enemy);  // this is stricted type, that's why it fails
            Assert.IsAssignableFrom<Enemy>(enemy);  // we can use IsAssignableFrom

        }
        [Fact]
        public void CreateSeparateInstances() 
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");

            // We want to check those 2 enemies are separete object references, in other words to check they are not the same enemy
            Assert.NotSame(enemy1, enemy2);
        }
        [Fact]
        public void NotAllowNullName() 
        {
            EnemyFactory sut = new EnemyFactory();

            //Assert.Throws<ArgumentNullException>(() => sut.Create(null));
            Assert.Throws<ArgumentNullException>("name", () => sut.Create(null));
        }
        [Fact]
        public void OnlyAllowKingOrQueenBossEnemies() 
        {
            EnemyFactory sut = new EnemyFactory();

            EnemyCreationException ex =
                Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie", true));

            Assert.Equal("Zombie", ex.RequestedEnemyName);
        }
    }
}
