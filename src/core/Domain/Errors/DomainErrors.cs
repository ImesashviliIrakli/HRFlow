using Domain.Shared;

namespace Domain.Errors;

public static class DomainErrors
{
    public static class Employee
    {
        public static readonly Func<string, Error> NotFound = id => new(
                "Employee.NotFound",
                $"The specified user {id} could not be found.");

        public static readonly Error FailedRegistration = new(
                "Employee.FailedRegistration",
                $"The specified user could not be found.");
    }
}
