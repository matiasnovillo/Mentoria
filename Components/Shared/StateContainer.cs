using Mentoria.Areas.CMS.UserBack.Entities;

namespace Mentoria.Components.Shared
{
    public class StateContainer
    {
        public User User { get; set; } = new User();

        public bool ShowOrHideSideNav { get; set; } = true;
    }
}
