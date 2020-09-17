using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SpaceParkAPI.Models
{
    public class ParkingLotModel
    { 
        [Key]
        public long ID { get; set; }
        public long TotalAmount { get; set; }
        public ICollection<ParkingSpaceModel> ParkingSpaces { get; set; }
    }
}
