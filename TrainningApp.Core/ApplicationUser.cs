using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainningApp.Core
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public float? Heigth { get; set; }
        public string? Gender { get; set; }
        public float? Weight { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [Column("disabled_at")]
        public DateTime? DisabledAt { get; set; }

    }
}
