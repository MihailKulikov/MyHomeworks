using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using FindPairsGame;
using NUnit.Framework;
using FluentAssertions;

namespace FindPairsCoreTests
{
    public class FindPairsCoreShould
    {
        private FindPairsCore core;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CorrectInitializeFieldAfterCreation()
        {
            core = new FindPairsCore(2);
            
            core.CellsValue.Should().BeEquivalentTo(new []{0, 0, 1, 1});
        }

        [Test]
        public void ReturnTwoCoordinatesAfterClickCellsWithDifferentValue()
        {
            core = new FindPairsCore(4);

            (int x, int y) firstCoordinate = (0, 0);
            (int x, int y) secondCoordinate = (0, 0);

            for (var i = 1; i < core.CellsValue.GetLength(0); i++)
            {
                for (var q = 0; q < core.CellsValue.GetLength(1); q++)
                {
                    if (core.CellsValue[i, q] != core.CellsValue[0, 0])
                    {
                        secondCoordinate = (i, q);
                    }
                }
            }

            core.ChangeCellsVisibleOnClick(firstCoordinate);
            core.ChangeCellsVisibleOnClick(secondCoordinate).Should().BeEquivalentTo(firstCoordinate,secondCoordinate);
        }
    }
}