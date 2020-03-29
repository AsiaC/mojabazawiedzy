using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojaBazaWiedzy
{
    class Customer
    {
        private int CustomerId { get; set; }
        public string CompanyName { get; set; }
        protected string State { get; set; }
        internal string State2 { get; set; }
        public string City { get; set; }
        public Customer(int customerId, string companyName, string state, string city)
        {
            CustomerId = customerId;
            CompanyName = companyName;
            State = state;
            City = city;
        }
        public Customer() { }
    }
}
