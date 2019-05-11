using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater
{
    class Parter : HallPart
    {
        public Parter(bool left, int sector) : base("Партер", left, "Ряд", sector)
        {

        }
    }
}
