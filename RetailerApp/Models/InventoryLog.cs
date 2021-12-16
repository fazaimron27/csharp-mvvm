namespace RetailerApp.Models
{
    public class InventoryLog
    {
        public int Uid { get; set; }
        public Inventory Inventories { get; set; } = new Inventory();
        public Product Products { get; set; } = new Product();
        public int Qty { get; set; }
    }
}