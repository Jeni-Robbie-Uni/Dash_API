using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_dash.Models
{
    public class RunningEvent
    {

        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string URL { get; set; }


        [Required]
        public string Location { get; set; }

        [Required]
        public string City { get; set; }
            

        public string Postcode { get; set; }
        [Required]
        public string Country { get; set; }



        [Required]
        public DateTime date { get; set; }

        [Required]
        public float longitude { get; set; }

        [Required]
        public float latitude { get; set; }

        public bool VirtualRace { get; set; }

        
    }
}
