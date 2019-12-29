using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pricero.Core.Db
{
    public class Thread
    {
        public int ThreadID { get; set; }
        public DateTime ThreadDate { get; set; }
        public string ThreadTitle { get; set; }


        public virtual Section Section { get; set; }
        public virtual ICollection<UserPost> UserPosts { get; set; }
    }
}