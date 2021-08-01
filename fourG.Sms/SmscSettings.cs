using System;
using System.Collections.Generic;
using System.Text;

namespace fourG.Sms
{
   
        
        public class SMSCReceiverSettings
        {
            public string Server { get; set; }
            public string Port { get; set; }
            public string SystemId { get; set; }
            public string Password { get; set; }
            public string Count { get; set; }
            public string Shortcode { get; set; }
    }
        public class SMSCSenderSettings
        {
            public string Server { get; set; }
            public string Port { get; set; }
            public string SystemId { get; set; }
            public string Password { get; set; }
            public string Count { get; set; }
            public string Shortcode { get; set; }
        }
    
}
