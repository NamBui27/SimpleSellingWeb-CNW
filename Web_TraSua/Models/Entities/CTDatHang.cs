namespace Web_TraSua.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTDatHang")]
    public partial class CTDatHang
    {
        [Key]
        public int mactdh { get; set; }

        public int madh { get; set; }

        public int? mats { get; set; }

        public int? soluong { get; set; }

        public decimal? dongia { get; set; }

        public decimal? thanhtien { get; set; }

        public virtual DatHang DatHang { get; set; }

        public virtual TraSua TraSua { get; set; }
    }
}
