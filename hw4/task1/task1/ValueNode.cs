namespace Task1
{
    /// <summary>
    /// value node of AST tree, implements IASTNode interface, stores integer value
    /// </summary>
    public class ValueNode : IASTNode
    {
        private int value { get; }

        public ValueNode(int value) => this.value = value;

        /// <summary>
        /// returns stored value
        /// </summary>
        /// <returns>stored value</returns>
        public double Evaluate() => value;

        /// <summary>
        /// converts its value to string
        /// </summary>
        /// <returns>value in a string</returns>
        public override string ToString() => value.ToString();
    }
}
