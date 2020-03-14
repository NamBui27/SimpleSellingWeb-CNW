namespace Web_TraSua.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatHang")]
    public partial class DatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DatHang()
        {
            CTDatHangs = new HashSet<CTDatHang>();
        }

        [Key]
        public int madh { get; set; }

        public int? makh { get; set; }

        public decimal? tongtien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaytao { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDatHang> CTDatHangs { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
