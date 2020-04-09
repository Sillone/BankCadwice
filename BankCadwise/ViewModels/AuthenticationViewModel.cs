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
    class AuthenticationViewModel:Screen, IHandle<MessageModel>
    {
        private readonly IEventAggregator _eventAggregator;
        private Notifier notifier;           
        public AuthenticationViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            notifier = new Notifier(eventAggregator);
        }
        public void Handle(MessageModel message)
        {
           if(message.Type==MessageType.LoginError)
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
                var message = new MessageModel(MessageType.Login, id, password ) ;
                _eventAggregator.BeginPublishOnUIThread(message);

        }
    }
}
