using System;
using Xunit;

namespace GameEngine.Tests1
{
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInexperiencedWhenNew()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.True(sut.IsNoob);
        }
        [Fact]
        public void CalculateFullName()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Jose";
            sut.LastName = "Barajas";

            Assert.Equal("Jose Barajas", sut.FullName);
        }
        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Jose";
            sut.LastName = "Barajas";

            Assert.StartsWith("Jose", sut.FullName);
        }
        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "JOSE";
            sut.LastName = "BARAJAS";

            Assert.Equal("Jose Barajas", sut.FullName, ignoreCase: true);
        }
        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Jose";
            sut.LastName = "Barajas";

            Assert.Contains("se Ba", sut.FullName);
        }
        [Fact]
        public void CalculateFullName_FullNameWithTitleCase()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Jose";
            sut.LastName = "Barajas";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.FullName);
        }
        [Fact]
        public void StartWithDefaultHealth() 
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Equal(100, sut.Health);
        }
        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.NotEqual(0, sut.Health);
        }
        [Fact]
        public void IncreaseHealthAfterSleeping() 
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.Sleep(); // Expect increase between 1 and 100 inclusive

            //Assert.True(sut.Health >= 101 && sut.Health <= 200);
            Assert.InRange(sut.Health, 101, 200);
        }
        [Fact]
        public void NotHaveNickNameByDefault() 
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Null(sut.Nickname);
        }
    }
}
