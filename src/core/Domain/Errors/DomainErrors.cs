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

    public static class LeaveRequest
    {
        public static readonly Func<Guid, Error> NotFound = leaveId => new(
                "LeaveRequest.NotFound",
                $"The specified leave {leaveId} could not be found.");

        public static readonly Func<Guid, Error> NotFoundByEmpId = employeeId => new(
                "LeaveRequest.NotFound",
                $"The specified leave for employee {employeeId} could not be found.");

        public static readonly Error NoEmployees = new(
                "LeaveRequest.NoEmployees",
                $"Don't have any employees");
    }
}
