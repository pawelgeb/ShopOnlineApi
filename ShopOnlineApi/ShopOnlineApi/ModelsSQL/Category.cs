using System;
using System.Collections.Generic;

namespace ShopOnlineApi.ModelsSQL
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public DateOnly? AddData { get; set; }
        public bool? Empty { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
