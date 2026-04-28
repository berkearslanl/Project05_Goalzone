using GoalZoneProject.WebUI.Dtos.FixtureDtos;
using GoalZoneProject.WebUI.Dtos.MatchEventDtos;
using GoalZoneProject.WebUI.Dtos.MatchStatisticDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GoalZoneProject.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddFixture()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddFixture(CreateFixtureDto createFixtureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonSerializer.Serialize(createFixtureDto);
            var stringcontent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7194/api/Fixtures", stringcontent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("AddFixture");
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddMatchEvent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddMatchEvent(CreateMatchEventDto createMatchEventDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonSerializer.Serialize(createMatchEventDto);
            var stringcontent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7194/api/MatchEvents", stringcontent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("AddMatchEvent");
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddMatchStats()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddMatchStats(CreateMatchStatisticDto createMatchStatisticDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonSerializer.Serialize(createMatchStatisticDto);
            var stringcontent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7194/api/MatchStats", stringcontent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("AddMatchStats");
            }
            return View();
        }
    }
}
