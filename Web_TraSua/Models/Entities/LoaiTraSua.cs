namespace Web_TraSua.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiTraSua")]
    public partial class LoaiTraSua
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiTraSua()
        {
            TraSuas = new HashSet<TraSua>();
        }

        [Key]
        public int maloai { get; set; }

        [StringLength(100)]
        public string tenloai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TraSua> TraSuas { get; set; }
    }
}
