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
        public string CurrentPassword { get; set; }
        public string ConfimationPassword { get; set; }
        public My_Account Account { get; set; }
        public PasswordChangeReciever(string newp, string curp, string confirmp, My_Account acc)
        {
            NewPassword = newp;
            CurrentPassword = curp;
            ConfimationPassword = confirmp;
            Account = acc;
        }
    }
}
