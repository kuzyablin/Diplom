namespace Diplom2.DTO
{
    public class KrossRaspisanie
    {
        public int IdKrossRaspisanie { get; set; }

        public int? IdSotrud { get; set; }

        public int? IdRaspisanie { get; set; }

        public virtual RaspisanieDTO? IdRaspisanieNavigation { get; set; }

        public virtual SotrudDTO? IdSotrudNavigation { get; set; }
    }
}
