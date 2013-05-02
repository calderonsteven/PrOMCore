using System;
using System.Collections.Generic;
using System.Text;

namespace PrOMCore.Exceptions
{
    public class PrOMException:Exception
    {
        public PrOMException(string message)
            : base(message)
        { 
        
        }
    }
}
