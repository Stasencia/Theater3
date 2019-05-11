using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater
{
    class Beljetazh : HallPart
    {
        public Beljetazh(bool left, int sector) : base ("Бельэтаж", left, "Сектор", sector)
        {
            
        }
    }
}
