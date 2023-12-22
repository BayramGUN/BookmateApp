using BookmateApp.Entities;
using BookmateApp.Infrastructure.Repositories.RepositoryInterFaces;
using BookmateApp.Infrastructure.Repositories.RepositoryInterfaces;
using BookmateApp.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookmateApp.DTOs.Requests;
using BookmateApp.DTOs.Responses;
using AutoMapper;
using BookmateApp.Services.Mappings.Extensions;

namespace BookmateApp.Services.ServiceImplementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserResponse?> ValidateUser(UserLoginRequest loginRequest)
    {
        var user = await _userRepository.GetUserByUsernameAsync(loginRequest.Username);
        return user.ConvertToUserResponse(_mapper);
    }
}

