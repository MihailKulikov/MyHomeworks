using System;
using System.Collections.Generic;

namespace FindPairsGame
{
    /// <summary>
    /// Represents core for Find Pairs Game
    /// </summary>
    public class FindPairsCore
    {
        public int[,] CellsValue { get; }
        private States currentState = States.FirstCellWaiting;
        private (int x, int y) lastClickedCellCoordinates;
        private int enabledCellsCount;

        /// <summary>
        /// Initialize new instance of <see cref="FindPairsCore"/> with specified size.
        /// </summary>
        /// <param name="size">Specified size.</param>
        public FindPairsCore(int size)
        {
            CellsValue = new int[size, size];
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
            for (var i = 0; i < CellsValue.GetLength(0); i++)
            {
                for (var j = 0; j < CellsValue.GetLength(1); j++)
                {
                    var randomNumber = random.Next(0, cellsValue.Count);
                    CellsValue[i, j] = cellsValue[randomNumber];
                    cellsValue.RemoveAt(randomNumber);
                }
            }
        }

        /// <summary>
        /// Change cells visible on click.
        /// </summary>
        /// <param name="coordinates">Coordinates of button which was clicked.</param>
        /// <returns>Coordinates of buttons that should be enable.</returns>
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
                    if (CellsValue[coordinates.x, coordinates.y] ==
                        CellsValue[lastClickedCellCoordinates.x, lastClickedCellCoordinates.y])
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

        /// <summary>
        /// Checks is game over.
        /// </summary>
        /// <returns>true if is game over; false if it is not.</returns>
        public bool IsGameOver()
            => enabledCellsCount == 0;
    }
}
