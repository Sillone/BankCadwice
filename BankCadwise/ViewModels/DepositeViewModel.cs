using BankCadwise.Message;
using BankCadwise.Models;
using BankCadwise.Utils;
using Caliburn.Micro;
using System.Collections.Generic;
using System.Windows;

namespace BankCadwise.ViewModels
{
    class DepositeViewModel : Screen
    { 

        private readonly IEventAggregator _eventAggregator;     

        public Bank MyBank { get; set; }
        BankLogic bankLogic;

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

        public KeyValuePair<int, int> DepositeMoney { get; set; }

        private BindableCollection<KeyValuePair<int, int>> _availableMoney = new BindableCollection<KeyValuePair<int, int>>();
        public BindableCollection<KeyValuePair<int, int>> AvailableMoney
        {
            get { return _availableMoney; }
            set { _availableMoney = value; }
        }

        public DepositeViewModel(IEventAggregator eventAggregator, Bank bank)
        {
            MyBank = bank;
            bankLogic = new BankLogic(bank);
            _eventAggregator = eventAggregator;          
            RefreshAvailebleMoney();
           
        }
        public bool CanDeposite(int count)
        {
            return (count > 0)&&(count!=100);
        }
        public void Deposite(int count)
        {
            var returnCount = bankLogic.DepositMoney(DepositeMoney.Key, count);
            if(returnCount<=0)
            {
                RefreshAvailebleMoney();              
                _eventAggregator.PublishOnUIThread(new DepositeType(DepositeMoney.Key * count));
            }
            else
            {
                RefreshAvailebleMoney();
                var rightCount = count - returnCount;
                _eventAggregator.PublishOnUIThread(new DepositeType(rightCount));
                MessageBox.Show($"Количество купюр достигла максимум \nВам вернули: {DepositeMoney.Key}, в количестве {returnCount}", "Ошибка"); ; ;
            }
        }
        private void RefreshAvailebleMoney()
        {
            Balance = bankLogic.GetBalance();
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
