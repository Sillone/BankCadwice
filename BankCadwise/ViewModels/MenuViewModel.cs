using BankCadwise.Message;
using BankCadwise.Models;
using BankCadwise.Utils;
using Caliburn.Micro;

namespace BankCadwise.ViewModels
{
    class MenuViewModel : Conductor<object>, IHandle<Person>, IHandle<DepositeType>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly SimpleContainer _container;
        private readonly SerializePerson serializePerson;
        private Person _person;
        public Person MyPerson
        {
            get { return _person; }
            set
            {
                _person = value;
                NotifyOfPropertyChange(() => MyPerson);
            }
        }

        public MenuViewModel(IEventAggregator eventAggregator, SimpleContainer container)
        {

            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _container = container;
            serializePerson = _container.GetInstance<SerializePerson>();
        }

        public void Deposite()
        {
            ActivateItem(_container.GetInstance<DepositeViewModel>());
            _eventAggregator.PublishOnBackgroundThread(MyPerson);

        }

        public void GetCash()
        {
            ActivateItem(_container.GetInstance<GetCashMenuViewModel>());
            _eventAggregator.PublishOnBackgroundThread(MyPerson);
        }

        public void LogOut()
        {
            serializePerson.Serialize(MyPerson);
            _eventAggregator.PublishOnBackgroundThread(MessageType.Logout);
        }

        public void Handle(Person person)
        {
            MyPerson = person;
        }
        public void Handle(DepositeType message)
        {
            MyPerson.Balance += message.Amount;
        }
    }
}
