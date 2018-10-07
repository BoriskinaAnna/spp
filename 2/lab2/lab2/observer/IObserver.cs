using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{

    interface IObserver
    {
        void Update(Object message);
    }

    interface IObserver<T>: IObserver where T: IMessage
    {
        void Update(T message);
    }
}
