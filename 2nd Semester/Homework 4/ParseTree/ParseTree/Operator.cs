using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree
{
    internal class Operator : INode
    {
        public INode? LeftChild { get; set; }

        public INode? RightChild { get; set; }

        public INode? Parent { get; set; }

        public char OperatorChar { get; set; }

        public double Evaluate()
        {
            switch (OperatorChar)
            {
                case '+':
                    return LeftChild.Evaluate() + RightChild.Evaluate();
                    break;
                case '-':
                    return LeftChild.Evaluate() - RightChild.Evaluate();
                    break;
                case '*':
                    return LeftChild.Evaluate() * RightChild.Evaluate();
                    break;
                case '/':
                    return LeftChild.Evaluate() / RightChild.Evaluate();
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
