﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElderSourceVolunteerManagementCore.Models.ViewModels
{
    public class AuditViewModel
    {
        public IEnumerable<VolunteerUpdateUser> AuditList { get; set; }
        public Volunteer Volunteer { get; set; }
    }
}