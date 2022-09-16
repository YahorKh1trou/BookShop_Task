namespace RestAPI.Counters
{
    public class AddCounter
    {
        public int Counter = 1;
        private static AddCounter _counter = null;
        private static object _lock = new object();
        protected AddCounter() { }
        public static AddCounter Initialize()
        {
            if (_counter == null)
            {
                lock (_lock)
                {
                    if (_counter == null)
                    {
                        _counter = new AddCounter();
                    }
                }
            }
            return _counter;
        }
        public int Increment()
        {
            return Counter++;
        }
    }
}
