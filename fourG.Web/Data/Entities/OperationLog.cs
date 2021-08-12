using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fourG.Web.Data.Entities
{
    public class OperationLog
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public string MobileNo { get; set; }
        public string OperationCode { get; set; }
        public string Result { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
