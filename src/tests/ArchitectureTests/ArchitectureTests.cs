using FluentAssertions;
using NetArchTest.Rules;

namespace ArchitectureTests;

public class ArchitectureTests
{
    private const string ApplicationNamespace = "Application";
    private const string DomainNamespace = "Domain";
    private const string PersistenceNamespace = "Persistence";


    [Fact]
    public void Domain_Should_Not_HaveDependecyOnOtherProjects()
    {
        //Arrange
        var assembly = Domain.AssemblyReference.Assembly;

        var otherProjects = new[]
        {
                ApplicationNamespace,
                PersistenceNamespace,
            };

        //Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        //Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Application_Should_Not_HaveDependecyOnOtherProjects()
    {
        //Arrange
        var assembly = Application.AssemblyReference.Assembly;

        var otherProjects = new[]
        {
                PersistenceNamespace,
            };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        //Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    //[Fact]
    //public void Infrastructure_Should_Not_HaveDependecyOnOtherProjects()
    //{
    //    //Arrange
    //    var assembly = Infrastructure.AssemblyReference.Assembly;

    //    var otherProjects = new[]
    //    {
    //            PresentationNamespace,
    //            AppNamespace
    //        };

    //    //Act
    //    var testResult = Types
    //        .InAssembly(assembly)
    //        .ShouldNot()
    //        .HaveDependencyOnAny(otherProjects)
    //        .GetResult();

    //    //Assert
    //    testResult.IsSuccessful.Should().BeTrue();
    //}

    //[Fact]
    //public void Persistence_Should_Not_HaveDependecyOnOtherProjects()
    //{
    //    //Arrange
    //    var assembly = Persistence.AssemblyReference.Assembly;

    //    var otherProjects = new[]
    //    {

    //        };

    //    //Act
    //    var testResult = Types
    //        .InAssembly(assembly)
    //        .ShouldNot()
    //        .HaveDependencyOnAny(otherProjects)
    //        .GetResult();

    //    //Assert
    //    testResult.IsSuccessful.Should().BeTrue();
    //}


    //[Fact]
    //public void Presentation_Should_Not_HaveDependecyOnOtherProjects()
    //{
    //    //Arrange
    //    var assembly = Presentation.AssemblyReference.Assembly;

    //    var otherProjects = new[]
    //    {
    //            AppNamespace,
    //            PersistenceNamespace,
    //        };

    //    //Act
    //    var testResult = Types
    //        .InAssembly(assembly)
    //        .ShouldNot()
    //        .HaveDependencyOnAny(otherProjects)
    //        .GetResult();

    //    //Assert
    //    testResult.IsSuccessful.Should().BeTrue();
    //}

    [Fact]
    public void Handlers_Should_Have_DependencyOnDomain()
    {
        // Arrange
        var assembly = Application.AssemblyReference.Assembly;

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .That()
            .HaveNameEndingWith("Handler")
            .Should()
            .HaveDependencyOn(DomainNamespace)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    //[Fact]
    //public void Controllers_Should_HaveDependencyOnMediatR()
    //{
    //    // Arrange
    //    var assembly = Presentation.AssemblyReference.Assembly;

    //    // Act
    //    var testResult = Types
    //        .InAssembly(assembly)
    //        .That()
    //        .HaveNameEndingWith("Controller")
    //        .Should()
    //        .HaveDependencyOn("MediatR")
    //        .GetResult();

    //    // Assert
    //    testResult.IsSuccessful.Should().BeTrue();
    //}
}

