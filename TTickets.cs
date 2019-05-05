using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Threading.Tasks;

namespace Theater
{
    [Table(Name = "Tickets")]
    public class TTickets
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public int User_Id { get; set; }
        [Column]
        public int Performance_info_id { get; set; }
        [Column]
        public decimal Price { get; set; }
        [Column]
        public string HallPart { get; set; }
        [Column]
        public bool Left { get; set; }
        [Column]
        public int Sector { get; set; }
        [Column]
        public int Seat { get; set; }

    }
}
