using Caliburn.Micro;
using System.Runtime.Serialization;
using System;

namespace BankCadwise.Models
{ 

    [Serializable]
    class Person
    {
   
        public int Id { get; set; }

        public string Pasword { get; set; }

        public string Name { get; set; }

        public float Balance { get; set; }
    }
}
