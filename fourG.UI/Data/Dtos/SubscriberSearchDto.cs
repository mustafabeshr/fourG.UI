using fourG.UI.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace fourG.UI.Data.Dtos
{
    public class SubscriberSearchDto
    {
        public SubscriberSearchDto()
        {
            Subscribers = new List<Subscriber>();
        }
        [Required(ErrorMessage = "يجب ادخال رقم المشترك")]
        [StringLength(9, ErrorMessage ="اكبر طول رقم المشترك هو 9 حرف")]
        [MinLength(9, ErrorMessage ="رقم المشترك اقل من المتوقع")]
        [MaxLength(9, ErrorMessage = "رقم المشترك اكبر من المتوقع")]
        public string MobileNo { get; set; }

        public List<Subscriber> Subscribers { get; set; }
    }
}
