﻿namespace SpaceProgram.BusinessLayer.DtoModels;

public class UserDto
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public UserDto()
    {
    }
}
