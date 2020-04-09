using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCadwise.Message
{
    class MessageModel
    {
        public MessageType Type { get; }
        public MessageModel(MessageType type)
        {
            Type = type;
        }

        public object Parametr { get; }   
        public MessageModel(MessageType type, object parametr)
        {
            Type = type;
            Parametr = parametr;  
        }

        public object Parametr2 { get; }
        public MessageModel(MessageType type, object parametr, object parametr2)
        {
            Type = type;
            Parametr = parametr;
            Parametr2 = parametr2;
        }
    }
}
