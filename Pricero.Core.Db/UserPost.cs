﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindDiscount.Models
{
    public class UserPost
    {
        public int PostID { get; set; }
        public DateTime PostDate { get; set; }
        public string PostContent { get; set; }
        

        public virtual Thread Thread { get; set; }
        public virtual User User { get; set; }
    }
}