using System;
using ConsoleGame;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace ConsoleGameTests
{
    public class GameInitializerShould
    {
        private IMapWriter _mapWriter;
        
        [SetUp]
        public void Setup()
        {
            _mapWriter = A.Fake<IMapWriter>();
        }

        [Test]
        public void Throw_InvalidMapException_WhenTryToLoad_MapWithWrongPath()
        {
            const string incorrectPath = "incorrect path";
            Action act = () => GameInitializer.LoadGameWithSpecifiedMapWriterFromFile(incorrectPath, _mapWriter);

            act.ShouldThrow<InvalidMapException>().WithMessage($"There is no map with this path: {incorrectPath}");
        }

        [Test]
        public void Throw_InvalidMapException_WhenTryToLoad_Map_With_TwoCharacters()
        {
            Action act = () =>
                GameInitializer.LoadGameWithSpecifiedMapWriterFromFile("ConsoleGame.Maps.MapWithTwoCharacters.txt",
                    _mapWriter);
                
                act.ShouldThrow<InvalidMapException>()
                .WithMessage("There are several characters.");
        }

        [Test]
        public void Throw_InvalidMapException_WhenTryToLoad_Map_Without_Character()
        {
            Action act = () =>
                GameInitializer.LoadGameWithSpecifiedMapWriterFromFile("ConsoleGame.Maps.MapWithoutCharacter.txt",
                    _mapWriter);

            act.ShouldThrow<InvalidMapException>()
                .WithMessage("There is no character.");
        }

        [Test]
        public void Throw_InvalidMapException_WhenTryToLoad_Map_WithWrongSymbol()
        {
            Action act = () =>
                GameInitializer.LoadGameWithSpecifiedMapWriterFromFile("ConsoleGame.Maps.MapWithWrongSymbol.txt",
                    _mapWriter);
            act.ShouldThrow<InvalidMapException>()
                .WithMessage("There is unfamiliar symbol.");
        }

        [Test]
        public void InitializeCorrectMap()
        {
            var characterPosition = (1, 1);
            
            var game = GameInitializer.LoadGameWithSpecifiedMapWriterFromFile("ConsoleGame.Maps.CorrectMap.txt", _mapWriter);

            A.CallTo(() => _mapWriter.WriteMap(null)).WithAnyArguments().MustHaveHappenedOnceExactly();
            A.CallTo(() => _mapWriter.WriteCellOnTargetPosition(characterPosition, Cell.Character))
                .MustHaveHappenedOnceExactly();
        }
    }
}