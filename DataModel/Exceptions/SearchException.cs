using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Exceptions
{
    public class SearchException<T> : Exception
    {
        private readonly T item;
        public T Id { get { return item; } }

        public SearchException(T item, string message = null, Exception innerException = null) : base(message, innerException)
        {
            this.item = item;
        }
    }
}
