using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_TraSua.Models.Entities
{
    public class CTSanPham
    {
        public int mats { get; set; }

        public string tents { get; set; }
        
        public string anhts { get; set; }

        public decimal dongia { get; set; }

        public int maloai { get; set; }

        public string tenloai { get; set; }
        public string huongvi { get; set; }
        public string size { get; set; }
        public string ghichu { get; set; }
    }
}