namespace FizzBuzzUI.Controllers
{
    using System.Web.Mvc;

    using FizzBuzzDataModels;

    using FizzBuzzServices;

    using Models;

    using PagedList;

    public class FizzBuzzController : Controller
    {
        private readonly IFizzBuzzProvider fizzBuzzProvider;

        public FizzBuzzController(IFizzBuzzProvider fizzBuzzProviderInj)
        {
            fizzBuzzProvider = fizzBuzzProviderInj;
        }

        public ActionResult Index()
        {
            return View(new FizzBuzzViewModel());
        }

        public ActionResult FizzBuzzList(FizzBuzzViewModel modelInput, int page = 1, int pageSize = 20)
        {
            var fizzBuzzList = fizzBuzzProvider.GetFizzBuzzList(new FizzBuzzRequest { UserInput = modelInput.UserInput }).FizzBuzzList;

            return View("Index", new FizzBuzzViewModel() { UserInput = modelInput.UserInput, FizzBuzzList = new PagedList<FizzBuzz>(fizzBuzzList, page, pageSize) });
        }
    }
}