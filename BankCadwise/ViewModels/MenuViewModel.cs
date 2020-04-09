using BankCadwise.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCadwise.ViewModels
{
    class MenuViewModel : Conductor<object>
    {
        private readonly IEventAggregator _eventAggregator;

        public Person MyPerson { get; set; }      
        public MenuViewModel(IEventAggregator eventAggregator, Person person)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            MyPerson = person;
        }


        public void Deposite()
        {
            ActivateItem(new DepositeViewModel(_eventAggregator, MyPerson));
        }

        public void GetCash()
        {
            ActivateItem(new GetCashViewModel(_eventAggregator, (int)MyPerson.Balance)); 
        }

        public void LogOut()
        {

        }
    }
}
