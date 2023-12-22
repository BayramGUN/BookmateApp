using BookmateApp.DTOs.Requests;
using BookmateApp.DTOs.Responses;
using BookmateApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmateApp.Services.ServiceInterfaces;
public interface IUserService
{
    Task<UserResponse?> ValidateUser(UserLoginRequest loginRequest);
}
