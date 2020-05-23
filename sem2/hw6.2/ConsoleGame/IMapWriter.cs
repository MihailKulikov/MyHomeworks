using System.Collections.Generic;

namespace ConsoleGame
{
    /// <summary>
    /// Represents a map writer for the game.
    /// </summary>
    public interface IMapWriter
    {
        /// <summary>
        /// Write symbol of specified cell on specified position.
        /// </summary>
        /// <param name="position">Specified position.</param>
        /// <param name="cell">Specified cell.</param>
        public void WriteCellOnTargetPosition((int, int) position, Cell cell);
        
        /// <summary>
        /// Write specified map for the game.
        /// </summary>
        /// <param name="map">Specified map for the game.</param>
        public void WriteMap(IEnumerable<List<Cell>> map);
    }
}