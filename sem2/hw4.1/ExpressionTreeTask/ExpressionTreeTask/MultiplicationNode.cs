namespace ExpressionTreeTask
{
    /// <summary>
    /// Represents multiplication operation in expression tree. Provides methods to calculate and print subtree.
    /// </summary>
    public class MultiplicationNode : INode
    {
        private readonly INode _leftNode;
        private readonly INode _rightNode;

        /// <summary>
        /// Initializes a new instance of the MultiplicationNode with introduced left child and right child.
        /// </summary>
        /// <param name="leftNode">Left child of the MultiplicationNode</param>
        /// <param name="rightNode">Right child of the MultiplicationNode</param>
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