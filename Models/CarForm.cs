using System.ComponentModel.DataAnnotations;

namespace RollsRoyce.Models
{
    public class CarForm
    {
        [Key]
        public int id { get; set; }
        public string? model { get; set; }
        public string? name { get; set; }
        public string? price { get; set; }
        public string? body_style { get; set; }
        public string? seating_capacity { get; set; }
        public string? length { get; set; }
        public string? width { get; set; }
        public string? height { get; set; }
        public string? wheelbase { get; set; }
        public string? curb_weight { get; set; }
        public string? engine { get; set; }
        public string? power_output { get; set; }
        public string? torque { get; set; }
        public string? transmission { get; set; }
        public string? speed_in_second { get; set; }
        public string? top_speed { get; set; }
        public string? combined_fuel { get; set; }
        public string? suspension { get; set; }
        public string? brakes { get; set; }
        public string? wheels { get; set; }
        public string? infotainment { get; set; }
        public string? img1 { get; set; }
        public string? img2 { get; set; }
        public string? img3 { get; set; }
        public string? img4 { get; set; }
        public string? img5 { get; set; }
        public string? summary { get; set; }
        public string? short_desc { get; set; }
    }
}
