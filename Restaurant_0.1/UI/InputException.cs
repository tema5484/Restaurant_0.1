using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_lib.PL
{
    class InputException : Exception
    {
        public string Property { get; protected set; }
        public InputException(string message, string prop) : base(message)
        {
            Property = prop + TargetSite.Name + TargetSite.ToString();
        }
    }
}
