using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Models
{
    public class ParkingSpaceModel
    {
        [Key]
        public long ID { get; set; }
        public ParkingLotModel ParkingLotId { get; set; }
        public SpaceshipModel SpaceShipId { get; set; }

        


    }
}
