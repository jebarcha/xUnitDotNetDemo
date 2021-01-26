using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests1
{
    public class PlayerCharacterShould: IDisposable
    {
        private readonly PlayerCharacter _sut;
        private readonly ITestOutputHelper _output;

        public PlayerCharacterShould(ITestOutputHelper output)
        {
            _output = output;

            _output.WriteLine("Creating new PlayerCharacter");
            _sut = new PlayerCharacter();
        }

        public void Dispose() 
        {
            _output.WriteLine($"Disposing PlayerCharacter {_sut.FullName}");
            //_sut.Dispose();
        }

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            Assert.True(_sut.IsNoob);
        }
        [Fact]
        public void CalculateFullName()
        {
            _sut.FirstName = "Jose";
            _sut.LastName = "Barajas";

            Assert.Equal("Jose Barajas", _sut.FullName);
        }
        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            _sut.FirstName = "Jose";
            _sut.LastName = "Barajas";

            Assert.StartsWith("Jose", _sut.FullName);
        }
        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
            _sut.FirstName = "JOSE";
            _sut.LastName = "BARAJAS";

            Assert.Equal("Jose Barajas", _sut.FullName, ignoreCase: true);
        }
        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {
            _sut.FirstName = "Jose";
            _sut.LastName = "Barajas";

            Assert.Contains("se Ba", _sut.FullName);
        }
        [Fact]
        public void CalculateFullName_FullNameWithTitleCase()
        {
            _sut.FirstName = "Jose";
            _sut.LastName = "Barajas";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", _sut.FullName);
        }
        [Fact]
        public void StartWithDefaultHealth()
        {
            Assert.Equal(100, _sut.Health);
        }
        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {
            Assert.NotEqual(0, _sut.Health);
        }
        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            _sut.Sleep(); // Expect increase between 1 and 100 inclusive

            //Assert.True(_sut.Health >= 101 && _sut.Health <= 200);
            Assert.InRange(_sut.Health, 101, 200);
        }
        [Fact]
        public void NotHaveNickNameByDefault()
        {
            Assert.Null(_sut.Nickname);
        }
        [Fact]
        public void HaveALongBow()
        {
            Assert.Contains("Long Bow", _sut.Weapons);
        }
        [Fact]
        public void NotHaveAStaffOfWonder()
        {
            Assert.DoesNotContain("Staff of Wonder", _sut.Weapons);
        }
        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            Assert.Contains(_sut.Weapons, weapon => weapon.Contains("Sword"));
        }
        [Fact]
        public void HaveAllExpectedWeapons()
        {
            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            Assert.Equal(expectedWeapons, _sut.Weapons);
        }
        [Fact]
        public void HaveNoEmptyDefaultWeapons() 
        {
            Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }
        [Fact]
        public void RaiseSleptEvent() 
        {
            Assert.Raises<EventArgs>(
                handler => _sut.PlayerSlept += handler, 
                handler => _sut.PlayerSlept -= handler,
                () => _sut.Sleep());
        }
        [Fact]
        public void RaisePropertyChangedEvent() 
        {
            Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));
        }
    }
}
