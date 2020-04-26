using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ConsoleGame
{
    /// <summary>
    /// Represents static class for initializing game from file.
    /// </summary>
    public static class GameInitializer
    {
        /// <summary>
        /// Get data of a resource file with specified path.
        /// </summary>
        /// <param name="path">Specified path of a resource file.</param>
        /// <returns>Data of resource file.</returns>
        private static string GetFileData(string path)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(path);
            using var reader = new StreamReader(stream ?? throw new InvalidMapException($"There is no map with this path: {path}"));
            return reader.ReadToEnd();
        }

        /// <summary>
        /// Initialize a new instance of <see cref="Game"/> with map from file with specified path and specified <see cref="IMapWriter"/>.
        /// </summary>
        /// <param name="path">Specified path of a resource file.</param>
        /// <param name="mapWriter">Specified <see cref="IMapWriter"/></param>
        /// <returns>New instance of <see cref="Game"/></returns>
        /// <exception cref="InvalidMapException">The map has an incorrect format.</exception>
        public static Game LoadGameWithSpecifiedMapWriterFromFile(string path, IMapWriter mapWriter)
        {
            var fileData = GetFileData(path).Split("\n", StringSplitOptions.RemoveEmptyEntries);
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
                            throw new InvalidMapException(fileData[x]);
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