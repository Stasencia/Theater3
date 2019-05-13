using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater
{
    class LoginChangeReciever
    {
        public string NewLogin { get; set; }
        public string InitialLogin { get; set; }
        public My_Account Account { get; set; }

        public LoginChangeReciever(string newl, string initl, My_Account acc)
        {
            NewLogin = newl;
            InitialLogin = initl;
            Account = acc;
        }
    }
}
