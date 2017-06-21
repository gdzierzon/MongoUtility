using System;
using System.Reactive.Concurrency;

namespace MongoUtility.Common.Interfaces.Rx
{
    public interface IEventAggregator
    {
        IObservable<T> GetEvent<T>();
        IScheduler Scheduler { get; set; }
        void Publish<TEvent>(TEvent publishedEvent);
    }
}