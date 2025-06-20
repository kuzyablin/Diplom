namespace Diplom2.DTO
{
    public class SotrudDTO
    {
        public int IdSotrud { get; set; }

        public string ParolSotrud { get; set; } = null!;

        public string LoginSotrud { get; set; } = null!;

        public string? NameSotrud { get; set; }

        public string? Surname { get; set; }

        public string? Familia { get; set; }

        public int? IdRole { get; set; }



        public virtual RoleDTO? IdRoleNavigation { get; set; }

    }
}
