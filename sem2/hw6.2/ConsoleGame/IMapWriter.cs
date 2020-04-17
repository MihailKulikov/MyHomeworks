using System.Collections.Generic;

namespace ConsoleGame
{
    public interface IMapWriter
    {
        public void MoveCharacter(object sender, MoveCharacterEventArgs args);
        public void WriteMap(IEnumerable<List<Cell>> map);
    }
}