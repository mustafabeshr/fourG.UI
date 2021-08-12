using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fourG.Web.Data.Entities
{
    public class Subscriber
    {
        public int Id { get; set; }
        public string MobileNo { get; set; }
        public string IMSI { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime ExpiredOn { get; set; }
        public int Status { get; set; }
        public DateTime LastPackageOn { get; set; }
        public string LastPackageId { get; set; }
        public string LastPackageName { get; set; }
        public int AAAStatus { get; set; }
        public int HSSStatus { get; set; }
    }
}
