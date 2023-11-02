using kursovoy.StructureArray;
using kursovoy.StructureHash;
using kursovoy.StructureTree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursovoy
{
    public partial class Form1 : Form
    {
        string[] keys;
        Tree tree;
        HashTable hashTable;
        SortedArray sortedArray;
        public Form1()
        {
            InitializeComponent();
            string[] array = System.IO.File.ReadAllLines(@"C:\Users\Алексей\Desktop\дз\Курсовые\3 семестр СИАОД\words.txt");
            keys = System.IO.File.ReadAllLines(@"C:\Users\Алексей\Desktop\дз\Курсовые\3 семестр СИАОД\finded.txt");
            tree = new Tree();
            hashTable = new HashTable(array.Length - 1);
            sortedArray = new SortedArray(array.Length);
            foreach (string s in array)
            {
                tree.Insert(s);
                hashTable.Add(s,s);
                sortedArray.Add(s);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double finalTime=0;
            double finalCountComp=0;
            int finalCountOfFound=0;
            ResultDTO result1 = new ResultDTO(0,0,false);
            foreach (string word in keys)
            {
                result1 = tree.Search(word);
                finalTime += result1._time;
                finalCountComp += result1._avgNumberOfComparisons;
                if (result1._status) { finalCountOfFound++; }
            }
            finalTime = finalTime / keys.Length;
            finalCountComp = finalCountComp / keys.Length;
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataGridView1);
            row.HeaderCell.Value = "Дерево цифрового поиска";
            row.Cells[0].Value =finalTime.ToString();
            row.Cells[1].Value = finalCountComp;
            row.Cells[2].Value = finalCountOfFound;
            dataGridView1.Rows.Add(row);
            this.Refresh();
            finalTime = 0;
            finalCountComp = 0;
            finalCountOfFound = 0;
            ResultDTO result2 = new ResultDTO(0, 0, false);
            foreach (string word in keys)
            {
                result2 = hashTable.Get(word);
                finalTime += result2._time;
                finalCountComp += result2._avgNumberOfComparisons;
                if (result2._status) { finalCountOfFound++; }
            }
            finalTime = finalTime / keys.Length;
            finalCountComp = finalCountComp / keys.Length;
            DataGridViewRow row1 = new DataGridViewRow();
            row1.CreateCells(dataGridView1);
            row1.HeaderCell.Value = "Хеш-таблица";
            row1.Cells[0].Value = finalTime.ToString();
            row1.Cells[1].Value = finalCountComp.ToString();
            row1.Cells[2].Value = finalCountOfFound;
            dataGridView1.Rows.Add(row1);
            this.Refresh();
            finalTime = 0;
            finalCountComp = 0;
            finalCountOfFound = 0;
            ResultDTO result3 = sortedArray.search("алтынница");
            Console.WriteLine(result3._status);
            finalTime = finalTime / keys.Length;
            finalCountComp = finalCountComp / keys.Length;
            DataGridViewRow row2 = new DataGridViewRow();
            row2.CreateCells(dataGridView1);
            row2.HeaderCell.Value = "Сортированный массив";
            row2.Cells[0].Value = finalTime.ToString();
            row2.Cells[1].Value = finalCountComp.ToString();
            row2.Cells[2].Value = finalCountOfFound;
            dataGridView1.Rows.Add(row2);
            this.Refresh();


        }
    }
}
