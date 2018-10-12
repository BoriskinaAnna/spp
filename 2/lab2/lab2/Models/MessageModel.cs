using lab2.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Models
{
    class MessageModel: IMessage
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
