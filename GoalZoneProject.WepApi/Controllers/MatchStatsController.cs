using GoalZoneProject.WepApi.Context;
using GoalZoneProject.WepApi.Dtos.MatchStatisticDtos;
using GoalZoneProject.WepApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoalZoneProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchStatsController : ControllerBase
    {
        private readonly ApiContext _context;

        public MatchStatsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult MatchStatList()
        {
            var values = _context.MatchStats.ToList();
            return Ok(values);
        }
        [HttpGet("GetByFixture/{fixtureId}")]
        public IActionResult GetByFixture(int fixtureId)
        {
            var values = _context.MatchStats.FirstOrDefault(x => x.FixtureId == fixtureId);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateMatchStats(CreateMatchStatisticDto createMatchStatisticDto)
        {
            var values = new MatchStats
            {
                AwayCorners = createMatchStatisticDto.AwayCorners,
                AwayFouls = createMatchStatisticDto.AwayFouls,
                AwayOffsides = createMatchStatisticDto.AwayOffsides,
                AwayPassAccuracy = createMatchStatisticDto.AwayPassAccuracy,
                AwayPasses = createMatchStatisticDto.AwayPasses,
                AwayPossession = createMatchStatisticDto.AwayPossession,
                AwayRedCards = createMatchStatisticDto.AwayRedCards,
                AwayShots = createMatchStatisticDto.AwayShots,
                AwayShotsOnTarget = createMatchStatisticDto.AwayShotsOnTarget,
                AwayYellowCards = createMatchStatisticDto.AwayYellowCards,
                FixtureId = createMatchStatisticDto.FixtureId,
                HomeCorners = createMatchStatisticDto.HomeCorners,
                HomeFouls = createMatchStatisticDto.HomeFouls,
                HomeOffsides = createMatchStatisticDto.HomeOffsides,
                HomePassAccuracy = createMatchStatisticDto.HomePassAccuracy,
                HomePasses = createMatchStatisticDto.HomePasses,
                HomePossession = createMatchStatisticDto.HomePossession,
                HomeRedCards = createMatchStatisticDto.HomeRedCards,
                HomeShots = createMatchStatisticDto.HomeShots,
                HomeShotsOnTarget = createMatchStatisticDto.HomeShotsOnTarget,
                HomeYellowCards = createMatchStatisticDto.HomeYellowCards
            };
            _context.MatchStats.Add(values);
            _context.SaveChanges();
            return Ok("Ekleme başarılı");
        }
    }
}
