using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public class MapConsoleWriter : IMapWriter
    {
        private readonly char _wallSymbol;
        private readonly char _freeSpaceSymbol;
        private readonly char _characterSymbol;

        public MapConsoleWriter(char wallSymbol, char freeSpaceSymbol, char characterSymbol)
        {
            _wallSymbol = wallSymbol;
            _freeSpaceSymbol = freeSpaceSymbol;
            _characterSymbol = characterSymbol;
        }

        public void MoveCharacter(object sender, MoveCharacterEventArgs args)
        {
            var lastLineNumber = Console.CursorTop;
            var lastColumnNumber = Console.CursorLeft;
            var (fromX, fromY) = args.From;
            var (toX, toY) = args.To;
            
            Console.SetCursorPosition(fromY, fromX);
            Console.Write(_freeSpaceSymbol);
            Console.SetCursorPosition(toY, toX);
            Console.Write(_characterSymbol);
            
            Console.SetCursorPosition(lastColumnNumber,lastLineNumber);
        }
        
        public void WriteMap(IEnumerable<List<Cell>> map)
        {
            Console.SetCursorPosition(0, 0);

            foreach (var line in map)
            {
                foreach (var cell in line)
                {
                    switch (cell)
                    {
                        case Cell.Character:
                            Console.Write(_characterSymbol);
                            break;
                        case Cell.FreeSpace:
                            Console.Write(_freeSpaceSymbol);
                            break;
                        case Cell.Wall:
                            Console.Write(_wallSymbol);
                            break;
                    }
                }
                
                Console.WriteLine();
            }
        }
    }
}