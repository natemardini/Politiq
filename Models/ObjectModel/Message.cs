using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Politiq.Models.ObjectModel
{
    public class Message
    {
        public int MessageID { get; set; }

        public virtual Member From { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public DateTime Created_At { get; set; }

        public DateTime Updated_At { get; set; }
    }

    public class Private_Message : Message
    {
        [Key]
        public int PrivateMsgID { get; set; }

        public virtual Member To { get; set; }
    }
}