using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeskMarket.Data.Models
{
    public class ProductClient
    {
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        public string ClientId { get; set; } = null!;

        [ForeignKey(nameof(ClientId))]
        public IdentityUser Client { get; set; } = null!;
    }
}
