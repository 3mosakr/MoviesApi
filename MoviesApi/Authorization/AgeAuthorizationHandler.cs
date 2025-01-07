using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MoviesApi.Authorization
{
    public class AgeAuthorizationHandler : AuthorizationHandler<AgeGreaterThan25Requirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgeGreaterThan25Requirement requirement)
        {
            var dateOfBirth = context.User.FindFirstValue("DateOfBirth");
            if (dateOfBirth is null)
                return Task.CompletedTask;

            var yearOfBirth = DateTime.Parse(dateOfBirth).Year;
            if (DateTime.Now.Year - yearOfBirth > 25)
                context.Succeed(requirement);
            
            return Task.CompletedTask;
        }
    }
}
