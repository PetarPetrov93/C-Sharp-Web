namespace GameZone.Models
{
    public class AllGamesViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string Publisher { get; set; } = null!;

        public string ReleasedOn { get; set; } = null!;

        public string Genre { get; set; } = null!;
    }
}
