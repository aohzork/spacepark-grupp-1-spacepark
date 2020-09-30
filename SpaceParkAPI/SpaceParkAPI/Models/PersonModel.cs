using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpaceParkAPI.Models
{
    public class PersonModel
    {
        [Key]
        public long ID { get; set; }
        public string Name { get; set; }

        [ForeignKey("Spaceship")]
        public long SpaceshipID { get; set; }
        public SpaceshipModel Spaceship { get; set; }
    }
}
