namespace RetailerApp.Models
{
    public class UserRule
    {
        public int Uid { get; set; }
        public User User { get; set; } = new User();
        public string Menu { get; set; }
        public string Access { get; set; }
    }
}