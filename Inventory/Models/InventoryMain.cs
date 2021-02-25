using System;

namespace Inventory.Models
{
    public class InventoryMain
    {
        public int LocationID { get; set; }
        public int ItemID { get; set; }
        public int ExpectedCount { get; set; }
        public int ActualCount { get; set; }
        public DateTime ItemLastUpdated { get; set; }

        public Location location { get; set; }
        public Item item { get; set; }
    }
}
