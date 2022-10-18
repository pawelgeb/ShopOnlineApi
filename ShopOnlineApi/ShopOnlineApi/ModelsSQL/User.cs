using System;
using System.Collections.Generic;

namespace ShopOnlineApi.ModelsSQL
{
    public partial class User
    {
        public int Id { get; set; } = 0;
        public string? Name { get; set; }
        public DateTime? RegisterDate { get; set; }
        public virtual Adress? Adress { get; set; }
        public virtual Contact? Contact { get; set; }
    }
}
