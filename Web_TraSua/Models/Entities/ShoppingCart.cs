using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_TraSua.Models.Entities
{
    public class ShoppingCart
    {
        public List<Item> lst = new List<Item>();

        public void InsertItem(int id, string image, string name, double price)
        {
            bool check = false;
            foreach (Item item in lst)
            {
                if (item.id == id)
                {
                    check = true;
                    item.amount += 1;
                    break;
                }
            }
            if (!check)
            {
                Item item = new Item();
                item.id = id;
                item.amount = 1;
                item.price = price;
                item.image = image;
                item.name = name;
                lst.Add(item);
            }
        }
        public void UpdateAmount(int id, int amount)
        {
            foreach (Item item in lst)
            {
                if (item.id == id)
                {
                    if(amount > 0)
                    {
                        item.amount = amount;
                    }
                    else
                    {
                        lst.Remove(item);
                    }
                }
            }
        }
        public void RemoveItem(int id)
        {
            for (int i=lst.Count -1; i>=0; i--)
            {
                if (lst.ElementAt(i).id == id)
                {
                    lst.RemoveAt(i);
                }
            }
        }

        public int GetTotal()
        {
            int total = 0;
            foreach (Item item in lst)
            {
                total += item.amount;              
            }
            return total;
        }

        public double GetTotalMoney()
        {
            double total = 0;
            foreach (Item item in lst)
            {
                total += item.amount * item.price;
            }
            return total;
        }

        public double GetMoney(Item item)
        {
            return item.amount * item.price;
        }
    }
}
