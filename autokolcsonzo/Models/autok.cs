namespace autokolcsonzo.Models
{
    public class autok
    {
        public int Id { get; set; }
        public string marka { get; set; }
        public string tipus { get; set; }
        public int ev { get; set; }
        public decimal arnaponta { get; set; }
        public List<kolcsonzesek> kolcsonzesek { get; set; }
    }
}
