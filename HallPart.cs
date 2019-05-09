using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater
{
    abstract class HallPart
    {
        public HallPart(string n, bool Left, string SectorName, int Sector)
        {
            this.Name = n;
            this.Left = Left;
            this.SectorName = SectorName;
            this.Sector = Sector;
        }
        public string Name { get; protected set; }
        public bool Left { get; protected set; }
        public string SectorName { get; protected set; }
        public int Sector { get; protected set; }
        public override string ToString()
        {
            return $"{(this.Left == true ? "Левый" : "Правый")} {this.Name}, {this.SectorName} №{this.Sector} (";
        }
    }
}
