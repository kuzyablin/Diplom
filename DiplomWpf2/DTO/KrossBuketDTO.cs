namespace Diplom2.DTO
{
    public class KrossBuketDTO
    {
        public int IdKrossBuket { get; set; }

        public int IdBuket { get; set; }

        public int IdTovar { get; set; }

        public int? Kolvo { get; set; }
        public virtual TovarDTO IdTovarNavigation { get; set; } = null!;
        public virtual BuketDTO IdBuketNavigation { get; set; } = null!;
    }
}
