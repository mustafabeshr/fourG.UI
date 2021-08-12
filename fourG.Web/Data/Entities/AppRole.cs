using System;
using System.Collections.Generic;
using System.Text;

namespace fourG.Web.Data.Entities
{
    public class AppRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
