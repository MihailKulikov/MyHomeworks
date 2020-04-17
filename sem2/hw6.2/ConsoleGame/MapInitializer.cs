using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ConsoleGame
{
    public class MapInitializer
    {
        private readonly char _wallSymbol;
        private readonly char _characterSymbol;
        private readonly char _freeSpaceSymbol;

        public MapInitializer(char freeSpaceSymbol, char characterSymbol, char wallSymbol)
        {
            _freeSpaceSymbol = freeSpaceSymbol;
            _characterSymbol = characterSymbol;
            _wallSymbol = wallSymbol;
        }

        private string GetFileData(string path)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(path);
            using var reader = new StreamReader(stream ?? throw new InvalidMapException($"There is no map with this path: {path}"));
            return reader.ReadToEnd();
        }

        public List<Cell>[] LoadMapFromFile(string path)
        {
            var fileData = GetFileData(path).Split(Environment.NewLine);
            var characterWasAdded = false;

            var map = new List<Cell>[fileData.Length];
            for (var i = 0; i < map.Length; i++)
            {
                map[i] = new List<Cell>();
            }
            
            for (var x = 0; x < fileData.Length; x++)
            {
                for (var y = 0; y < fileData[x].Length; y++)
                {
                    if (fileData[x][y] == _wallSymbol)
                    {
                        map[x].Add(Cell.Wall);
                    }
                    else if (fileData[x][y] == _characterSymbol)
                    {
                        if (characterWasAdded)
                            throw new InvalidMapException("There can only be one character.");

                        map[x].Add(Cell.Character);
                        characterWasAdded = true;
                    }
                    else if (fileData[x][y] == _freeSpaceSymbol)
                    {
                        map[x].Add(Cell.FreeSpace);
                    }
                    else
                    {
                        throw new InvalidMapException("There is unfamiliar symbol.");
                    }
                }
            }

            if(!characterWasAdded)
                throw new InvalidMapException("There is no character.");

            return map;
        }
    }
}