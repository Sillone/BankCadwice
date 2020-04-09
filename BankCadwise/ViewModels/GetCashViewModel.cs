using BankCadwise.Message;
using BankCadwise.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;

namespace BankCadwise.ViewModels
{
    class GetCashViewModel : Screen, IHandle<MessageModel>
    {
        public Bank MyBank { get; set; }
        BindableCollection<KeyValuePair<int, int>> _returnedMoney = new BindableCollection<KeyValuePair<int, int>>();
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

        private readonly int _personBalance;
        public GetCashViewModel(IEventAggregator eventAggregator,int persomBalance)
        {
            MyBank = Bank.GetBank();
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            ReturnedMoney = new BindableCollection<KeyValuePair<int, int>>();
            _personBalance = persomBalance;
        }

        public bool CanGetCash(int amount, bool exchange)
        {
            return (amount > 0)&&(amount<= _personBalance)&&(_personBalance-amount>=0);
        }
        public void GetCash(int amount, bool exchange)
        {
            MyBank.GetCash(amount, exchange);
        }
        private void ReturnMoney(BindableCollection<KeyValuePair<int, int>> returnedMoney)
        {
            ReturnedMoney = new BindableCollection<KeyValuePair<int, int>>();
            foreach (var item in returnedMoney)
            {
                ReturnedMoney.Add(item);
            }
        }

        public void Handle(MessageModel message)
        {
            switch (message.Type)
            {
                case MessageType.GetCashSuccess:
                    {
                        ReturnMoney((BindableCollection<KeyValuePair<int, int>>)message.Parametr);
                        MyBank.GetBalance();
                        break;
                    }
                case MessageType.GetCashError:
                    break;
                default:
                    break;
            }
        }
    }
}
