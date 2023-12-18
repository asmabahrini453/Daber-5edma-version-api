using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Daber_5edma_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;


namespace Daber_5edma_WebApp.Controllers
{
    public class CandidatWebController : Controller
    {
        private readonly ILogger<CandidatWebController> _logger;
        private readonly HttpClient _candidat;

        public CandidatWebController(ILogger<CandidatWebController> logger)
        {
            _logger = logger;
            _candidat = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44384")
            };
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _candidat.GetAsync("api/Candidats/get-all-Candidats");
            if (response.IsSuccessStatusCode)
            {
                var candidats = await response.Content.ReadFromJsonAsync<IEnumerable<Candidat>>();
                return View(candidats);
            }
            else
            {
                return View(null);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await _candidat.GetAsync($"api/Candidats/get-Candidat-by-id/{id}");

            if (response.IsSuccessStatusCode)
            {
                var candidat = await response.Content.ReadFromJsonAsync<Candidat>();
                return View(candidat);
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
        public async Task<IActionResult> Create(Candidat candidat)
        {
            HttpResponseMessage response = await _candidat.PostAsJsonAsync("api/Candidats/create-candidat", candidat);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(candidat);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _candidat.GetAsync($"Candidats/get-Candidat-by-id/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var candidat = JsonConvert.DeserializeObject<Candidat>(jsonString);
                return View(candidat);
            }
            else
            {
                // Handle error
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Candidat candidat)
        {
            HttpResponseMessage response = await _candidat.PutAsJsonAsync($"api/Candidats/edit-candidat/{id}", candidat);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(candidat);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await _candidat.DeleteAsync($"api/Candidats/delete-candidat/{id}");

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
