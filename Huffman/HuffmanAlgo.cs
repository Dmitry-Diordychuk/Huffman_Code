using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;

namespace Huffman
{
    public static class HuffmanAlgo
    {
        public static List<char> CharSetList = new List<char>();
        public static List<BinaryTree.Node> Nodes = new List<BinaryTree.Node>();
        public static List<BinaryTree.Tree> Trees = new List<BinaryTree.Tree>();
        public static BinaryTree.Tree HuffmanTree;
        public static void SetElements()
        {
            if (CharSetList.Count > 0)
            {
                List<char> elements = CharSetList.Distinct().ToList();
                foreach (var el in elements)
                {
                    Nodes.Add( new BinaryTree.Node(el,-1) );
                }
            }
        }
        public static void FindWeights()
        {
            foreach (var node in Nodes)
            {
                int count = 0;
                foreach (var letter in CharSetList)
                {
                    if( node.Symbol == letter )
                        count++;
                }
                node.Weight = count;
            }
            Nodes = Nodes.OrderBy( x => x.Weight ).ToList();
        }
        public static void SetTrees()
        {
            foreach (var node in Nodes)
            {
                Trees.Add(new BinaryTree.Tree(node));
            }
        }
        public static BinaryTree.Tree MergeTrees()
        {
            List<BinaryTree.Tree> result = new List<BinaryTree.Tree>();

            do
            {
                result.Clear();
                for( int i = 0; i < Trees.Count; i++ )
                {
                    if( i + 1 < Trees.Count )
                    {
                        result.Add( new BinaryTree.Tree( Trees[i], Trees[i + 1] ) );
                        i++;
                    }
                    else if( i < Trees.Count )
                        result.Add( Trees[i] );
                }
                Trees = new List<BinaryTree.Tree>(result);
            } while( result.Count > 1 );
            return ( result.Last() );
        }
        public static void Init(MyFile myFile)
        {
            CharSetList = myFile.ToString().ToCharArray().ToList();
            SetElements();
            FindWeights();
            SetTrees();
            HuffmanTree = MergeTrees();
            GetCodes(HuffmanTree.Root, new List<char>());
            CodeText(myFile);
        }
        public static void GetCodes( BinaryTree.Node node, List<char> code )
        {
            if (node.Left == null && node.Right == null)
            {
                node.Code = code;
                return ;
            }
            if (node.Left != null)
            {
                List<char> next = new List<char>( code )
                {
                    '0'
                };
                GetCodes( node.Left, next );
            }
            if (node.Right != null)
            {
                List<char> next = new List<char>( code )
                {
                    '1'
                };
                GetCodes( node.Right, next );
            }
        }
        public static void CodeText(MyFile myFile)
        { 
            using (StreamWriter writer = new StreamWriter("./codedText.txt"))
            {
                using (StreamReader reader = new StreamReader(myFile.Path))
                {
                    while (reader.Peek() > 0)
                    {
                        char cur = (char)reader.Read();
                        writer.Write(new string(Nodes.Find(c => c.Symbol == cur).Code.ToArray()));
                    }
                }
            }
        }
    }
}
