using BankCadwise.Message;
using Caliburn.Micro;
using System.Collections.Generic;
using System.Linq;

namespace BankCadwise.Models
{
    class Bank : PropertyChangedBase
    {
        private static Bank _bank;
        public static Bank GetBank()
        {
            return _bank;
        }

        public Dictionary<int, int> AvailableMoney { get; private set; }
        const int MaxMoneyCount = 10000;
        private readonly IEventAggregator _eventAggregator;

        private int balance;
        public int Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
                NotifyOfPropertyChange(() => Balance);
            }
        }


        public Bank(IEventAggregator eventAggregator)
        {
            if (_bank == null)
                _bank = this;
            AvailableMoney = new Dictionary<int, int>();
            AvailableMoney.Add(50, 100);
            AvailableMoney.Add(100, 100);
            AvailableMoney.Add(200, 100);
            AvailableMoney.Add(500, 100);
            AvailableMoney.Add(1000, 100);
            AvailableMoney.Add(2000, 100);
            AvailableMoney.Add(5000, 100);
            GetBalance();
            _eventAggregator = eventAggregator;
        }
        public void DepositMoney(int value, int count)
        {
            if (AvailableMoney.ContainsKey(value))
            {
                if (AvailableMoney[value] + count <= MaxMoneyCount)
                {
                    AvailableMoney[value] += count;
                    Balance += AvailableMoney[value] * count;
                    _eventAggregator.BeginPublishOnUIThread(new MessageModel(MessageType.DepositSuccess, value * count));
                }
                else
                {
                    int ReturnCount = count - (MaxMoneyCount - AvailableMoney[value]);
                    AvailableMoney[value] = MaxMoneyCount;
                    _eventAggregator.BeginPublishOnUIThread(new MessageModel(MessageType.DepositSuccess, value * count, ReturnCount));
                }
                GetBalance();


            }
            _eventAggregator.BeginPublishOnUIThread(new MessageModel(MessageType.DepositError));
        }
        public void GetCash(int amount, bool exchangeMoney)
        {
            if (amount > Balance)
            {
                _eventAggregator.BeginPublishOnUIThread(new MessageModel(MessageType.GetCashError));
                return;
            }

            if (exchangeMoney)
            {
                GetExchangeMoney(amount);
            }
            else
            {
                GetUnExchangeMoney(amount);
            }
        }
        private void GetExchangeMoney(int NeedAmount)
        {
            BindableCollection<KeyValuePair<int, int>> returnedMoney = new BindableCollection<KeyValuePair<int, int>>();
            int amount = NeedAmount;
            var r = AvailableMoney.OrderBy(t => t.Key).ToDictionary(t => t.Key, t => t.Value).Where(t => t.Value != 0);
            while (amount != 0)
            {
                foreach (var item in r)
                {
                    if (amount <= 0)
                    {
                        break;
                    }
                    int count = amount / item.Key;
                    if (item.Value >= count)
                    {
                        amount -= count * item.Key;
                        AvailableMoney[item.Key] -= count;
                        returnedMoney.Add(new KeyValuePair<int, int>(item.Key, count));
                    }
                    else
                    {
                        if ((count % 2) == (item.Value % 2))
                        {
                            count = item.Value;
                            amount -= count * item.Key;
                            AvailableMoney[item.Key] -= count;
                            returnedMoney.Add(new KeyValuePair<int, int>(item.Key, count));
                        }
                        else
                        {
                            count = item.Value - 1;
                            amount -= count * item.Key;
                            AvailableMoney[item.Key] -= count;
                            returnedMoney.Add(new KeyValuePair<int, int>(item.Key, count));
                        }
                    }
                }
            }

            Balance -= NeedAmount;
            _eventAggregator.BeginPublishOnUIThread(new MessageModel(MessageType.GetCashSuccess, returnedMoney));
        }
        private void GetUnExchangeMoney(int NeedAmount)
        {
            if (NeedAmount <= 0)
                return;
            BindableCollection<KeyValuePair<int, int>> returnedMoney = new BindableCollection<KeyValuePair<int, int>>();
            int amount = NeedAmount;
            var r = AvailableMoney.OrderByDescending(t => t.Key).ToDictionary(t => t.Key, t => t.Value);
            foreach (var item in r)
            {
                int count = amount / item.Key;
                if (count > 0)
                {
                    if (count <= item.Value)
                    {
                        amount -= count * item.Key;
                        AvailableMoney[item.Key] -= count;
                        returnedMoney.Add(new KeyValuePair<int, int>(item.Key, count));
                    }
                    else
                    {
                        amount -= item.Value * item.Key;
                        AvailableMoney[item.Key] = 0;
                        returnedMoney.Add(new KeyValuePair<int, int>(item.Key, item.Value));
                    }
                }
            }
            _eventAggregator.BeginPublishOnUIThread(new MessageModel(MessageType.GetCashSuccess, returnedMoney));
            Balance -= NeedAmount;
        }

        public void GetBalance()
        {
            Balance = 0;
            foreach (var item in AvailableMoney)
            {
                Balance += item.Key * item.Value;
            }
        }
    }
}
