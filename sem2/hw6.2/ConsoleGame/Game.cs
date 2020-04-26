using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    /// <summary>
    /// Represents 2D game.
    /// </summary>
    public class Game
    {
        private readonly List<Cell>[] _map;
        private readonly IMapWriter _mapWriter;
        private (int x, int y) _characterPosition;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class with specified map, starting character position and Map Writer.
        /// </summary>
        /// <param name="map">Specified map.</param>
        /// <param name="characterPosition">Specified starting character position.</param>
        /// <param name="mapWriter">Specified character position.</param>
        public Game(List<Cell>[] map, (int x, int y) characterPosition, IMapWriter mapWriter)
        {
            _map = map;
            _mapWriter = mapWriter;
            _characterPosition = characterPosition;
            
            _mapWriter.WriteMap(_map);
            _mapWriter.WriteCellOnTargetPosition(_characterPosition, Cell.Character);
        }

        /// <summary>
        /// Makes actions responsive to pressing the left key.
        /// </summary>
        public void OnLeft(object sender, EventArgs args)
        {
            var newCharacterPosition = (_characterPosition.x, _characterPosition.y - 1);
            TryChangeCharacterPosition(newCharacterPosition);
        }
        
        /// <summary>
        /// Makes actions responsive to pressing the right key.
        /// </summary>
        public void OnRight(object sender, EventArgs args)
        {
            var newCharacterPosition = (_characterPosition.x, _characterPosition.y + 1);
            TryChangeCharacterPosition(newCharacterPosition);
        }

        /// <summary>
        /// Makes actions responsive to pressing the up key
        /// </summary>
        public void OnUp(object sender, EventArgs args)
        {
            var newCharacterPosition = (_characterPosition.x - 1, _characterPosition.y);
            TryChangeCharacterPosition(newCharacterPosition);
        }

        /// <summary>
        /// Makes actions responsive to pressing the down key
        /// </summary>
        public void OnDown(object sender, EventArgs args)
        {
            var newCharacterPosition = (_characterPosition.x + 1, _characterPosition.y);
            TryChangeCharacterPosition(newCharacterPosition);
        }

        /// <summary>
        /// Changes character to the specified position if it possible.
        /// </summary>
        /// <param name="newCharacterPosition">Specified position for a character.</param>
        private void TryChangeCharacterPosition((int x, int y) newCharacterPosition)
        {
            if (!IsTheCellValid(newCharacterPosition)) return;
            
            _mapWriter.WriteCellOnTargetPosition(_characterPosition, Cell.FreeSpace);
            _mapWriter.WriteCellOnTargetPosition(newCharacterPosition, Cell.Character);
            _characterPosition = newCharacterPosition;
        }
        
        /// <summary>
        /// Checks if the character can be put in the specified position.
        /// </summary>
        /// <param name="position">Specified position.</param>
        /// <returns></returns>
        private bool IsTheCellValid((int x, int y) position)
        {
            var (x, y) = position;
            if (x < 0 || x > _map.Length - 1 || y < 0 || y > _map[x].Count - 1) return false;

            return _map[x][y] == Cell.FreeSpace;
        }
    }
}