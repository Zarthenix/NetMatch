using NetMatch_PT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.ViewModels
{
    public class InsuranceDetailVm
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Selected { get; set; }
        public InsuranceDetailVm()
        {

        }
        public InsuranceDetailVm(int id, string name, decimal price)
        {
            ID = id;
            Name = name;
            Price = price;
        }
    }
}
