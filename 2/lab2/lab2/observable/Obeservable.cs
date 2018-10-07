using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.observable
{
    class Obeservable : IObservable
    {
        private IList<IObserver> observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void DeleteObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify(IMessage message)
        {
            foreach (IObserver observer in observers)
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
