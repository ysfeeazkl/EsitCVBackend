﻿using EsitCV.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.CompanyDtos
{
    public class CompanyGetDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string? IpAddress { get; set; }
        public string Sector { get; set; }
        public string TaxNumber { get; set; }

        //public DateTime YearOfFoundation { get; set; }
        public string YearOfFoundation { get; set; }
        public DateTime LastLogin { get; set; }

        public Location Location { get; set; }
        public int LocationID { get; set; }
        public CompanyPicture CompanyPicture { get; set; }
        public int CompanyPictureID { get; set; }
    }
}
