using BankCadwise.Models;
using Caliburn.Micro;
using System.Collections.Generic;

namespace BankCadwise.ViewModels
{
    class DepositeViewModel : Screen
    {
  
        private readonly IEventAggregator _eventAggregator;
        public Person MyPerson { get; private set; }     
        public Bank MyBank { get; set; }
        private int balance;
        public int Balance
        {
            get { return balance; }
            set { balance = value;
                NotifyOfPropertyChange(()=>Balance);
            }
        }
        public KeyValuePair<int, int> DepositeMoney { get; set; }
        BindableCollection<KeyValuePair<int, int>> _availableMoney = new BindableCollection<KeyValuePair<int, int>>();
        public BindableCollection<KeyValuePair<int, int>> AvailableMoney
        {
            get { return _availableMoney; }
            set { _availableMoney = value; }
        }

        public DepositeViewModel(IEventAggregator eventAggregator, Person person)
        {
            _eventAggregator = eventAggregator;
            MyPerson = person;
            MyBank = Bank.GetBank();
            ReFreshAvailebleMoney();
        }
        public bool CanDeposite(int count)
        {
            return count > 0;
        }
        public void Deposite(int count)
        {
            MyBank.DepositMoney(DepositeMoney.Key, count);
            ReFreshAvailebleMoney();
        }
        private void ReFreshAvailebleMoney()
        {
            Balance = MyBank.Balance;
            foreach (var item in MyBank.AvailableMoney)
            {
                for (int i = 0; i < AvailableMoney.Count; i++)
                {
                    if (AvailableMoney[i].Key == item.Key)
                    {
                        AvailableMoney[i] = item;
                    }
                }
                if (!AvailableMoney.Contains(item))
                    AvailableMoney.Add(item);
            }
        }
    }
}
