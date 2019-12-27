using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Pricero.Core.Db
{
    public class ForumThread
    {
        public Guid ThreadId { get; set; }
        public DateTime ThreadDate { get; set; }
        public string ThreadTitle { get; set; }

        public ForumSection Section { get; set; }

    }
}
