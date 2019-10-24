using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojaBazaWiedzy
{
    interface ICustomer
    {
        string GetCustomerById(int customerId);
        string GetCustomerByDate(DateTime dateForm, DateTime dateTo);
    }
}
