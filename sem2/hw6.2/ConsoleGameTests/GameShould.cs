using System;
using System.Collections.Generic;
using ConsoleGame;
using NUnit.Framework;
using FakeItEasy;

namespace ConsoleGameTests
{
    public class GameShould
    {
        private IMapWriter _mapWriter;

        private readonly List<Cell>[] _firstMap =
        {
            new List<Cell> {Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall},
            new List<Cell> {Cell.Wall, Cell.FreeSpace, Cell.FreeSpace, Cell.FreeSpace, Cell.Wall},
            new List<Cell> {Cell.Wall, Cell.FreeSpace, Cell.Character, Cell.FreeSpace, Cell.Wall},
            new List<Cell> {Cell.Wall, Cell.FreeSpace, Cell.FreeSpace, Cell.FreeSpace, Cell.Wall},
            new List<Cell> {Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall}
        };

        private readonly List<Cell>[] _secondMap =
        {
            new List<Cell> {Cell.Wall, Cell.Wall, Cell.Wall},
            new List<Cell> {Cell.Wall, Cell.Wall, Cell.Wall},
            new List<Cell> {Cell.Wall, Cell.Wall, Cell.Character}
        };

        private readonly (int x, int y) _characterPosition = (2, 2);

        [SetUp]
        public void SetUp()
        {
            _mapWriter = A.Fake<IMapWriter>();
        }

        [Test]
        public void CallMapWriterMethodsWhenCreated()
        {
            var game = new Game(_firstMap, _characterPosition, _mapWriter);
            
            A.CallTo(() => _mapWriter.WriteMap(_firstMap)).MustHaveHappenedOnceExactly();
            A.CallTo(() => _mapWriter.WriteCellOnTargetPosition(_characterPosition, Cell.Character))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public void CallMapWriterMethods_WhenCharacterCanMove_AfterOnDown_Is_Called()
        {
            var game = new Game(_firstMap, _characterPosition, _mapWriter);
            var newCharacterPosition = (_characterPosition.x + 1, _characterPosition.y);
            game.OnDown(this, EventArgs.Empty);

            A.CallTo(() => _mapWriter.WriteCellOnTargetPosition(_characterPosition, Cell.FreeSpace))
                .MustHaveHappenedOnceExactly();
            A.CallTo(() => _mapWriter.WriteCellOnTargetPosition(newCharacterPosition, Cell.Character))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public void CallMapWriterMethods_WhenCharacterCanMove_AfterOnUp_Is_Called()
        {
            var game = new Game(_firstMap, _characterPosition, _mapWriter);
            var newCharacterPosition = (_characterPosition.x - 1, _characterPosition.y);
            game.OnUp(this, EventArgs.Empty);

            A.CallTo(() => _mapWriter.WriteCellOnTargetPosition(_characterPosition, Cell.FreeSpace))
                .MustHaveHappenedOnceExactly();
            A.CallTo(() => _mapWriter.WriteCellOnTargetPosition(newCharacterPosition, Cell.Character))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public void CallMapWriterMethods_WhenCharacterCanMove_AfterOnRight_Is_Called()
        {
            var game = new Game(_firstMap, _characterPosition, _mapWriter);
            var newCharacterPosition = (_characterPosition.x, _characterPosition.y + 1);

            game.OnRight(this, EventArgs.Empty);

            A.CallTo(() => _mapWriter.WriteCellOnTargetPosition(_characterPosition, Cell.FreeSpace))
                .MustHaveHappenedOnceExactly();
            A.CallTo(() => _mapWriter.WriteCellOnTargetPosition(newCharacterPosition, Cell.Character))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public void CallMapWriterMethods_WhenCharacterCanMove_AfterOnLeft_Is_Called()
        {
            var game = new Game(_firstMap, _characterPosition, _mapWriter);
            var newCharacterPosition = (_characterPosition.x, _characterPosition.y - 1);

            game.OnLeft(this, EventArgs.Empty);

            A.CallTo(() => _mapWriter.WriteCellOnTargetPosition(_characterPosition, Cell.FreeSpace))
                .MustHaveHappenedOnceExactly();
            A.CallTo(() => _mapWriter.WriteCellOnTargetPosition(newCharacterPosition, Cell.Character))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public void CallMapWriterMethods_WhenCharacterCan_Not_Move_AfterOnDown_Is_Called()
        {
            var game = new Game(_secondMap, _characterPosition, _mapWriter);
            
            game.OnDown(this, EventArgs.Empty);

            A.CallTo(() => _mapWriter.WriteCellOnTargetPosition(_characterPosition, Cell.Character)).WithAnyArguments()
                .MustHaveHappenedOnceExactly();
        }
        
        [Test]
        public void CallMapWriterMethods_WhenCharacterCan_Not_Move_AfterOnUp_Is_Called()
        {
            var game = new Game(_secondMap, _characterPosition, _mapWriter);
            
            game.OnUp(this, EventArgs.Empty);

            A.CallTo(() => _mapWriter.WriteCellOnTargetPosition(_characterPosition, Cell.Character)).WithAnyArguments()
                .MustHaveHappenedOnceExactly();
        }
        
        [Test]
        public void CallMapWriterMethods_WhenCharacterCan_Not_Move_AfterOnRight_Is_Called()
        {
            var game = new Game(_secondMap, _characterPosition, _mapWriter);
            
            game.OnRight(this, EventArgs.Empty);

            A.CallTo(() => _mapWriter.WriteCellOnTargetPosition(_characterPosition, Cell.Character)).WithAnyArguments()
                .MustHaveHappenedOnceExactly();
        }
        
        [Test]
        public void CallMapWriterMethods_WhenCharacterCan_Not_Move_AfterOnLeft_Is_Called()
        {
            var game = new Game(_secondMap, _characterPosition, _mapWriter);
            
            game.OnLeft(this, EventArgs.Empty);

            A.CallTo(() => _mapWriter.WriteCellOnTargetPosition(_characterPosition, Cell.Character)).WithAnyArguments()
                .MustHaveHappenedOnceExactly();
        }
    }
}