namespace autokolcsonzo.Models
{
    public class ugyfelek
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string email { get; set; }
        public List<kolcsonzesek> kolcsonzesek { get; set; }
    }
}
