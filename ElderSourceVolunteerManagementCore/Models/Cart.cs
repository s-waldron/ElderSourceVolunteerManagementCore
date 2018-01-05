using System.Collections.Generic;
using System.Linq;

namespace ElderSourceVolunteerManagementCore.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(Opportunity opportunity)
        {
            CartLine line = lineCollection
                .Where(o => o.Opportunity.OPPORTUNITYID == opportunity.OPPORTUNITYID)
                .FirstOrDefault();
            if(line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Opportunity = opportunity
                });
            }// end if(line == null) check
        }// end AddItem method

        public virtual void RemoveLine(Opportunity opportunity) =>
            lineCollection.RemoveAll(l => l.Opportunity.OPPORTUNITYID == opportunity.OPPORTUNITYID);

        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines => lineCollection;

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Opportunity Opportunity { get; set; }

        }// end CartList class
    }// end Cart class
}// end ElderSourceVolunteerManagementCore namespace
