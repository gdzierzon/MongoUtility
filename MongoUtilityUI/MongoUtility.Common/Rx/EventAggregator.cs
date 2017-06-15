using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace MongoUtility.Common.Rx
{

    public class EventAggregator
    {
        #region singleton contstruction

        private static EventAggregator eventAggregator;
        public static EventAggregator Aggregator => eventAggregator ?? (eventAggregator = new EventAggregator());

        private EventAggregator()
        {
            
        }

        #endregion

        private IScheduler scheduler;
        private readonly ISubject<object> subject = new Subject<object>();

        public IObservable<T> GetEvent<T>()
        {
            return subject.AsObservable().OfType<T>();
        }

        public IScheduler Scheduler
        {
            get { return scheduler ?? System.Reactive.Concurrency.Scheduler.Default; }

            set { scheduler = value; }
        }

        public void Publish<TEvent>(TEvent publishedEvent)
        {
            subject.OnNext(publishedEvent);
        }

        public void Dispose()
        {
        }

        public string Name { get { return "EventAggregator"; } }

    }
}