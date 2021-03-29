﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private static Stack<Item> items;
       

        public Bag(int capacity)
        {
            Capacity = capacity;
            items = new Stack<Item>();
           
        }

        public int Capacity { get; set; } = 100;

        public int Load => items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => items.ToList().AsReadOnly();

        public void AddItem(Item item)
        {
            int size = item.Weight + Load;
            if (size >= Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            
            items.Push(item);
        }

        public Item GetItem(string name)
        {

            if (!items.Any())
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            if (!items.Any(x => x.GetType().Name == name))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            Item find = items.FirstOrDefault(x => x.GetType().Name == name);
            items.Pop();
            return find;
        }
    }
}
