using System;
using System.Collections.Generic;
using System.Text;

namespace fourG.UI.Data.Entities { 
    public class MessageSpool
    {
        public int Id { get; set; }
        public string MobileNo { get; set; }
        public string Message { get; set; }
        public string Shortcode { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Status { get; set; }

    }

    public class MessageSpoolHistory
    {
        public int Id { get; set; }
        public string MobileNo { get; set; }
        public string Message { get; set; }
        public string Shortcode { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime BackedupOn { get; set; }
        public int Status { get; set; }

    }
}
