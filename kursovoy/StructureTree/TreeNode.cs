using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovoy.StructureTree
{
    internal class TreeNode
    {
            public char Value { get; }
            public Dictionary<char, TreeNode> Children { get; }
            public bool IsEndOfWord { get; set; }

            public TreeNode(char value)
            {
                Value = value;
                Children = new Dictionary<char, TreeNode>();
                IsEndOfWord = false;
            }
        }
}
