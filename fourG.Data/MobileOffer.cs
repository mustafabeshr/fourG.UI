using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fourG.Data
{
    public class MobileOffer
    {
        public int Id { get; set; }
        public string MobileNo { get; set; }
        public string OfferId { get; set; }
        public string OfferName { get; set; }
        public DateTime SubscribedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastOperation { get; set; }
    }
}
