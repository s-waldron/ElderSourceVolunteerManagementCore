using System.Collections.Generic;
using System.Linq;

namespace ElderSourceVolunteerManagementCore.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(Opportunity opportunity)
        {

        }// end AddItem method

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Opportunity Opportunity { get; set; }

        }// end CartList class
    }// end Cart class
}// end ElderSourceVolunteerManagementCore namespace
