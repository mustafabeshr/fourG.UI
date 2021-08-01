using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fourG.Data
{
    public class SubscriberExceedMaxValidity
    {
        public int Id { get; set; }
        public string MobileNo { get; set; }
        public SubscriberPackage Package { get; set; }
        public int OperationType { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
