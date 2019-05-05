using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Theater
{
    class NoChangesHandler : InfoChangeHandler
    {
        public override void Handle(LoginChangeReciever reciever)
        {
            if (reciever.NewLogin == reciever.InitialLogin)
            {
            }
            else if (Successor != null)
                Successor.Handle(reciever);
        }
    }
}
