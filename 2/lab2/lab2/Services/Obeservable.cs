using lab2.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Services
{
    public class Observable : Contracts.IObservable
    {
        private IList<Contracts.IObserver<IMessage>> observers = new List<Contracts.IObserver<IMessage>>();

        public void AddObserver(Contracts.IObserver<IMessage> observer)
        {
            observers.Add(observer);
        }

        public void DeleteObserver(Contracts.IObserver<IMessage> observer)
        {
            observers.Remove(observer);
        }

        public void Notify(IMessage message)
        {
            foreach (Contracts.IObserver<IMessage> observer in observers)
            {
                Type observerMessageType = observer.GetType().GenericTypeArguments[0];
                if (typeof(IMessage).Equals(observerMessageType))
                {
                    observer.Update(message);
                }
            }
        }
    }
}
