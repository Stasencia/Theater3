using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater
{
    public class SeatClickedEventArgs : EventArgs
    {
        public decimal Price { get; set; }

        public SeatClickedEventArgs(decimal price)
        {
            Price = price;
        }
    }
}
