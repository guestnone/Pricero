using System;
using System.Collections.Generic;
using System.Text;

namespace Pricero.Core.Db
{
    public class PrivateMessage
    {
        public Guid MessageId { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
        public Guid MessageSenderId { get; set; }
        public Guid MessageRecieverId { get; set; }
    }
}
