using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.LocationDtos
{
    public class LocationDto
    {
        public string Country { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
    }
}
