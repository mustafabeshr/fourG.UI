using System;
using System.Collections.Generic;
using System.Text;

namespace fourG.Web.Data.Entities
{
    public class SMSReceiver
    {
        public int Id { get; set; }
        public string MobileNo { get; set; }
        public string Message { get; set; }
        public string Shortcode { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
