using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Exceptions
{
    public class ItemNotFoundException : SearchException<Guid>
    {
        public ItemNotFoundException(Guid id, string message, Exception innerException = null) : base(id, message, innerException) { }
        public ItemNotFoundException(Guid id, Exception innerException = null) : this(id, $"Item with property {id} was not found", innerException) { }
    }
}
