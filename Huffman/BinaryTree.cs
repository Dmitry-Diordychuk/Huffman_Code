using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Huffman
{
    public class BinaryTree
    {
        public class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public char Symbol { get; set; }
            public int  Weight { get; set; }
            public List<char> Code { get; set; }
            public Node( char symbol, int weight )
            {
                this.Symbol = symbol;
                this.Weight = weight;
            }
        }
        public class Tree
        {
            public Node Root;

            public Tree()
            {
                Root = null;
            }
            public Tree(Node node)
            {
                Root = node;
            }
            public Tree(Tree left, Tree right)
            {
                Root = new Node((char)0, left.Root.Weight + right.Root.Weight );
                Root.Left = left.Root;
                Root.Right = right.Root;
            }
        }
    }
}
