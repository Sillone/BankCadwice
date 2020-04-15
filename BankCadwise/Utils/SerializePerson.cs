using BankCadwise.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BankCadwise.Utils
{
    class SerializePerson
    {
        XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));
        public void Serialize(Person person)
        {
            using (FileStream fs = new FileStream("people.xml", FileMode.Open))
            {                
                List<Person> persons = (List<Person>)formatter.Deserialize(fs);
                fs.Position = 0;
                foreach (var item in persons)
                {
                    if (item.Id == person.Id)
                    {
                        item.Balance = person.Balance;
                        formatter.Serialize(fs,persons);
                        fs.Close();
                        return;
                    }
                        
                }
                
            }
        }
    }
}
