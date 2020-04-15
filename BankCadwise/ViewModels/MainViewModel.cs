using BankCadwise.Message;
using BankCadwise.Models;
using Caliburn.Micro;

namespace BankCadwise.ViewModels
{
    class MainViewModel : Conductor<object>, IHandle<MessageType>
    {
        private readonly IEventAggregator _eventAggregator;
        public MainViewModel(IEventAggregator eventAggregator, SimpleContainer container)
        {
            _auth = container.GetInstance<AuthenticationViewModel>();
            _menu = container.GetInstance<MenuViewModel>();
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            ActivateItem(_auth);         
        }
        private AuthenticationViewModel _auth;
        private MenuViewModel _menu;
        private void LoadMenu()
        {
            ActivateItem(_menu);    
        }
        private void LoadAuthor()
        {
            ActivateItem(_auth);        
        }
        public void Handle(MessageType message)
        {
            switch (message)
            {

                case MessageType.LoginSuccess:
                    {
                        LoadMenu();
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
