using Caliburn.Micro;
using System.Runtime.Serialization;
using System;

namespace BankCadwise.Models
{ 

    [DataContract]
    public class Person : PropertyChangedBase
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Pasword { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]

        private int balance;

        public int Balance
        {
            get { return balance; }
            set 
            { balance = value;
                NotifyOfPropertyChange(() => Balance);
            }
        }


    }
}
