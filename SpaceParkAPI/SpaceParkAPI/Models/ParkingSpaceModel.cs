using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Models
{
    public class ParkingSpace
    {
        [Key]
        public long ID { get; set; }
        public int ParkingLotId { get; set; }
        public int SpaceShipId { get; set; }


    }
}
