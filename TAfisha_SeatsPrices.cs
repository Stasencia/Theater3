using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater
{
    [Table(Name = "Afisha_SeatsPrices")]
    class TAfisha_SeatsPrices
    {
        [Column(IsPrimaryKey = true)]
        public int Performance_Id { get; set; }
        [Column]
        public decimal ParterPrice { get; set; }
        [Column]
        public decimal BeljetazhPrice { get; set; }
        [Column]
        public decimal BenuarPrice { get; set; }
    }
}
