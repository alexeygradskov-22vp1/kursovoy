using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovoy.StructureHash
{
    internal class HashTableEntry
    {
        public string Key { get; }
        public string Value { get; }

        public HashTableEntry(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
