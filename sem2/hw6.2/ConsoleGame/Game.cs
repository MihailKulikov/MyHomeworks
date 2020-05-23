using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    /// <summary>
    /// Represents 2D game.
    /// </summary>
    public class Game
    {
        private readonly List<Cell>[] map;
        private readonly IMapWriter mapWriter;
        private (int x, int y) characterPosition;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class with specified map, starting character position and Map Writer.
        /// </summary>
        /// <param name="map">Specified map.</param>
        /// <param name="characterPosition">Specified starting character position.</param>
        /// <param name="mapWriter">Specified character position.</param>
        public Game(List<Cell>[] map, (int x, int y) characterPosition, IMapWriter mapWriter)
        {
            this.map = map;
            this.mapWriter = mapWriter;
            this.characterPosition = characterPosition;
            
            this.mapWriter.WriteMap(this.map);
            this.mapWriter.WriteCellOnTargetPosition(this.characterPosition, Cell.Character);
        }

        /// <summary>
        /// Makes actions responsive to pressing the left key.
        /// </summary>
        public void OnLeft(object sender, EventArgs args)
            => TryChangeCharacterPosition((characterPosition.x, characterPosition.y - 1));

        /// <summary>
        /// Makes actions responsive to pressing the right key.
        /// </summary>
        public void OnRight(object sender, EventArgs args)
            => TryChangeCharacterPosition((characterPosition.x, characterPosition.y + 1));

        /// <summary>
        /// Makes actions responsive to pressing the up key.
        /// </summary>
        public void OnUp(object sender, EventArgs args)
            => TryChangeCharacterPosition((characterPosition.x - 1, characterPosition.y));

        /// <summary>
        /// Makes actions responsive to pressing the down key.
        /// </summary>
        public void OnDown(object sender, EventArgs args)
            => TryChangeCharacterPosition((characterPosition.x + 1, characterPosition.y));

        /// <summary>
        /// Changes character to the specified position if it possible.
        /// </summary>
        /// <param name="newCharacterPosition">Specified position for a character.</param>
        private void TryChangeCharacterPosition((int x, int y) newCharacterPosition)
        {
            if (!IsTheCellValid(newCharacterPosition)) return;
            
            mapWriter.WriteCellOnTargetPosition(characterPosition, Cell.FreeSpace);
            mapWriter.WriteCellOnTargetPosition(newCharacterPosition, Cell.Character);
            characterPosition = newCharacterPosition;
        }
        
        /// <summary>
        /// Checks if the character can be put in the specified position.
        /// </summary>
        /// <param name="position">Specified position.</param>
        /// <returns></returns>
        private bool IsTheCellValid((int x, int y) position)
        {
            var (x, y) = position;
            if (x < 0 || x > map.Length - 1 || y < 0 || y > map[x].Count - 1) return false;

            return map[x][y] == Cell.FreeSpace;
        }
    }
}