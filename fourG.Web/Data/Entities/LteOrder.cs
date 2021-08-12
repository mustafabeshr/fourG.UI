using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fourG.Web.Data.Entities
{
    public class LteOrder
    {
        public int Id { get; set; }
        public string MobileNo { get; set; }
        public bool IsExist { get; set; }
        public int OrderType { get; set; }
        public DateTime ExpiredOn { get; set; }
        public int Postpaid { get; set; }
        public string IMSI { get; set; }
        public string IMSIPassword { get; set; }
        public string PackageId { get; set; }
        public string AlterPackageId { get; set; }
        public int PackageValidity { get; set; }
        public string OfferId { get; set; }
        public int Status { get; set; }
        public int AAAStatus { get; set; }
        public int PRLStatus { get; set; }
        public int CRMStatus { get; set; }
        public int HSSStatus { get; set; }
        public string Channel { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ClosedOn { get; set; }
        public string Note { get; set; }

    }

    public class LteOrderHistory : LteOrder
    {

    }
}
