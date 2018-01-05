using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ElderSourceVolunteerManagementCore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            if (!context.Volunteers.Any())
            {
                context.Volunteers.AddRange(
                    new Volunteer
                    {
                        FirstName = "John",
                        LastName = "Smith",
                        Email = "jsmith@somone.com"
                    },
                    new Volunteer
                    {
                        FirstName = "Jane",
                        LastName = "Doe",
                        Email = "jdoe@somewhere.com"
                    },
                    new Volunteer
                    {
                        FirstName = "Jack",
                        LastName = "Nimble",
                        Email = "jnimble@nimble.com"
                    }
                    );
                context.Opportunities.AddRange(
                    new Opportunity
                    {
                        OpportunityName = "Raking Leaves",
                        OpportunityDescription = "Need help raking leaves around the house."
                    },
                    new Opportunity
                    {
                        OpportunityName = "Moving Furniture",
                        OpportunityDescription = "Need help moving furniture around the house."
                    }
                    );
                context.SaveChanges();
            }// end if(!context.Volunteers.Any()) check
        }// end EnsurePopultated method
    }// end SeedData class
}// end ElderSourceVolunteerManagementCore.Models namespace
