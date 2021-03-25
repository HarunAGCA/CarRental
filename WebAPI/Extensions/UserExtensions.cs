using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.IoC;
using Core.Utilities.Security.JWT;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Extensions
{
    public static class UserExtensions
    {
        public static void AddAdminUserIfNotExist(this IApplicationBuilder app ,IAuthService authService, IUserService userService)
        {

            var result =  userService.GetByMail("admin@example.com");

            if (!result.IsSuccess)
            {
                throw new Exception();
            }

            if (result.Data == null)
            {
                authService.Register(new UserForRegisterDto
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "admin@example.com",
                    Password = "admin123"
                });
            }


        }

        private static IAuthService FromService(IAuthService authService)
        {
            return authService;
        }
    }
}
