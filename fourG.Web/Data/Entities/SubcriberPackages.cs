using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fourG.Web.Data.Entities
{
    public class SubscriberPackage
    {
        public int Id { get; set; }
        public string MobileNo { get; set; }
        public string PackageId { get; set; }
        public string PackageName { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime ExpiredOn { get; set; }
        public int Status { get; set; }
    }

    public class SubscriberPackageHistory : SubscriberPackage
    {
        public DateTime DeactivatedOn { get; set; }
    }
}
