using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Entities
{
    public class CustomUserProperty : EntityBase
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
