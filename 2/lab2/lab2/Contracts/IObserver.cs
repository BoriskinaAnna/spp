using System;

namespace lab2.Contracts
{
    public interface IObserver<T> where T: IMessage
    {
        void Update(T message);
    }
}
