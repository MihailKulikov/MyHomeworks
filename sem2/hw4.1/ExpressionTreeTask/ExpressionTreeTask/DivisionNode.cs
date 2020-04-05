namespace ExpressionTreeTask
{
    /// <summary>
    /// Represents division operation in expression tree. Provides methods to calculate and print subtree.
    /// </summary>
    public class DivisionNode : INode
    {
        private readonly INode _leftNode;
        private readonly INode _rightNode;

        /// <summary>
        /// Initializes a new instance of the DivisionNode with introduced left child and right child.
        /// </summary>
        /// <param name="leftNode">Left child of the DivisionNode</param>
        /// <param name="rightNode">Right child of the DivisionNode</param>
        public DivisionNode(INode leftNode, INode rightNode)
        {
            _leftNode = leftNode;
            _rightNode = rightNode;
        }
        
        public int Calculate()
        {
            return _leftNode.Calculate() / _rightNode.Calculate();
        }

        public string Print()
        {
            return $"(/ {_leftNode.Print()} {_rightNode.Print()})";
        }
    }
}