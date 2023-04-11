using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Infra.Data.Context;
using Black.Repository.Implement.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Repository.Implement
{
    public class UserProfileRepository : RepositoryBaseCRUD<UserProfile, int>, IUserProfileRepository
    {
        #region Constructors
        public UserProfileRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }
        #endregion

        #region Methods
        public override IEnumerable<UserProfile> GetAll()
        {
            return Context.UserProfile.OrderBy(x => x.Name).ToList();
        }

        public override Task<UserProfile> GetByIdAsync(int id)
        {
            return Context.UserProfile
                .Include(x => x.Permissions)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        
        #endregion
    }
}
