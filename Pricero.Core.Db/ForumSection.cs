using System;
using System.Collections.Generic;
using System.Text;

namespace Pricero.Core.Db
{
    public class ForumSection
    {
        public Guid SectionId { get; set; }
        public DateTime SectionCreationDate { get; set; }
        public string SectionTitle { get; set; }
    }
}
