using AutoMapper;
using BookmateApp.DTOs.Requests;
using BookmateApp.DTOs.Responses;
using BookmateApp.Entities;

namespace BookmateApp.Services.Mappings.Extensions;

public static class UserMappingExtensions
{
    public static UserResponse ConvertToUserResponse(this Participant user, IMapper mapper) => 
        mapper.Map<UserResponse>(user);
    public static Participant ConvertFromUserLoginRequest(this UserLoginRequest userRequest, IMapper mapper) => 
        mapper.Map<Participant>(userRequest);
}