using Daber_5edma_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Daber_5edma_WebApp.Controllers
{
    public class JobApplicationWebController : Controller
    {
        private readonly ILogger<JobApplicationWebController> _logger;
        private readonly HttpClient _jobapp;

        public JobApplicationWebController(ILogger<JobApplicationWebController> logger)
        {
            _logger = logger;
            _jobapp = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44384")
            };
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _jobapp.GetAsync("api/JobApplications/get-all-jobapplications");
            if (response.IsSuccessStatusCode)
            {
                var jobapplications = await response.Content.ReadFromJsonAsync<IEnumerable<JobApplication>>();
                return View(jobapplications);
            }
            else
            {
                return View(null);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await _jobapp.GetAsync($"api/JobApplications/get-jobapplication-by-id/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jobapplication = await response.Content.ReadFromJsonAsync<JobApplication>();
                return View(jobapplication);
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
        public async Task<IActionResult> Create(JobApplication jobapplication)
        {
            HttpResponseMessage response = await _jobapp.PostAsJsonAsync("api/JobApplications/create-jobapplication", jobapplication);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(jobapplication);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _jobapp.GetAsync($"api/JobApplications/get-jobapplication-by-id/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var jobapplication = JsonConvert.DeserializeObject<JobApplication>(jsonString);
                return View(jobapplication);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, JobApplication jobapplication)
        {
            HttpResponseMessage response = await _jobapp.PutAsJsonAsync($"api/JobApplications/edit-jobapplication/{id}", jobapplication);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(jobapplication);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await _jobapp.DeleteAsync($"api/JobApplications/delete-jobapplication/{id}");

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
