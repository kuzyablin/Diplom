namespace Diplom2.DTO
{
    public class BuketDTO
    {
        public int IdBuket { get; set; }

        public byte[]? ImageBuket { get; set; }
        public decimal? PriceBuket { get; set; }
        public DateTime? DeleteAt { get; set; }
        public string? NameBuket { get; set; }

        public int? Stock { get; set; }
        public List<TovarDTO> Tovars { get; set; } = new();

    }
}
