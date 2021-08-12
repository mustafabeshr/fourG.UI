using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace fourG.Web.Data.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "يجب ادخال رمز المستخدم")]
        [StringLength(12, ErrorMessage ="اكبر طول لرمز المستخدم هو 12 حرف")]
        [MinLength(3, ErrorMessage ="رمز المستخدم اقل من المتوقع")]
        public string Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "يجب ادخال الرقم السري")]
        [StringLength(20, ErrorMessage = "اكبر طول للرقم السري هو 20 حرف")]
        [MinLength(6, ErrorMessage = "الرقم السري اقل من المتوقع")]
        public string Secret { get; set; }
        
    }
}
