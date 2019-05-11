using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater
{
    class SeatInfo
    {
        public int Performance_info_id { get; set; }
        public decimal Price { get; set; }
        public string HallPart { get; set; }
        public bool Left { get; set; }
        public int Sector { get; set; }
        public int Seat { get; set; }
    }
}
