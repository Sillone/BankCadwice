using BankCadwise.Message;
using BankCadwise.Models;
using Caliburn.Micro;

namespace BankCadwise.ViewModels
{
    class MainViewModel : Conductor<object>, IHandle<MessageModel>
    {
        private readonly IEventAggregator _eventAggregator;

        private Bank _bank;
        public MainViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            ActivateItem(new AuthenticationViewModel(eventAggregator));
            _bank = new Bank(_eventAggregator);

        }

        private void LoadMenu(object obj)
        {
            ActivateItem(new MenuViewModel(_eventAggregator,(Person)obj));
        }
        private void LoadAuthor()
        {
            ActivateItem(new AuthenticationViewModel(_eventAggregator));
        }
        public void Handle(MessageModel message)
        {
            switch (message.Type)
            {

                case MessageType.LoginSuccess:
                    {
                        LoadMenu(message.Parametr);
                        break;
                    }

                case MessageType.Logout:
                    {
                        LoadAuthor();
                        break;
                    }

                default:
                    break;
            }


        }


    }
}
