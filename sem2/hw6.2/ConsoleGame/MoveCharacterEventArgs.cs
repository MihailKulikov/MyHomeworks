using System;

namespace ConsoleGame
{
    public class MoveCharacterEventArgs : EventArgs
    {
        public MoveCharacterEventArgs((int x, int y) from, (int x, int y) to)
        {
            From = from;
            To = to;
        }

        public (int, int) From { get; }
        public (int, int) To { get; }
    }
}