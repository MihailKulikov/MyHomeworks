using System.Runtime.InteropServices.WindowsRuntime;

namespace ExpressionTreeTask
{
    public class NumberNode : INode
    {
        private readonly int _value;

        public NumberNode(int value)
        {
            _value = value;
        }

        public int Calculate()
        {
            return _value;
        }

        public string Print()
        {
            return _value.ToString();
        }
    }
}