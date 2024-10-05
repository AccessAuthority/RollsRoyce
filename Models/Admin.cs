using System.ComponentModel.DataAnnotations;

namespace RollsRoyce.Models
{
    public class Admin
    {
        [Key]
        public int id { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
    }
}
