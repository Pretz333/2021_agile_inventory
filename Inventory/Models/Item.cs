using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        [Range(1, 100)]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
    }
}
