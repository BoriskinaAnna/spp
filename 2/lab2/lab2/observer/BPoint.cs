using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class BPoint : IObserver<MessageModel>
    {
        private int x;
        private int y;

        public void Update(MessageModel message)
        {
            x = message.X;
            y = message.Y;
        }

        public void Update(object message)
        {
            Update((MessageModel) message);
        }
    }
}
