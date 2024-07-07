using Xunit;
using PlateRate.Application.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using PlateRate.Domain.Constants;
using FluentAssertions;

namespace PlateRate.Application.User.Tests;

public class UserContextTests
{
    [Fact()]
    public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCurrentUser()
    {
        // arrange

        var httpContextAccessorMoq = new Mock<IHttpContextAccessor>();
        var claims = new List<Claim>() 
        {
            new(ClaimTypes.NameIdentifier, "1"),
            new(ClaimTypes.Email,"test@test.com"),
            new(ClaimTypes.Role,UserRoles.Admin),
            new(ClaimTypes.Role,UserRoles.User)
        };

        var user = new ClaimsPrincipal(new ClaimsIdentity(claims,"Test"));

        httpContextAccessorMoq.Setup(x => x.HttpContext).Returns(new DefaultHttpContext()
        {
            User = user
        });

        var userContext = new UserContext(httpContextAccessorMoq.Object);

        // act

        var currentUser = userContext.GetCurrentUser();

        // assert

        currentUser.Should().NotBeNull();
        currentUser.Id.Should().Be("1");
        currentUser.Email.Should().Be("test@test.com");
        currentUser.Roles.Should().ContainInOrder(UserRoles.Admin,UserRoles.User);
        
    }


    [Fact()]
    public void GetCurrentUser_WithCurrentUserNotPresent_ThrowsInvalidOperationException()
    {
        // Arrange

        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        httpContextAccessorMock.Setup(x => x.HttpContext).Returns((HttpContext)null);

        var userContext = new UserContext(httpContextAccessorMock.Object);

        // Act  

        Action action = () => userContext.GetCurrentUser();

        // Assert

        action.Should().Throw<InvalidOperationException>()
            .WithMessage("User context is not present");
    }
}