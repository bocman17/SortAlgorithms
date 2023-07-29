using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.HelperClasses
{
    public class TrieNode
    {
        public int Value;
        public TrieNode[] Children = new TrieNode[2];
    }
}
