using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Models
{
    public class ParkingSpaceModel
    {
        [Key]
        public long ID { get; set; }
        public SpaceshipModel Spaceship { get; set; }

        [ForeignKey("ParkingLotID")]
        public long ParkingLotID { get; set; }
        public ParkingLotModel ParkingLot { get; set; }
    }
}
