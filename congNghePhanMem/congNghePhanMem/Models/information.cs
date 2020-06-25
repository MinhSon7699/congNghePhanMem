namespace congNghePhanMem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("congnghephanmem.information")]
    public partial class information
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public information()
        {
            checks = new HashSet<check>();
        }

        public int Id { get; set; }

        [StringLength(45)]
        public string name { get; set; }

        [StringLength(200)]
        public string address { get; set; }

        public DateTime? birthDay { get; set; }

        public int? gender { get; set; }

        public decimal? salary { get; set; }

        public int? block { get; set; }

        public int IdWork { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<check> checks { get; set; }
    }
}
