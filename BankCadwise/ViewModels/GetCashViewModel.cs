using BankCadwise.Models;
using BankCadwise.Utils;
using Caliburn.Micro;
using System.Collections.Generic;
using System.Windows;

namespace BankCadwise.ViewModels
{
    class GetCashViewModel : Screen, IHandle<Person>
    {
        public Bank MyBank { get; set; }
        private int amount;

        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                NotifyOfPropertyChange(() => Amount);
            }
        }

        private Person person;
        private BankLogic bankLogic;
        private BindableCollection<KeyValuePair<int, int>> _returnedMoney = new BindableCollection<KeyValuePair<int, int>>();
        public BindableCollection<KeyValuePair<int, int>> ReturnedMoney
        {
            get { return _returnedMoney; }
            set
            {
                _returnedMoney = value;
                NotifyOfPropertyChange(() => ReturnedMoney);
            }
        }
        private readonly IEventAggregator _eventAggregator;
        public GetCashViewModel(IEventAggregator eventAggregator, Bank myBank)
        {
            MyBank = myBank;
            bankLogic = new BankLogic(MyBank);
            MyBank.Balance = bankLogic.GetBalance();
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            ReturnedMoney = new BindableCollection<KeyValuePair<int, int>>();
        }

        public bool CanGetCash(int amount, bool exchange)
        {
            return (amount > 0) && (person.Balance - amount >= 0);
        }
        public void GetCash(int amount,bool exchange)
        {
            var value = bankLogic.GetCash(amount, exchange);
            if (value != null)
            {
                ReturnMoney(value);
                person.Balance -= amount;               
            }
            else
            {
                MessageBox.Show("Недостаточно купюр для выдачи суммы.", "Ошибка");
            }
            Amount =0;
        }
        private void ReturnMoney(BindableCollection<KeyValuePair<int, int>> returnedMoney)
        {
            ReturnedMoney = new BindableCollection<KeyValuePair<int, int>>(returnedMoney);
        }

        public void Handle(Person _person)
        {
            person = _person;
        }
    }
}
