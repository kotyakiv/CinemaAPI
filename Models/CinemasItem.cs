namespace CinemaAPI.Models
{
    public class CinemasItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public required int OpeningHour { get; set; }
        public required int ClosingHour { get; set; }
        public required int ShowDuration { get; set; }
    }
}
