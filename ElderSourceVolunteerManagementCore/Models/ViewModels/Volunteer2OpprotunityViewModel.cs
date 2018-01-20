﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElderSourceVolunteerManagementCore.Models.ViewModels
{
    public class Volunteer2OpprotunityViewModel
    {
        public Volunteer Volunteer { get; set; }
        public Opportunity Opportunity { get; set; }
        public IEnumerable<Opportunity> OpportunityList { get; set; }
    }
}