using System;
using System.Collections.Generic;
using System.IO;

namespace FrozenFive
{
    class Program
    {
        class Item
        {
            string name;
            string item;
            int price;

            public Item(string _name, string _item, int _price)
            {
                name = _name;
                item = _item;
                price = _price;
            }

            public string Name { get { return name; } }

            public string ChristmasItem { get { return item; } }

            public int Price { get { return price; } }

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


            public void AddItemsToList(string name, string item, int price)
            {
                Item newItem = new Item(name, item, price);
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
            string fileName = @"frozenII.txt";
            string fullFilePath = Path.Combine(filePath, fileName);

            string[] linesfromFile = File.ReadAllLines(fullFilePath);

            ItemList myItems = new ItemList();

            foreach (string line in linesfromFile)
            {
                string[] tempArray = line.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                string firstName = tempArray[0];
                string firstItem = tempArray[1];
                int firstPrice = int.Parse(tempArray[2]);


                myItems.AddItemsToList(firstName, firstItem, firstPrice);

                Console.WriteLine($"{firstName} wants {firstItem} for Christmas.");
            }

        }
    }
}