namespace autokolcsonzo.Models
{
    public class kolcsonzesek
    {
        public int Id { get; set; }
        public int ugyfelid { get; set; }
        public ugyfelek ugyfelek { get; set; }
        public int autoid { get; set; }
        public autok autok { get; set; }
        public DateTime kezdes { get; set; }
        public DateTime vegzes { get; set; }
    }
}
