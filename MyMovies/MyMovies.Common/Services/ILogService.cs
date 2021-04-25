using MyMovies.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Common.Services
{
    public interface ILogService
    {
        void Log(LogData logData);
    }
}
