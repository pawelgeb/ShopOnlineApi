using System;
using System.Collections.Generic;

namespace ShopOnlineApi.ModelsSQL
{
    public partial class CategoryDTO
    {
        public CategoryDTO()
        {
            
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? AddData { get; set; }
        public bool? Empty { get; set; }
        
    }
}
