using GoalZoneProject.WebUI.Dtos.FixtureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace GoalZoneProject.WebUI.Controllers
{
    public class FixtureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FixtureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int week = 1)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7194/api/Fixtures/GetByWeek/{week}");
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFixtureDto>>(json);
            ViewBag.SelectedWeek = week;
            return View(values);
        }
    }
}
