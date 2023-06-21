using ColossalFramework;
using Democracy.GameAPI.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Democracy.GameAPI
{
    internal abstract class Publisher<T, E> where E : Enum
    {
        public delegate void Consumer(HashSet<T> values);
        
        protected PoolList<ConsumerOptionWrapper> _consumers;

        protected Publisher()
        {
            Logging.Instance.Trace("Obtain PoolList for class " + typeof(T) + ", with argument type " + typeof(E) + ".");
            this._consumers = PoolList<ConsumerOptionWrapper>.Obtain();
        }

        public void Subscribe(Consumer consumer, E subscriptionOption)
        {
            _consumers.Add(new ConsumerOptionWrapper(consumer, subscriptionOption));
            Logging.Instance.Trace(consumer + " subscribed with option" + subscriptionOption);
        }

        protected void Update(HashSet<T> values, E subscriptionOption)
        {
            foreach(var value in _consumers)
            {
                if (value.SubscriptionOption.Equals(subscriptionOption)) {
                    value.Consumer.Invoke(values);
                }
            }
        }

        protected internal class ConsumerOptionWrapper
        {
            private readonly Consumer _consumer;
            private readonly E _subscriptionOption;

            internal ConsumerOptionWrapper(Consumer consumer, E subscriptionOption)
            {
                this._consumer = consumer;
                this._subscriptionOption = subscriptionOption;
            }

            internal Consumer Consumer { get { return _consumer; } }
            internal E SubscriptionOption { get { return _subscriptionOption; } }
        }

    }
}
