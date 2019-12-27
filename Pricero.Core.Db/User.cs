using System;
using System.Collections.Generic;
using System.Text;

namespace Pricero.Core.Db
{
    public enum UserType
    {
        Normal,
        Moderator,
        Administrator
    }

    public class User
    {
        public Guid UserId { get; set; }
        public string NickName { get; set; }
        public string EMail { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordInitValue { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType UserType { get; set; }

        // Relations
        public ForumPost Post { get; set; }
    }
}
