using System.ComponentModel.DataAnnotations;

namespace RollsRoyce.Models
{
    public class ContactForm
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? number { get; set; }
        public string? email { get; set; }
        public string? msg { get; set; }
    }
}
