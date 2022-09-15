using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Security.Claims;
using ViciBuzzDriverApp.Models;

namespace ViciBuzzDriverApp.Controllers
{
    public class RequestOrderController : Controller
    {
        //Injecting usermanager in controller

        


        private readonly ILogger<RequestOrderController> _logger;
        private readonly IConfiguration _Configure;
        private readonly string apiBaseUrl;


        public RequestOrderController(ILogger<RequestOrderController> logger, IConfiguration configure)
        {
            _logger = logger;
            _Configure = configure;
            this.apiBaseUrl = _Configure.GetValue<string>("WebAPIBaseUrl");
        }

        [HttpGet]

        public ActionResult Index()
        {
            List<RequestOrderViewModel> apiResponse = new List<RequestOrderViewModel>();
            //List<ViewModel> viewModel = new List<ViewModel>();

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(apiBaseUrl);
                apiResponse = JsonConvert.DeserializeObject<List<RequestOrderViewModel>>(json);
            }

            foreach (var items in apiResponse)
            {
                items.Id.ToString();
                //viewModel.Add(items);
            }
            // viewModel = JsonConvert.DeserializeObject<List<ViewModel>>();
            return View(apiResponse);
        }

        public ActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrder(RequestOrderViewModel requestOrderViewModel)
        {
            requestOrderViewModel.MadeBy = User.Identity.Name;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
           // var user =  _userManager.FindByIdAsync(userId);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<RequestOrderViewModel>("Order", requestOrderViewModel);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(requestOrderViewModel);
        }


    }
}
