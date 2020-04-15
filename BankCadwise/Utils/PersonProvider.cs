using BankCadwise.Message;
using BankCadwise.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BankCadwise.Utils
{
    public class PersonProvider
    {    
        public Person Login(int id, string password)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));
            using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
            {
                if (fs.Length <= 0L)
                {

                    List<Person> newPerson = new List<Person>();
                    newPerson.Add(new Person() { Balance = 10000, Id = 123, Pasword = "123", Name = "Иван Иванович"});
                    newPerson.Add(new Person() { Balance = 99999, Id = 111, Pasword = "111", Name = "Петр Петрович"});
                    newPerson.Add(new Person() { Balance = 100, Id = 321, Pasword = "321", Name = "Александр Александрович"});
                    formatter.Serialize(fs, newPerson);
                    fs.Position = 0L;
                  
                }
                List<Person> persons = (List<Person>)formatter.Deserialize(fs);
                fs.Close();
                foreach (var item in persons)
                {
                    if ((item.Id == id) && (item.Pasword == password))
                        return item;
                }

                return null;

            }
        }
    }
}
