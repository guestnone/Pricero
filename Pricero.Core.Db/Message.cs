using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindDiscount.Models
{
    public class Message
    {
        public int MessageID { get; set; }

        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }

        public virtual User MessageSender { get; set; }
        public virtual User MessageReceiver { get; set; }
    }
}