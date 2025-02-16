using Demo.Core.Models;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Users
{
    public record CreateUserRequest(string FirstName, string LastName,string? Domain = null) : IRequest<User>
    {
    }
}
