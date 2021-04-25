using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Common.Models
{
    public class LogData
    {
        public LogType Type { get; set; }
        public DateTime DateCreated { get; set; }
        public string Message { get; set; }
    }
}
