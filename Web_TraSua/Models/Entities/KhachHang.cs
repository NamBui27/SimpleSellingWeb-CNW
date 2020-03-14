namespace Web_TraSua.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DatHangs = new HashSet<DatHang>();
        }

        [Key]
        public int makh { get; set; }

        [StringLength(50)]
        public string hotenkh { get; set; }

        [StringLength(500)]
        public string diachi { get; set; }

        [StringLength(15)]
        public string sdt { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(100)]
        public string taikhoan { get; set; }

        [StringLength(50)]
        public string matkhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatHang> DatHangs { get; set; }
    }
}
