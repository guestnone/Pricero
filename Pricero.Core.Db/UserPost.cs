using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pricero.Core.Db
{
    public class UserPost
    {
        public int PostID { get; set; }
        public DateTime PostDate { get; set; }
        public string PostContent { get; set; }
        

        public virtual ForumThread Thread { get; set; }
        public virtual User User { get; set; }
    }
}