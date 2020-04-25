using System.Collections.Generic;

namespace ConsoleGame
{
    public interface IMapWriter
    {
        public void WriteCellOnTargetPosition((int, int) position, Cell cell);
        public void WriteMap(IEnumerable<List<Cell>> map);
    }
}