namespace WCF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Posts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Posts()
        {
            Replies = new HashSet<Replies>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(150)]
        public string title { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string body { get; set; }

        public int userId { get; set; }

        public int categoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Replies> Replies { get; set; }
    }
}
