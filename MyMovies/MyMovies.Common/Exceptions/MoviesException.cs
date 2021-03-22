using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Common.Exceptions
{
    public class MoviesException : Exception
    {
        public MoviesException(string message) : base(message)
        {

        }
    }
}
