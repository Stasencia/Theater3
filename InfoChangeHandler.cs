using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater
{
    abstract class InfoChangeHandler
    {
        public InfoChangeHandler Successor { get; set; }
        public abstract void Handle(LoginChangeReciever receiver);
    }
}
