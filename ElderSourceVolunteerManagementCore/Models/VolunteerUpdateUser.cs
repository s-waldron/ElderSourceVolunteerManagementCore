﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElderSourceVolunteerManagementCore.Models
{
    public class VolunteerUpdateUser
    {
        [Key]
        public int VOLUNTEERUPDATEUSERID { get; set; }
        [ForeignKey ("Volunteer")]
        public int VOLUNTEERID { get; set; }
        public Volunteer Volunteer { get; set; }
        [ForeignKey ("AppUsers")]
        public string Email { get; set; }
        public AppUsers AppUsers { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
