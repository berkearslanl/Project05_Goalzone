using GoalZoneProject.WepApi.Context;
using GoalZoneProject.WepApi.Dtos.FixtureDtos;
using GoalZoneProject.WepApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoalZoneProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixturesController : ControllerBase
    {
        private readonly ApiContext _context;

        public FixturesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult FixtureList()
        {
            var values = _context.Fixtures.Include(x => x.HomeTeam).Include(x => x.AwayTeam).ToList();
            return Ok(values);
        }
        [HttpGet("GetByWeek/{weekNumber}")]
        public IActionResult GetByWeek(int weekNumber)
        {
            var values = _context.Fixtures
                        .Include(x => x.HomeTeam)
                        .Include(x => x.AwayTeam)
                        .Where(x => x.WeekNumber == weekNumber)
                        .ToList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetFixtureById(int id)
        {
            var value = _context.Fixtures
                        .Include(x => x.AwayTeam)
                        .Include(x => x.HomeTeam)
                        .FirstOrDefault(x => x.FixtureId == id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddFixture(CreateFixtureDto createFixtureDto)
        {
            var value = new Fixture
            {
                AwayTeamHalfScore = createFixtureDto.AwayTeamHalfScore,
                AwayTeamId = createFixtureDto.AwayTeamId,
                AwayTeamScore = createFixtureDto.AwayTeamScore,
                HomeTeamHalfScore = createFixtureDto.HomeTeamHalfScore,
                HomeTeamScore = createFixtureDto.HomeTeamScore,
                MatchDate = createFixtureDto.MatchDate,
                Status = createFixtureDto.Status,
                WeekNumber = createFixtureDto.WeekNumber,
                Stadium = createFixtureDto.Stadium,
                ImageUrl = createFixtureDto.ImageUrl,
                HomeTeamId = createFixtureDto.HomeTeamId
            };
            _context.Fixtures.Add(value);
            _context.SaveChanges();
            return Ok("Başarıya eklendi");
        }
    }
}
