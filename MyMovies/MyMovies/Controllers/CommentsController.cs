using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Common.Exceptions;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System;
using MyMovies.Mappings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    public class CommentsController : Controller
    {
        private ICommentsService _service { get; set; }
        public CommentsController(ICommentsService service)
        {
            _service = service;
        }
        [HttpPost]
        [Authorize]
        public IActionResult Add(string comment, int movieId)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);
            var response = _service.Add(comment, movieId, userId);
            if (response.Success)
            {
                return RedirectToAction("Overview", "Movies");
            }
            else
            {
                return RedirectToAction("ActionNotSuccessful", "Info", new { Message = response.Message });
            }
        }

        public IActionResult Delete(int id)
        {
            var response = _service.Delete(id);
            if (response.Success)
            {
                return RedirectToAction("Overview", "Movies");
            }
            else
            {
                return RedirectToAction("Overview", "Movies", new { ErrorMessage = response.Message });
            }
        }
        //[HttpGet]
        //public IActionResult Update(int id)
        //{
        //    try
        //    {
        //        var comment = _service.GetCommentById(id);
        //        return View(comment.ToUpdateCommentModel());
        //    }
        //    catch (MoviesException ex)
        //    {
        //        return RedirectToAction("ActionNotSuccessful", "Info", new { Message = ex.Message });
        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction("ErrorNotFound", "Info");
        //    }
        //}
        //[HttpPost]
        //public IActionResult Update(UpdateCommentModel commentModel)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var response = _service.Update(commentModel.ToModel());
        //            if (response.Success)
        //            {
        //                return RedirectToAction("Overview", "Movies", new { SuccessMessage = response.Message });
        //            }
        //            else
        //            {
        //                return RedirectToAction("Overview", "Movies", new { ErrorMessage = response.Message });
        //            }
        //        }

        //        return View(commentModel);
        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction("ErrorNotFound", "Info");
        //    }
        //}
    }
}
