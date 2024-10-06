using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Data.Models
{
    [Comment("mapping table between Gamer and Game")]
    public class GamerGame
    {
        [Comment("Game Identifier")]
        public int GameId { get; set; }

        [Comment("Game Property")]
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;

        [Comment("Gamer Identifier")]
        public string GamerId { get; set; } = null!;

        [Comment("Gamer Property")]
        [ForeignKey(nameof(GamerId))]
        public IdentityUser Gamer { get; set; } = null!;
    }
}
