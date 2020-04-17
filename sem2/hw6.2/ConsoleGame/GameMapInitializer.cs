using System.Collections.Generic;
using System.IO;

namespace ConsoleGame
{
    public class MapInitializer
    {
        private const char WallSymbol = '#';
        private const char CharacterSymbol = '@';
        private const char FreeSpaceSymbol = ' ';

        public List<Cell>[] LoadMapFromFile(string path)
        {
            var fileData = File.ReadAllLines(path);
            var characterWasAdded = false;

            List<Cell>[] map = new List<Cell>[fileData.Length];
            for (var i = 0; i < map.Length; i++)
            {
                map[i] = new List<Cell>();
            }
            
            for (var x = 0; x < fileData.Length; x++)
            {
                for (var y = 0; y < fileData[x].Length; y++)
                {
                    switch (fileData[x][y])
                    {
                        case WallSymbol:
                            map[x].Add(Cell.Wall);
                            break;
                        case CharacterSymbol:
                            if(characterWasAdded)
                                throw new InvalidMapException("There can only be one character.");
                            
                            map[x].Add(Cell.Character);
                            characterWasAdded = true;
                            break;
                        case FreeSpaceSymbol:
                            map[x].Add(Cell.FreeSpace);
                            break;
                        default:
                            throw new InvalidMapException("Unfamiliar character seen.");
                    }
                }
            }

            if(!characterWasAdded)
                throw new InvalidMapException("There is no character.");

            return map;
        }
    }
}