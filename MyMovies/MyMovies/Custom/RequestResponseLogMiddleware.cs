using Microsoft.AspNetCore.Http;
using MyMovies.Common.Models;
using MyMovies.Common.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Custom
{
    public class RequestResponseLogMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestResponseLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogService logService )
        {
            var requestLog = JsonConvert.SerializeObject(new { RequestPath = httpContext.Request.Path });
            var requestLogData = new LogData() { Type = LogType.Info, DateCreated = DateTime.Now, Message = requestLog };
            logService.Log(requestLogData);

            await _next(httpContext);

            var responceLog = JsonConvert.SerializeObject(new { ResponseStatusCode = httpContext.Response.StatusCode.ToString() });
            var responseLogData = new LogData() { Type = LogType.Info, DateCreated = DateTime.Now, Message = responceLog };
            logService.Log(responseLogData);

        }
    }
}
