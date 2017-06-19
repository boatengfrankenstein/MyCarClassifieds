using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarClassifieds.Models
{
    public class VehicleDTO
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool IsRegistered { get; set; }
        [Required]
        public string ContactName { get; set; }
        [Required]
        public string ContactPhone { get; set; }
        [Required]
        public string ContactEmail { get; set; }
        public ICollection<int> Features { get; set; }

        public VehicleDTO()
        {
            Features = new Collection<int>();
        }
    }
}
