using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.DtoModels
{
    public class StatusModel
    {
        public StatusModel()
        {
            Success = true;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
