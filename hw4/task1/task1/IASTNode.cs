using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    /// <summary>
    /// interface of the AST node
    /// </summary>
    public interface IASTNode
    {
        /// <summary>
        /// evaluates the node
        /// </summary>
        /// <returns>the result of the evaluation</returns>
        double Evaluate();
        /// <summary>
        /// converts subtree of the node to string
        /// </summary>
        /// <returns>subtree converted to string</returns>
        string ToString();
    }
}
