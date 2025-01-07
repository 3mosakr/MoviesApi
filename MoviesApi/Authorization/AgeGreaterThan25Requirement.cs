using Microsoft.AspNetCore.Authorization;

namespace MoviesApi.Authorization
{
    public class AgeGreaterThan25Requirement : IAuthorizationRequirement
    {
    }
}
