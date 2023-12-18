using Daber_5edma_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Daber_5edma_WebApp.Controllers
{
    public class JobOfferWebController : Controller
    {
        private readonly ILogger<JobOfferWebController> _logger;
        private readonly HttpClient _joboffer;

        public JobOfferWebController(ILogger<JobOfferWebController> logger)
        {
            _logger = logger;
            _joboffer = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44384")
            };
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _joboffer.GetAsync("api/JobOffers/get-all-joboffers");
            if (response.IsSuccessStatusCode)
            {
                var joboffers = await response.Content.ReadFromJsonAsync<IEnumerable<JobOffer>>();
                return View(joboffers);
            }
            else
            {
                return View(null);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await _joboffer.GetAsync($"api/JobOffers/get-joboffer-by-id/{id}");

            if (response.IsSuccessStatusCode)
            {
                var joboffer = await response.Content.ReadFromJsonAsync<JobOffer>();
                return View(joboffer);
            }
            else
            {
                return View(null);
            }
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobOffer joboffer)
        {
            HttpResponseMessage response = await _joboffer.PostAsJsonAsync("api/JobOffers/create-joboffer", joboffer);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(joboffer);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _joboffer.GetAsync($"api/JobOffers/get-joboffer-by-id/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var joboffer = JsonConvert.DeserializeObject<JobOffer>(jsonString);
                return View(joboffer);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, JobOffer joboffer)
        {
            HttpResponseMessage response = await _joboffer.PutAsJsonAsync($"api/JobOffers/edit-joboffer/{id}", joboffer);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(joboffer);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await _joboffer.DeleteAsync($"api/JobOffers/delete-joboffer/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
