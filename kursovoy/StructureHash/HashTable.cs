using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovoy.StructureHash
{
    internal class HashTable
    {
        private int TableSize; // Размер таблицы
        private List<HashTableEntry>[] table;

        public HashTable(int size)
        {
            TableSize = size;
            table = new List<HashTableEntry>[size];
        }

        // Метод для вычисления хеша строки
        private int CalculateHash(string key)
        {
            int hash = 0;
            foreach (char c in key)
            {
                hash += (int)c;
            }
            return hash % TableSize;
        }

        // Метод для добавления записи в таблицу
        public void Add(string key, string value)
        {
            int hash = CalculateHash(key);
            if (table[hash] == null)
            {
                table[hash] = new List<HashTableEntry>();
            }
            table[hash].Add(new HashTableEntry(key, value));
        }

        // Метод для поиска записи по ключу
        public ResultDTO Get(string key)
        {
            int start = Environment.TickCount;
            int count = 0;
            bool status = false;
            int hash = CalculateHash(key);
            var bucket = table[hash];
            if (bucket != null)
            {
                foreach (var entry in bucket)
                {
                    count++;
                    if (entry.Key == key)
                    {
                        status = true;
                         break;
                    }
                }
            }
            int end = Environment.TickCount-start;
            return new ResultDTO(count, end, status);
        }
    }
}
