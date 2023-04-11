using Microsoft.AspNetCore.Identity;
using Black.Domain.Core.Models;
using Black.Infra.CrossCutting.Common.String;
using System;

namespace Black.Infra.CrossCutting.Identity
{
    public class User : IdentityUser<int>
    {
        #region Properties
        public string Name { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
        public int? UserProfileId { get; private set; }

        #endregion

        #region Constructors
        protected User()
        {
        }

        public User(string name, string email, string username, int? userProfileId = null)
        {
            SetName(name);
            SetEmail(email);
            UserName = username;
            UserProfileId = userProfileId;
            SetStatus(true);
            CreatedAt = DateTime.Now;
        }

        #endregion

        #region Methods

        public void Update(string name, string email, bool active, int? userProfileId)
        {
            SetName(name);
            SetEmail(email);
            SetStatus(active);
            UserProfileId = userProfileId;
        }

        #endregion
        

        #region Methods
        public void SetName(string name) { Name = name; }
        public void SetEmail(string email) { Email = email; }
        public void SetPhoneNumber(string phoneNumber) { PhoneNumber = phoneNumber.RemoverCaracterMascara(); }
        public CommandResult SetStatus(bool status)
        {
            Active = status;
            return new CommandResult(true);
        }
        #endregion
    }
}
