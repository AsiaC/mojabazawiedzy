using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojaBazaWiedzy
{
    class LoanCollection :IEnumerable
    {
        private readonly Loan[] _loanCollection;
        public LoanCollection(Loan[] loanArray)
        {
            _loanCollection = new Loan[loanArray.Length];
            for (int i = 0; i < loanArray.Length; i++)
            {
                _loanCollection[i] = loanArray[i];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return _loanCollection.GetEnumerator();
        }
    }
}
