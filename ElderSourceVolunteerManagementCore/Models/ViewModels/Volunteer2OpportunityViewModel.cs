using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElderSourceVolunteerManagementCore.Models.ViewModels
{
    public class Volunteer2OpportunityViewModel
    {
        public Volunteer Volunteer { get; set; }
        public Opportunity Opportunity { get; set; }
        public int Hours { get; set; }
        public IEnumerable<Cart.CartLine> OpportunityList { get; set; }
        public IEnumerable<Opportunity> Opportunities { get; set; }
    }
}
