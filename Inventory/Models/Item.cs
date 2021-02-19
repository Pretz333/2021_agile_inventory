using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }

    }
}
