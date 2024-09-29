using Domain.Shared;

namespace Domain.Errors;

public static class DomainErrors
{
    public static class Employee
    {
        public static readonly Func<string, Error> NotFound = userId => new(
                "Employee.NotFound",
                $"The specified user {userId} could not be found.");

        public static readonly Func<Guid, Error> NotFoundByEmpId = employeeId => new(
                "Employee.NotFound",
                $"The specified employee {employeeId} could not be found.");

        public static readonly Error FailedRegistration = new(
                "Employee.FailedRegistration",
                $"The specified user could not be found.");

        public static readonly Error NoEmployees = new(
                "Employee.NoEmployees",
                $"Don't have any employees");
    }
}
