using BankCadwise.Message;
using Caliburn.Micro;
using System.Collections.Generic;
using System.Linq;

namespace BankCadwise.Models
{
    class Bank : PropertyChangedBase
    {   
        public Dictionary<int, int> AvailableMoney { get; private set; }
        public int MaxMoneyCount = 10000;
        public int Balance { get; set; }
        public Bank()
        {  
            AvailableMoney = new Dictionary<int, int>();
            AvailableMoney.Add(50, 10);
            AvailableMoney.Add(100, 10);
            AvailableMoney.Add(200, 10);
            AvailableMoney.Add(500, 10);
            AvailableMoney.Add(1000, 10);
            AvailableMoney.Add(2000, 10);
            AvailableMoney.Add(5000, 10);        
        }
       
    }
}
