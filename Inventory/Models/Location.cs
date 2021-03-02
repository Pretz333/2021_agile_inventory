using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Inventory.Models
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        public string Description { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
