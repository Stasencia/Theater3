using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater
{
    class TicketSellInfo
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Small_image { get; set; }
        public bool Cancelled { get; set; }
        public IEnumerable<TTickets> Tickets { get; set; }
    }
}
