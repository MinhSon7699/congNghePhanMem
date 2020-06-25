namespace congNghePhanMem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("congnghephanmem.register")]
    public partial class register
    {
        public int Id { get; set; }

        [StringLength(45)]
        public string name { get; set; }

        [StringLength(45)]
        public string userName { get; set; }

        [StringLength(45)]
        public string email { get; set; }

        [StringLength(45)]
        public string passWord { get; set; }

        [StringLength(45)]
        public string phone { get; set; }

        [StringLength(45)]
        public string address { get; set; }

        public int? permision { get; set; }

        [Column(TypeName = "bit")]
        public bool? status { get; set; }
    }
}
