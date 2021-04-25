using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MyMovies.Common;
using MyMovies.Mappings;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Service
{
    public class SideBarService : ISideBarService
    {
        private readonly SideBarConfig _sideBarConfig;

        private IMoviesService _service { get; set; }
        public SideBarService(IMoviesService service, IOptions<SideBarConfig> sideBarConfig)
        {
            _service = service;
            _sideBarConfig = sideBarConfig.Value;
        }

        public MovieSidebarDataModel GetSidebarData()
        {
            var sidebarModel = new MovieSidebarDataModel();
            var topMoviesCount = _sideBarConfig.TopMovies;
            var mostRecentMoviesCount = _sideBarConfig.MostRecentMovies;
            if (topMoviesCount > 20)
            {
                topMoviesCount = 20;
            }
            if (mostRecentMoviesCount > 20)
            {
                mostRecentMoviesCount = 20;
            }
            var topMovies = _service.GetTopMovies(topMoviesCount);
            var mostRecentMovies = _service.GetMostRecentMovies(mostRecentMoviesCount);

            sidebarModel.TopMovies = topMovies.Select(x => x.ToMovieSidebarModel()).ToList();
            sidebarModel.MostRecentMovies = mostRecentMovies.Select(x => x.ToMovieSidebarModel()).ToList();

            return sidebarModel;
        }
    }


}
