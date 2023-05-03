namespace CinemaAPI.Models
{
    public class CinemasItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public int OpeningHour { get; set; }
        public int ClosingHour { get; set; }
        public int ShowDuration { get; set; }
    }
}
