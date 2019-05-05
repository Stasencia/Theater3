using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater
{
    class PasswordChangeReciever
    {
        public string NewPassword { get; set; }
        public string InitialPassword { get; set; }
        public My_Account Account { get; set; }
        public PasswordChangeReciever(string newp, string initp, My_Account acc)
        {
            NewPassword = newp;
            InitialPassword = initp;
            Account = acc;
        }
    }
}
