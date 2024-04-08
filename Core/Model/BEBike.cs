using System;
namespace Core.Model
{
    public class BEBike
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; } = 0;
        public string? ImageUrl { get; set; } = string.Empty;
    }
}

