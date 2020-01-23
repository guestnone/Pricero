using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pricero.Core.Db
{
    public class Section
    {
        [Key]
        public int SectionID { get; set; }
        public DateTime SectionDate { get; set; }
        public string SectionTitle { get; set; }

        public virtual ICollection<ForumThread> Threads { get; set; }
    }
}