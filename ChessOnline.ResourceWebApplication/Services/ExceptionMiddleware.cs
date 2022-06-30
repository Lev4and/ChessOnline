﻿using ChessOnline.Model.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace ChessOnline.ResourceWebApplication.Services
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(JsonConvert.SerializeObject(new BaseResponseModel<object?>(null,
                new Status(HttpStatusCode.InternalServerError, StatusName.Error, "Внутренняя ошибка сервера")),
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }));
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");

                await HandleExceptionAsync(httpContext, ex);
            }
        }
    }
}
