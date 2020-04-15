using BankCadwise.Utils;
using BankCadwise.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankCadwise.Message;
using System.Windows;

namespace BankCadwise.ViewModels
{
    class AuthenticationViewModel:Screen, IHandle<MessageType>
    {
        private readonly IEventAggregator _eventAggregator;
        private PersonProvider notifier;
        public AuthenticationViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            notifier = new PersonProvider();
        }
        public void Handle(MessageType message)
        {
           if(message==MessageType.LoginError)
            {
                MessageBox.Show("Не верный Id или пароль\n Попробуйте ещё раз.","Ошибка авторизации");
            }
        }
        public bool CanLogin(int id , string password)
        {
            return id>0 && !String.IsNullOrEmpty(password);
        }
        public void Login(int id, string password)
        {

            var person= notifier.Login(id, password);
            if (person!=null)
            {                  
                _eventAggregator.PublishOnUIThread(MessageType.LoginSuccess);
                _eventAggregator.PublishOnBackgroundThread(person);
            }
        }
    }
}
