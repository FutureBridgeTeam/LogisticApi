﻿using LogisticApi.Application.DTOs.ResponseDTOs;
using LogisticApi.Application.Utilites;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace LogisticApi.API.Extensions
{
    public static class GlobalExceptionHandler
    {
        public static IApplicationBuilder AddExceptionHandlerService(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    int statusCode = (int)HttpStatusCode.InternalServerError;
                    string message = "Internal Server Error";
                    if (contextFeature is not null)
                    {
                        if (contextFeature.Error is IBaseException)
                        {
                            var error = contextFeature.Error;
                            statusCode = 400;
                            message = error.Message;

                        }
                    }
                    context.Response.StatusCode = statusCode;
                    await context.Response.WriteAsJsonAsync(new ResultDto(statusCode, false, message));
                });
            });
            return app;
        }
    }
}
