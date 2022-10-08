﻿using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete
{
    public class JobApplicationAndJobPosting : EntityBase<int>, IEntity
    {

        public JobApplication JobApplication{ get; set; }
        public int JobApplicationID { get; set; }
        public JobPosting JobPosting { get; set; }
        public int JobPostingID { get; set; }
    }
}