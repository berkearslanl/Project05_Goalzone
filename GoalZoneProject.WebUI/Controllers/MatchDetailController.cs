using GoalZoneProject.WebUI.Dtos.FixtureDtos;
using GoalZoneProject.WebUI.Dtos.MatchEventDtos;
using GoalZoneProject.WebUI.Dtos.MatchStatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace GoalZoneProject.WebUI.Controllers
{
    public class MatchDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MatchDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var fixtureResponse = await client.GetAsync($"https://localhost:7194/api/Fixtures/{id}");
            var fixtureJson = await fixtureResponse.Content.ReadAsStringAsync();
            var fixture = JsonConvert.DeserializeObject<ResultFixtureDto>(fixtureJson);

            var eventResponse = await client.GetAsync($"https://localhost:7194/api/MatchEvents/GetByFixture/{id}");
            var eventJson = await eventResponse.Content.ReadAsStringAsync();
            var events = JsonConvert.DeserializeObject<List<ResultMatchEventDto>>(eventJson);

            ViewBag.Events = events;

            var statResponse = await client.GetAsync($"https://localhost:7194/api/MatchStats/GetByFixture/{id}");
            var statJson = await statResponse.Content.ReadAsStringAsync();
            var stats = JsonConvert.DeserializeObject<ResultMatchStatisticDto>(statJson);

            ViewBag.Stats = new List<ResultMatchStatisticDto>
{
   stats
};

            return View(fixture);
        }
    }
}
