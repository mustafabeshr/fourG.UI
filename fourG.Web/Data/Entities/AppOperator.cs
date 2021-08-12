using System;
using System.Collections.Generic;
using System.Text;

namespace fourG.Web.Data.Entities
{
    public class AppOperator
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public AppRole Role { get; set; }
        public int Status { get; set; }
        public string Secret { get; set; }
        public string SecretKey { get; set; }
        public int Attempts { get; set; } 
        public DateTime CreatedOn { get; set; }
        public DateTime StatusChangedOn { get; set; }
        public DateTime LastLoggedOn { get; set; }
        public DateTime LockedTo { get; set; }
    }
}
