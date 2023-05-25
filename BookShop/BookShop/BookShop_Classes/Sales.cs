namespace BookShop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sales
    {
        public int Id { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime SaleDate { get; set; }

        public int BookId { get; set; }

        public int ShopId { get; set; }

        public virtual Books Books { get; set; }

        public virtual Shops Shops { get; set; }
    }
}
