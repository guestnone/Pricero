using System;
using System.Collections.Generic;
using System.Text;

namespace Pricero.Core.Db
{
    public class ForumPost
    {
        public Guid PostId { get; set; }
        public DateTime PostDate { get; set; }
        public string PostContent { get; set; }

        // Relations
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ThreadId { get; set; }
        public ForumThread Thread { get; set; }

    }
}
