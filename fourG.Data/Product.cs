using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fourG.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string FirstId  { get; set; }
        public string SecondId  { get; set; }
        public string Name  { get; set; }
        public double Fee  { get; set; }
        public double Size  { get; set; }
        public int Validity { get; set; }
        public string PrepaidOfferId { get; set; }
        public string PostpaidOfferId { get; set; }
    }
}
