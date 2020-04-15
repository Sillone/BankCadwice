using BankCadwise.Models;
using Caliburn.Micro;
using System.Collections.Generic;

namespace BankCadwise.ViewModels
{
    class GetCertainValueViewModel : Screen, IHandle<Person>
    {
        private int maxAmount;
        public int MaxAmount
        {
            get { return maxAmount; }
            set 
            {
                maxAmount = value;
                NotifyOfPropertyChange(() => MaxAmount);
            }
        }
        
        private int balance;
        public int Balance
        {
            get { return balance; }
            set
            {
                balance = value;
                NotifyOfPropertyChange(() => Balance);
            }
        }

        private BindableCollection<KeyValuePair<int, int>> _availableMoney = new BindableCollection<KeyValuePair<int, int>>();
        public BindableCollection<KeyValuePair<int, int>> AvailableMoney
        {
            get { return _availableMoney; }
            set { _availableMoney = value;
                NotifyOfPropertyChange(() => AvailableMoney);
            }
        }

        private readonly IEventAggregator _eventAggregator;
        private readonly SimpleContainer _container;
        private Bank bank;
        public Bank MyBank 
        {
            get { return bank; }
            set
            {
                bank = value;
            }
        }

        private Person person;
        public GetCertainValueViewModel(IEventAggregator eventAggregator, SimpleContainer container)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _container = container;
            MyBank = _container.GetInstance<Bank>();
            RefreshAvailebleMoney();
        }       
        public bool CanGetCertainValue(int amount, KeyValuePair<int, int> availableMoney)
        {            
            MaxAmount = availableMoney.Key*availableMoney.Value;
            if ((amount != 0)&&(MaxAmount!=0))
                return (amount >= availableMoney.Key) && (amount / availableMoney.Key <= availableMoney.Value) && (amount % availableMoney.Key == 0)&&(amount<=person.Balance);
            else return false;
        }
        public void GetCertainValue(int amount,KeyValuePair<int, int> availableMoney)
        {
           
            if(AvailableMoney.Contains(availableMoney))
            {
                var count = amount / availableMoney.Key;
                MyBank.AvailableMoney[availableMoney.Key] -= count;
                person.Balance -= amount;
                RefreshAvailebleMoney();
            }
        }
        private void RefreshAvailebleMoney()
        {
            Balance = 0;
            foreach (var item in MyBank.AvailableMoney)
            {
                Balance += item.Key * item.Value;
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

        public void Handle(Person _person)
        {
            person = _person;
        }
    }
}
