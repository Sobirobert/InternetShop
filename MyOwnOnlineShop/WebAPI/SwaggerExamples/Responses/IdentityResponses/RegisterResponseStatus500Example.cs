﻿using Swashbuckle.AspNetCore.Filters;
using WebAPI.Wrappers;

namespace WebAPI.SwaggerExamples.Responses.IdentityResponses;
public class RegisterResponseStatus500Example : IExamplesProvider<RegisterResponseStatus500>
{
    public RegisterResponseStatus500 GetExamples()
    {
        return new RegisterResponseStatus500
        {
            Succeeded = false,
            Message = "User already exists!"
        };
    }
}

public class RegisterResponseStatus500 : Response
{ }