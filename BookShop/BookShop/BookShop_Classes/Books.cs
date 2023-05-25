namespace BookShop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Books
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Books()
        {
            Sales = new HashSet<Sales>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Pages { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime PublishDate { get; set; }

        public int AuthorId { get; set; }

        public int ThemeId { get; set; }

        public virtual Authors Authors { get; set; }

        public virtual Themes Themes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
