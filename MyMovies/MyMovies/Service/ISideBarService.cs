using MyMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Service
{
    public interface ISideBarService
    {
        MovieSidebarDataModel GetSidebarData();
    }
}
