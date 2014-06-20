using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev.EDI
{
    class Order9Exception : Exception
    {
        /// <summary> 
        /// Default constructor. 
        /// </summary> 
        public Order9Exception()
        {
        }
        /// <summary> 
        /// Constructor used with a message. 
        /// </summary> 
        /// <param name="message">String message of exception.</param> 
        public Order9Exception(string message)
            : base(message)
        {
        }
        /// <summary> 
        /// Constructor used with a message and an inner exception. 
        /// </summary> 
        /// <param name="message">String message of exception.</param> 
        /// <param name="inner">Reference to inner exception.</param> 
        public Order9Exception(string message, Exception inner)
            : base(message, inner)
        {
        }


    }
}
