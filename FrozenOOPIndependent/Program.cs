using System;
using System.Collections.Generic;
using System.IO;

namespace FrozenOOPIndependent
{
    class Program
    {
        class Item
        {
            string name;
            string item;

            public Item(string _name, string _item)
            {
                name = _name;
                item = _item;
            }

            public string Name { get { return name; } }

            public string ChristmasItem { get { return item; } }

        }

        class ItemList
        {
            List<Item> items;
            int totalitemlist;


            public ItemList()
            {
                items = new List<Item>();
                totalitemlist = 0;
            }

            public void AddItemsToList(string name, string item)
            {
                Item newItem = new Item(name, item);
                items.Add(newItem);
            }

            public void PrintAllItems()
            {
                foreach (Item movie in items)
                {
                    Console.WriteLine($"{movie.Name} wants {movie.ChristmasItem}");
                }
            }
        }
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\opilane\samples";
            string fileName = @"frozenI.txt";
            string fullFilePath = Path.Combine(filePath, fileName);

            string[] linesfromFile = File.ReadAllLines(fullFilePath);

            ItemList myItems = new ItemList();

            foreach (string line in linesfromFile)
            {
                string[] tempArray = line.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                string firstName = tempArray[0];
                string firstItem = tempArray[1];


                myItems.AddItemsToList(firstName, firstItem);

                Console.WriteLine($"{firstName} wants {firstItem} for Christmas.");
            }
        }
    }
}