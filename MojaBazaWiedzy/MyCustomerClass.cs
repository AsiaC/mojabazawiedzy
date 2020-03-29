using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojaBazaWiedzy
{
    class MyCustomerClass : Customer, ICustomer
    {
        protected string Zip { get; set; }
        public string GetCustomerByDate(DateTime dateForm, DateTime dateTo)
        {
            throw new NotImplementedException();
        }

        public string GetCustomerById(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
