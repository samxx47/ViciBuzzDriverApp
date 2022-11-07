using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Security.Claims;
using ViciBuzzDriverApp.Models;
using Microsoft.AspNetCore.Identity;

namespace ViciBuzzDriverApp.Controllers
{
    public class DeliverOrderController : Controller
    {
        private readonly ILogger<DeliverOrderController> _logger;
        private readonly IConfiguration _Configure;
        private readonly string apiDeliverUrl;

        public DeliverOrderController(ILogger<DeliverOrderController> logger, IConfiguration configure)
        {
            _logger = logger;
            _Configure = configure;
            this.apiDeliverUrl = _Configure.GetValue<string>("WebAPIDeliverUrl");
        }
        [HttpGet]

        public ActionResult Index()
        {
            List<DeliverOrderViewModel> apiResponse = new List<DeliverOrderViewModel>();
            //List<ViewModel> viewModel = new List<ViewModel>();

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(apiDeliverUrl);
                apiResponse = JsonConvert.DeserializeObject<List<DeliverOrderViewModel>>(json);
            }

            foreach (var items in apiResponse)
            {
                items.Id.ToString();
                //viewModel.Add(items);
            }
            // viewModel = JsonConvert.DeserializeObject<List<ViewModel>>();
            return View(apiResponse);
        }



        public ActionResult CreateDelivery()
        {
            return View();
        }



        [HttpPost]
        public ActionResult CreateDelivery(DeliverOrderViewModel deliverOrderViewModel)
        {
            deliverOrderViewModel.AssignedTo = User.Identity.Name;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // var user =  _userManager.FindByIdAsync(userId);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiDeliverUrl );

                //HTTP POST
                var postTask = client.PostAsJsonAsync<DeliverOrderViewModel>("Deliver", deliverOrderViewModel);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(deliverOrderViewModel);
        }
    }
}
