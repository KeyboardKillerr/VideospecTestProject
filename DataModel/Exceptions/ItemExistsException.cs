using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Exceptions
{
    public class ItemExistsException : SearchException<Guid>
    {
        public ItemExistsException(Guid id, string message, Exception innerException = null) : base(id, message, innerException) { }
        public ItemExistsException(Guid id, Exception innerException = null) : this(id, $"Item with id {id} already exists", innerException) { }
    }
}
