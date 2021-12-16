namespace RetailerApp.Models
{
    public class Inventory
    {
        public int Uid { get; set; }
        public User Users { get; set; } = new User();
        public string LogDate { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}