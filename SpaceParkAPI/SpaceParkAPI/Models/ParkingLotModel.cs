using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SpaceParkAPI.Models
{
    public class ParkingLot
    { 
        [Key]
        public long ID { get; set; }
        public long TotalAmount { get; set; }
    }
}
