using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCadwise.Message
{
    class DepositeType
    {
        public int Amount { get; set; }
        public DepositeType(int amount)
        {
            Amount = amount;
        }
    }
}
