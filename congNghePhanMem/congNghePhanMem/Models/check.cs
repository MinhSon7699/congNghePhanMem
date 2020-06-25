namespace congNghePhanMem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("congnghephanmem.check")]
    public partial class check
    {
        public int Id { get; set; }

        public int? IdInformation { get; set; }

        [Column("check")]
        public int? check1 { get; set; }

        public int? dayWork { get; set; }

        public virtual information information { get; set; }
    }
}
