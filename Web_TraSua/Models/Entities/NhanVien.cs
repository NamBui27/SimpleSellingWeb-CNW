namespace Web_TraSua.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        public int manv { get; set; }

        [StringLength(50)]
        public string tennv { get; set; }

        [StringLength(50)]
        public string taikhoannv { get; set; }

        [StringLength(50)]
        public string matkhaunv { get; set; }
    }
}
