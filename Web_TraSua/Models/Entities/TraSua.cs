namespace Web_TraSua.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TraSua")]
    public partial class TraSua
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TraSua()
        {
            CTDatHangs = new HashSet<CTDatHang>();
        }

        [Key]
        public int mats { get; set; }

        public int? maloai { get; set; }

        [StringLength(100)]
        public string tents { get; set; }

        [StringLength(50)]
        public string huongvi { get; set; }

        [StringLength(5)]
        public string size { get; set; }

        public decimal? dongia { get; set; }

        [StringLength(100)]
        public string anhts { get; set; }

        [StringLength(500)]
        public string ghichu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDatHang> CTDatHangs { get; set; }

        public virtual LoaiTraSua LoaiTraSua { get; set; }
    }
}
