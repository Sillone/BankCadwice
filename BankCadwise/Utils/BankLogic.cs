using BankCadwise.Models;
using Caliburn.Micro;
using System.Collections.Generic;
using System.Linq;

namespace BankCadwise.Utils
{
    class BankLogic
    {
        Bank bank;
        public BankLogic(Bank bank)
        {
            this.bank = bank;
        }
        public int DepositMoney(int value, int count)
        {
            if (bank.AvailableMoney.ContainsKey(value))
            {
                if (bank.AvailableMoney[value] + count <= bank.MaxMoneyCount)
                {
                    bank.AvailableMoney[value] += count;
                    bank.Balance += bank.AvailableMoney[value] * count;
                }
                else
                {
                    int returnCount = count - (bank.MaxMoneyCount - bank.AvailableMoney[value]);
                    bank.AvailableMoney[value] = bank.MaxMoneyCount;
                    return returnCount;
                }
                GetBalance();
                return 0;
            }
            return 0;
        }
        public BindableCollection<KeyValuePair<int, int>> GetCash(int amount, bool exchangeMoney)
        {
            if ((amount > bank.Balance) || (amount == 0) || !CanGetCashe(bank.AvailableMoney,amount))
            {
                return null;
            }

            if (exchangeMoney)
            {
                return GetExchangeMoney(amount);
            }
            else
            {
                return GetUnExchangeMoney(amount);
            }
        }
        private BindableCollection<KeyValuePair<int, int>> GetExchangeMoney(int NeedAmount)
        {
            BindableCollection<KeyValuePair<int, int>> returnedMoney = new BindableCollection<KeyValuePair<int, int>>();
            int amount = NeedAmount;
            var tempAvailableMoney = new Dictionary<int, int>(bank.AvailableMoney);
            var r = tempAvailableMoney.OrderBy(t => t.Key).ToDictionary(t => t.Key, t => t.Value).Where(t => t.Value != 0);
            foreach (var item in r)
            {               
                int count = amount / item.Key;
                if (count == 0)
                    break;
                if (item.Value >= count)
                {
                    while (count > 0)
                    {
                        var tempAmount = amount - count * item.Key;
                        tempAvailableMoney[item.Key] -= count;
                        if ((tempAmount == 0) || (CanGetCashe(tempAvailableMoney, tempAmount)))
                        {
                            amount -= count * item.Key;
                            tempAvailableMoney[item.Key] -= count;
                            if (count > 0)
                            {
                                returnedMoney.Add(new KeyValuePair<int, int>(item.Key, count));
                                break;
                            }

                        }
                        else
                        {
                            tempAvailableMoney[item.Key] -= count;
                            count--;
                        }
                            
                    }                  
                }
                else
                {                                                        
                        count = item.Value;
                    while(count>0)
                    {
                        var tempAmount = amount - count * item.Key;
                        tempAvailableMoney[item.Key] -= count;
                        if ((tempAmount == 0) || (CanGetCashe(tempAvailableMoney, tempAmount)))
                        {
                            amount -= count * item.Key;
                            tempAvailableMoney[item.Key] -= count;
                            if (count > 0)
                            {
                                returnedMoney.Add(new KeyValuePair<int, int>(item.Key, count));
                                break;
                            }

                        }
                        else
                        {
                            tempAvailableMoney[item.Key] += count;
                            count--;
                        }
                            
                    }                                               
                }
            }        
            bank.Balance -= NeedAmount;
            foreach (var item in returnedMoney)
            {
                if (bank.AvailableMoney.ContainsKey(item.Key))
                    bank.AvailableMoney[item.Key] -= item.Value;
            }
            return returnedMoney;

        }
        private BindableCollection<KeyValuePair<int, int>> GetUnExchangeMoney(int NeedAmount)
        {
            BindableCollection<KeyValuePair<int, int>> returnedMoney = new BindableCollection<KeyValuePair<int, int>>();
            int amount = NeedAmount;
            var r = bank.AvailableMoney.OrderByDescending(t => t.Key).ToDictionary(t => t.Key, t => t.Value);
            foreach (var item in r)
            {
                int count = amount / item.Key;
                if (count > 0)
                {
                    if (count <= item.Value)
                    {
                        amount -= count * item.Key;
                        bank.AvailableMoney[item.Key] -= count;
                        returnedMoney.Add(new KeyValuePair<int, int>(item.Key, count));
                    }
                    else
                    {
                        amount -= item.Value * item.Key;
                        bank.AvailableMoney[item.Key] = 0;
                        returnedMoney.Add(new KeyValuePair<int, int>(item.Key, item.Value));
                    }
                }
            }
            bank.Balance -= NeedAmount;
            return returnedMoney;
        }
        private bool CanGetCashe(IEnumerable<KeyValuePair<int, int>> r, int amount)
        {
            var temp = r.OrderByDescending(t => t.Key).ToDictionary(t => t.Key, t => t.Value).Where(t => t.Value != 0);

            foreach (var item in temp)
            {
                if (amount > 0)
                {
                    int count = amount / item.Key;
                    if (count > 0)
                    {
                        if (count <= item.Value)
                        {
                            amount -= count * item.Key;
                        }
                        else
                        {
                            amount -= item.Value * item.Key;
                        }
                    }
                }
            }
            if (amount == 0)
                return true;
            else
                return false;
        }
        public int GetBalance()
        {
            int balance = 0;
            foreach (var item in bank.AvailableMoney)
            {
                balance += item.Key * item.Value;
            }
            return balance;
        }
    }
}
