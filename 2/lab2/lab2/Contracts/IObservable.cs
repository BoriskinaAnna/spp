using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Contracts
{
    public interface IObservable
    {

        void AddObserver(IObserver<IMessage> observer);
        void DeleteObserver(IObserver<IMessage> observer);
        void Notify(IMessage message);

    }
}
