namespace ExpressionTreeTask
{
    public class MultiplicationNode : INode
    {
        private readonly INode _leftNode;
        private readonly INode _rightNode;

        public MultiplicationNode(INode leftNode, INode rightNode)
        {
            _leftNode = leftNode;
            _rightNode = rightNode;
        }

        public int Calculate()
        {
            return _leftNode.Calculate() * _rightNode.Calculate();
        }

        public string Print()
        {
            return $"(* {_leftNode.Print()} {_rightNode.Print()})";
        }
    }
}