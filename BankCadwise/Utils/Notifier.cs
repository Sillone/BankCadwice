using BankCadwise.Message;
using BankCadwise.Models;
using Caliburn.Micro;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BankCadwise.Utils
{
    class Notifier : IHandle<MessageModel>
    {
        private readonly IEventAggregator _eventAggregator;

        BinaryFormatter formatter = new BinaryFormatter();

        public Notifier(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        public void Handle(MessageModel message)
        {
            if (message.Type == MessageType.Login)
                Login(Convert.ToInt32(message.Parametr), $"{message.Parametr2}");
        }

        public void Login(int id, string password)
        {
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length <= 0L)
                {

                    Person newPerson = new Person() { Id = 111, Pasword = "111", Balance = 10000, Name = "Иванов Иван" };
                    formatter.Serialize(fs, newPerson);
                    fs.Close();
                  
                }
                Person person = (Person)formatter.Deserialize(fs);
                fs.Close();
                if ((person.Id == id) && (person.Pasword == password))
                {
                    _eventAggregator.BeginPublishOnUIThread(new MessageModel(MessageType.LoginSuccess, person));
                    return;
                }

                _eventAggregator.BeginPublishOnUIThread(new MessageModel(MessageType.LoginError, null));

            }
        }
    }
}
