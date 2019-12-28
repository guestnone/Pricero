using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindDiscount.Models
{
    public class Section
    {
        public int SectionID { get; set; }
        public DateTime SectionDate { get; set; }
        public string SectionTitle { get; set; }

        public virtual ICollection<Thread> Threads { get; set; }
    }
}