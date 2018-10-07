using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.observable
{
    interface IObservable
    {

        void AddObserver(IObserver observer);
        void DeleteObserver(IObserver observer);
        void Notify(IMessage message);

    }
}
