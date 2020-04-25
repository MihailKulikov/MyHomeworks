using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public class ConsoleMapWriter : IMapWriter
    {
        public void WriteCellOnTargetPosition((int, int) position, Cell cell)
        {
            var lastLineNumber = Console.CursorTop;
            var lastColumnNumber = Console.CursorLeft;
            var (positionX, positionY) = position;
            
            Console.SetCursorPosition(positionY, positionX);
            Console.Write((char)int.Parse(Enum.Format(typeof(Cell), cell, "d")));
            Console.SetCursorPosition(lastColumnNumber,lastLineNumber);
        }

        public void WriteMap(IEnumerable<List<Cell>> map)
        {
            Console.SetCursorPosition(0, 0);

            foreach (var line in map)
            {
                foreach (var cell in line)
                {
                    Console.Write((char)int.Parse(Enum.Format(typeof(Cell), cell, "d")));
                }
                
                Console.WriteLine();
            }
        }
    }
}