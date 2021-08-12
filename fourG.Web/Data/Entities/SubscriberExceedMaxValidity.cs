using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fourG.Web.Data.Entities
{
    public class SubscriberExceedMaxValidity
    {
        public int Id { get; set; }
        public string MobileNo { get; set; }
        public string PackageId { get; set; }
        public string PackageName { get; set; }
        public int OperationType { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
