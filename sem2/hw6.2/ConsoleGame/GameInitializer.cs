using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ConsoleGame
{
    public static class GameInitializer
    {
        private static string GetFileData(string path)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(path);
            using var reader = new StreamReader(stream ?? throw new InvalidMapException($"There is no map with this path: {path}"));
            return reader.ReadToEnd();
        }

        public static Game LoadGameWithSpecifiedMapWriterFromFile(string path, IMapWriter mapWriter)
        {
            var fileData = GetFileData(path).Split(Environment.NewLine);
            var characterWasAdded = false;
            (int x, int y) characterPosition = (0, 0);
            
            var map = new List<Cell>[fileData.Length];
            for (var i = 0; i < map.Length; i++)
            {
                map[i] = new List<Cell>();
            }

            for (var x = 0; x < fileData.Length; x++)
            {
                for (var y = 0; y < fileData[x].Length; y++)
                {
                    if (Enum.TryParse<Cell>(((int) fileData[x][y]).ToString(), out var cell))
                    {
                        if (Enum.IsDefined(typeof(Cell), cell))
                        {

                            if (cell == Cell.Character)
                            {
                                if (characterWasAdded)
                                {
                                    throw new InvalidMapException("There are several characters.");
                                }

                                characterWasAdded = true;
                                characterPosition = (x, y);
                                map[x].Add(Cell.FreeSpace);
                            }
                            else
                            {
                                map[x].Add(cell);
                            }
                        }
                        else
                        {
                            throw new InvalidMapException("There is unfamiliar symbol.");
                        }
                    }
                    else
                    {
                        throw new InvalidMapException("There is unfamiliar symbol.");
                    }
                }
            }

            if(!characterWasAdded)
                throw new InvalidMapException("There is no character.");
            
            return new Game(map, characterPosition, mapWriter);
        }
    }
}