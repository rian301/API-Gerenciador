using System.Collections.Generic;

namespace Black.API.Admin.ViewModels
{
    public class UserProfileViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public virtual IList<UserProfilePermissionViewModel> Permissions { get; set; }

        public UserProfileViewModel()
        {
            Permissions = new List<UserProfilePermissionViewModel>();
        }
    }
}
