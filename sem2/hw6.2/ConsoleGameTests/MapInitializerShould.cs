using System.Collections.Generic;
using ConsoleGame;
using NUnit.Framework;
using FluentAssertions;

namespace ConsoleGameTests
{
    public class MapInitializerShould
    {
        private const char WallSymbol = '#';
        private const char FreeSpaceSymbol = ' ';
        private const char CharacterSymbol = '@';
        private GameInitializer _mapInitializer;

        [SetUp]
        public void Setup()
        {
            _mapInitializer = new GameInitializer(FreeSpaceSymbol, CharacterSymbol, WallSymbol);
        }

        [Test]
        public void Throw_InvalidMapException_WhenTryToLoad_MapWithWrongPath()
        {
            const string incorrectPath = "incorrect path";

            _mapInitializer
                .Invoking(x => x.LoadMapFromFile(incorrectPath))
                .ShouldThrow<InvalidMapException>()
                .WithMessage($"There is no map with this path: {incorrectPath}");
        }

        [Test]
        public void Throw_InvalidMapException_WhenTryToLoad_Map_With_TwoCharacters()
        {
            _mapInitializer
                .Invoking(x => x.LoadMapFromFile("ConsoleGame.Maps.MapWithTwoCharacters.txt"))
                .ShouldThrow<InvalidMapException>()
                .WithMessage("There can only be one character.");
        }

        [Test]
        public void Throw_InvalidMapException_WhenTryToLoad_Map_Without_Character()
        {
            _mapInitializer
                .Invoking(x => x.LoadMapFromFile("ConsoleGame.Maps.MapWithoutCharacter.txt"))
                .ShouldThrow<InvalidMapException>()
                .WithMessage("There is no character.");
        }

        [Test]
        public void Throw_InvalidMapException_WhenTryToLoad_Map_WithWrongSymbol()
        {
            _mapInitializer
                .Invoking(x => x.LoadMapFromFile("ConsoleGame.Maps.MapWithWrongSymbol.txt"))
                .ShouldThrow<InvalidMapException>()
                .WithMessage("There is unfamiliar symbol.");
        }

        [Test]
        public void InitializeCorrectMap()
        {
            var result = _mapInitializer.LoadMapFromFile("ConsoleGame.Maps.CorrectMap.txt");
            result[0].Should().Equal(new List<Cell> {Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall});
            result[1].Should().Equal(new List<Cell> { Cell.Wall, Cell.Character, Cell.FreeSpace, Cell.Wall });
            result[2].Should().Equal(new List<Cell> {Cell.Wall, Cell.FreeSpace, Cell.FreeSpace, Cell.Wall});
            result[3].Should().Equal(new List<Cell> {Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall});
        }
    }
}