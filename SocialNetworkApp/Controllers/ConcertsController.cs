using SocialNetworkApp.Models;
using SocialNetworkApp.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace SocialNetworkApp.Controllers
{
    public class ConcertsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConcertsController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Create()
        {
            var viewModel = new ConcertFormViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }
    }
}