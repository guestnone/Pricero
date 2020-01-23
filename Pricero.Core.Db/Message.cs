using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pricero.Core.Db
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        public int MessageSenderId { get; set; }
        public int MessageReceiverId { get; set; }

        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }

        // TODO: Adrian, can you fix it?
        public User MessageSender { get; set; }
        public User MessageReceiver { get; set; }
    }
}