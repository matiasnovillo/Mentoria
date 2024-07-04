using Mentoria.Areas.CMS.MenuBack.Entities;

namespace Mentoria.Areas.CMS.MenuBack.DTOs
{
    public class menuWithStateDTO : Menu
    {
        public bool IsSelected { get; set; }
    }
}
