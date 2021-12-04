using Base.BUSINESS.Interfaces;
using BaseAPI.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamGM.CROSSCUTTING.UnitOfWork;
using TeamGM.DATA.UnitOfWork;
using TeamGM.DOMAIN.Interfaces.Helpers;
using TeamGM.DOMAIN.Notifications;

namespace TeamGMAPI.Configuration
{
    public static class IoCConfig
    {
        public static IServiceCollection AddTeamGmService(this IServiceCollection services)
        {
            services.AddRepositoryService();
            services.AddHelpersService();

            return services;
        }


        private static IServiceCollection AddRepositoryService(this IServiceCollection service)
        {
            service.AddScoped<IDapperUnitOfWork, DapperUnitOfWork>();
            service.AddScoped<DbSession>();

            return service;
        }

        private static IServiceCollection AddHelpersService(this IServiceCollection service)
        {
            service.AddScoped<INotificador, Notificador>();

            service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            service.AddScoped<IUser, AspNetUser>();

            return service;
        }
    }
}
