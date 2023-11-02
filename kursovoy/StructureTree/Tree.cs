using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursovoy.StructureTree
{
    internal class Tree
    {
        private TreeNode root;
        public Tree()
        {
            root = new TreeNode(' ');
        }

        // Метод для вставки слова в дерево
        public void Insert(string word)
        {
            var current = root;

            foreach (var c in word)
            {
                if (!current.Children.ContainsKey(c))
                {
                    current.Children[c] = new TreeNode(c);
                }
                current = current.Children[c];
            }

            current.IsEndOfWord = true;
        }

        // Метод для поиска слова в дереве
        public ResultDTO Search(string word)
        {
            int count=0;
            bool status;
            int start = Environment.TickCount;
            int end;
            var current = root;

            foreach (var c in word)
            {
                count++;
                if (!current.Children.ContainsKey(c))
                {
                    return new ResultDTO(Environment.TickCount-start, count, false );
                }
                current = current.Children[c];
            }
            end = Environment.TickCount-start;
            status = current.IsEndOfWord;
            return new ResultDTO(end, count, status);
        }

        // Метод для проверки, существуют ли слова, начинающиеся с заданного префикса
        public bool StartsWith(string prefix)
        {
            var current = root;

            foreach (var c in prefix)
            {
                if (!current.Children.ContainsKey(c))
                {
                    return false;
                }
                current = current.Children[c];
            }

            return true;
        }
    }
}
