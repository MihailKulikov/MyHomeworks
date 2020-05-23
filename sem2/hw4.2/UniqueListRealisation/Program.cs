using System;
using System.Collections.Generic;

namespace UniqueListRealisation
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> ololo = new UniqueList<int>();
            ololo.AddElementByIndex(1, 0);
            ololo.AddElementByIndex(1, 0);
        }
    }
}