using Daber_5edma_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Daber_5edma_WebApp.Controllers
{
    public class CompanyWebController : Controller
    {
        private readonly ILogger<CompanyWebController> _logger;
        private readonly HttpClient _company;

        public CompanyWebController(ILogger<CompanyWebController> logger)
        {
            _logger = logger;
            _company = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44384")
            };
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _company.GetAsync("api/Companies/get-all-companies");
            if (response.IsSuccessStatusCode)
            {
                var companies = await response.Content.ReadFromJsonAsync<IEnumerable<Company>>();
                return View(companies);
            }
            else
            {
                return View(null);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await _company.GetAsync($"api/Companies/get-company-by-id/{id}");

            if (response.IsSuccessStatusCode)
            {
                var company = await response.Content.ReadFromJsonAsync<Company>();
                return View(company);
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
        public async Task<IActionResult> Create(Company company)
        {
            HttpResponseMessage response = await _company.PostAsJsonAsync("api/Companies/create-company", company);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(company);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _company.GetAsync($"api/Companies/get-company-by-id/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var company = JsonConvert.DeserializeObject<Company>(jsonString);
                return View(company);
            }
            else
            {
                // Handle error
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Company company)
        {
            HttpResponseMessage response = await _company.PutAsJsonAsync($"api/Companies/edit-company/{id}", company);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(company);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await _company.DeleteAsync($"api/Companies/delete-company/{id}");

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
