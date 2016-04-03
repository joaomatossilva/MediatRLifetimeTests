using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MediatR;
using TestWithStructureMap.Handlers;

namespace TestWithStructureMap.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Home
        public async Task<ActionResult> Index()
        {
            var model = await _mediator.SendAsync(new Home.Query());
            return View(model);
        }
    }
}