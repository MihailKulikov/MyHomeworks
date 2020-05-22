using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace FindPairsGame
{
    public class FindPairsCore
    {
        public int[,] Cells { get; }
        private States currentState = States.FirstCellWaiting;
        private (int x, int y) lastClickedCellCoordinates;
        private int enabledCellsCount;

        public FindPairsCore(int size)
        {
            Cells = new int[size, size];
            enabledCellsCount = size * size;
            InitializeField(size);
        }

        private void InitializeField(int size)
        {
            var cellsValue = new List<int>();
            for (var i = 0; i < size * size / 2; i++)
            {
                cellsValue.Add(i);
                cellsValue.Add(i);
            }

            var random = new Random();
            for (var i = 0; i < Cells.GetLength(0); i++)
            {
                for (var j = 0; j < Cells.GetLength(1); j++)
                {
                    var randomNumber = random.Next(0, cellsValue.Count);
                    Cells[i, j] = cellsValue[randomNumber];
                    cellsValue.RemoveAt(randomNumber);
                }
            }
        }

        public (int, int)[] ChangeCellsVisibleOnClick((int x, int y) coordinates)
        {
            switch (currentState)
            {
                case States.FirstCellWaiting:
                    currentState = States.SecondCellWaiting;
                    lastClickedCellCoordinates = coordinates;
                    return Array.Empty<(int, int)>();
                case States.SecondCellWaiting:
                    currentState = States.FirstCellWaiting;
                    if (Cells[coordinates.x, coordinates.y] ==
                        Cells[lastClickedCellCoordinates.x, lastClickedCellCoordinates.y])
                    {
                        enabledCellsCount -= 2;
                        return Array.Empty<(int, int)>();
                    }
                    else
                    {
                        return new (int, int)[]{lastClickedCellCoordinates, coordinates};
                    }
                default:
                    return Array.Empty<(int, int)>();
            }
        }

        public bool IsGameOver()
            => enabledCellsCount == 0;
    }
}
