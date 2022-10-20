using System;
using System.Collections.Generic;

namespace ShopOnlineApi.ModelsSQL
{
    public partial class OrderDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Price { get; set; }
        public int? ProductId { get; set; }

    }
}