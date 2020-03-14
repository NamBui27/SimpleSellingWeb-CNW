using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_TraSua.Models.Entities
{
    public class Item
    {     

        public int id { get; set; }

        public string image { get; set; }

        public string name { get; set; }

        public double price { get; set; }

        public int amount { get; set; }
    }
}