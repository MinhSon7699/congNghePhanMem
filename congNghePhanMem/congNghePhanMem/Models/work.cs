namespace congNghePhanMem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("congnghephanmem.work")]
    public partial class work
    {
        public int Id { get; set; }

        public DateTime? dateWork { get; set; }

        public DateTime? dateOut { get; set; }

        [StringLength(45)]
        public string nameEmployee { get; set; }

        [StringLength(45)]
        public string position { get; set; }

        [StringLength(45)]
        public string department { get; set; }
    }
}
